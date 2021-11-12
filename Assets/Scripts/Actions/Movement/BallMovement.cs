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

        [SerializeField] private float timeWishedToSpendOnAir;
        private float timeOnAir;





        private void Awake()
        {
            //_animator = GetComponentInChildren<Animator>();
            MovementComponent = GetComponent<CharacterController>();
            GetComponentInChildren<Bouncable>().OnBounce += GetBounce;


            transformInterpolater.oldVector = Vector3.zero;
            transformInterpolater.oldQuaternion = transform.rotation;
        }

        private void GetBounce(Vector3 colVector)
        {
            timeOnAir = 0f;
            movVerticalVector = Vector3.up;
            SetGravityToZero();
        }

        private bool isDebuging;


        private void Update()
        {
            #region Delete
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("T");
                Activate();
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
            #endregion


            if (!Activated)
                return;

            MoveTo(movVerticalVector);
            impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime);
        }

        private float EaseOutQuad(float progress)
        {
            return progress * progress * progress;
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

        private void MoveTo(Vector3 data)
        {
            timeOnAir += Time.deltaTime;

            data.Normalize();
            if (timeOnAir > timeWishedToSpendOnAir)
            {
                SetGravity();
            }






            data *= (speedMultiplier* maxSpeed * Time.deltaTime);


            Vector3 velocity = Vector3.Lerp(transformInterpolater.oldVector,
                data, transformInterpolater.vectorLerpCoefficient);

            if (impact != Vector3.zero && impact.sqrMagnitude < 12)
                impact = Vector3.zero;
            

            MovementComponent.Move(velocity + Vector3.up * (_gravityHolder.gravityCoefficient * Time.deltaTime)/* +
                                   impact * Time.deltaTime*/);
        }

        private void SetGravity()
        {
            if (MovementComponent.isGrounded)
                _gravityHolder.gravityCoefficient =
                    Mathf.Lerp(_gravityHolder.gravityCoefficient, 0, Time.deltaTime * 10f);
            else
                _gravityHolder.gravityCoefficient += GravityHolder.Gravity * Time.deltaTime;
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
        public void Activate()
        {
            Activated = true;
            SetGravity();
            //movVerticalVector = Vector3.up;
        }

        private void OnDestroy()
        {

        }


    }
}