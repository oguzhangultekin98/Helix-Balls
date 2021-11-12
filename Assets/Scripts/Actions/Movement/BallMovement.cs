using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    public class BallMovement : MovementBase
    {
        private GravityHolder _gravityHolder = new GravityHolder();

        protected Vector3 impact;
        public CharacterController MovementComponent { get; private set; }
        public bool Activated { get; private set; }

//        private Animator _animator;

        [SerializeField] protected TransformInterpolator transformInterpolater;

        protected virtual void Awake()
        {
            //_animator = GetComponentInChildren<Animator>();
            MovementComponent = GetComponent<CharacterController>();

            transformInterpolater.oldVector = Vector3.zero;
            transformInterpolater.oldQuaternion = transform.rotation;
        }
        private bool _isHit = false;
        private Vector3 _collisionVector;
       

      

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("T");
                Activate();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("C");
                MoveTo(Vector3.down);
            }


            if (!Activated)
                return;

            impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime);
        }


        public void AddImpact(Vector3 dir, float force)
        {
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y;
            impact += dir.normalized * force;
        }

        private void MoveTo(Vector3 data)
        {
            data.Normalize();

            data *= (speedMultiplier * maxSpeed * Time.deltaTime);


            Vector3 velocity = Vector3.Lerp(transformInterpolater.oldVector,
                data, transformInterpolater.vectorLerpCoefficient);

            if (impact != Vector3.zero && impact.sqrMagnitude < 12)
                impact = Vector3.zero;

            MovementComponent.Move(velocity + Vector3.up * (_gravityHolder.gravityCoefficient * Time.deltaTime) +
                                   impact * Time.deltaTime);

            SetGravity();
        }

        protected void SetGravity()
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
        public virtual void Activate()
        {
            Activated = true;
        }
    }
}
