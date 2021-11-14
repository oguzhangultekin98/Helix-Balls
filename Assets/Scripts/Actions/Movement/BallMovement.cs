using Assets.Scripts.Interactions.BallInteractions;
using System;
using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    public class BallMovement : MovementBase
    {
        private GravityHolder _gravityHolder = new GravityHolder();

        private Vector3 impact;
        public CharacterController MovementComponent { get; private set; }
        public bool Activated { get; private set; }

        //        private Animator _animator;

        [SerializeField] private TransformInterpolator transformInterpolater;

        private Vector3 movVerticalVector;
        private Vector3 movHorizontalVector;

        [SerializeField] private float timeWishedToSpendOnAir;
        private float timeOnAir;
        private float riseUpSpeedMultiplier;
        private float ballMass;

        private float maxTimeCanSpendOnAir = 1.2f;

        private void Awake()
        {
            //_animator = GetComponentInChildren<Animator>();
            MovementComponent = GetComponent<CharacterController>();
            GetComponentInChildren<Bouncable>().OnBounce += GetBounce;
            GetComponentInChildren<Hittable>().OnHit += GetHit;


            transformInterpolater.oldVector = Vector3.zero;
            transformInterpolater.oldQuaternion = transform.rotation;
        }

        private void GetHit(Vector3 colVector)
        {
            if (maxTimeCanSpendOnAir<timeOnAir)
            {
                timeWishedToSpendOnAir += 0.1f;
            }
            colVector.y = 0f;
            movHorizontalVector = (colVector * ballMass);
        }

        private void GetBounce(Vector3 reflectVector, float timeSpendOnAir)
        {
            timeOnAir = 0f;
            movVerticalVector.y = reflectVector.y;

            reflectVector.y = 0;

            if (reflectVector.sqrMagnitude > 0f)
            {
                movHorizontalVector = (movHorizontalVector - reflectVector).normalized*0.4f;
            }
            timeWishedToSpendOnAir = timeSpendOnAir;
        }

        private bool isDebuging;


        private void Update()
        {
            #region Delete
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("T");
                Activate(Vector3.zero);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("'D'EBUG");
                isDebuging = !isDebuging;
            }
            if (isDebuging)
            {
                Debug.Log("movVector: " + movVerticalVector);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                movHorizontalVector.x = 0.3f;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                movHorizontalVector.x = -0.3f;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                movHorizontalVector.z = 0.3f;
            }
            #endregion


            if (!Activated)
                return;

            MoveTo();
        }

        public void AddImpact(Vector3 dir, float force)
        {
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y;
            impact += dir.normalized * force;
        }

        private void ChangeGravityDirection()
        {

        }
        private float EaseOutQuad(float progress)
        {
            return 1 - Mathf.Pow(1 - progress, 4);
        }
        private void MoveTo()
        {
            timeOnAir += Time.deltaTime;
            if (timeOnAir < timeWishedToSpendOnAir)
            {
                MovementComponent.Move(Vector3.up * Time.deltaTime * riseUpSpeedMultiplier * EaseOutQuad(timeOnAir / timeWishedToSpendOnAir));
                SetGravityToZero();
            }
            else
            {
                SetGravity();
            }


            var movVector = movHorizontalVector * (speedMultiplier * maxSpeed * Time.deltaTime);
            var velocity = Vector3.Lerp(transformInterpolater.oldVector,
                movVector, transformInterpolater.vectorLerpCoefficient);

            /*if (impact != Vector3.zero && impact.sqrMagnitude < 12)
                impact = Vector3.zero;
            */

            MovementComponent.Move(velocity + movVerticalVector * (_gravityHolder.gravityCoefficient * Time.deltaTime) /*+
                                  impact * Time.deltaTime*/);
        }

        private void SetGravity()
        {
            if (MovementComponent.isGrounded)
                _gravityHolder.gravityCoefficient =
                    Mathf.Lerp(_gravityHolder.gravityCoefficient, 0, Time.deltaTime * 10f);
            else if (movVerticalVector.y < -0.1f)
                _gravityHolder.gravityCoefficient += GravityHolder.Gravity * Time.deltaTime;
            else
                _gravityHolder.gravityCoefficient -= GravityHolder.Gravity * Time.deltaTime;
        }

        public void SetGravityToZero()
        {
            _gravityHolder.gravityCoefficient = 0f;
        }


        public bool IsActive { get; }

        public void Deactivate()
        {
            Activated = false;
        }

        [ContextMenu("Start")]
        public void Activate(Vector3 horizontalMov)
        {
            Activated = true;
            SetGravity();
            movVerticalVector = Vector3.down;
            timeOnAir = 99f;
            riseUpSpeedMultiplier = UnityEngine.Random.Range(4.75f, 6.00f);
            ballMass = UnityEngine.Random.Range(0.75f, 1.25f);
            movHorizontalVector = horizontalMov;
        }

        private void OnDestroy()
        {
            GetComponentInChildren<Bouncable>().OnBounce -= GetBounce;
            GetComponentInChildren<Hittable>().OnHit -= GetHit;
        }
    }
}