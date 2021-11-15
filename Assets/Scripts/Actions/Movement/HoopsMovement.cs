using System;
using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    
    public class HoopsMovement : MovementBase
    {
      private Joystick _joystick;
        private GravityHolder _gravityHolder = new GravityHolder();

        protected Vector3 impact;
        public CharacterController MovementComponent { get; private set; }
        public bool Activated { get; private set; }

        [SerializeField] protected TransformInterpolator transformInterpolater;

        private void Awake()
        {
            _joystick = FindObjectOfType<Joystick>(true);
        }
        private void Start()
        {
            transformInterpolater.oldQuaternion = Quaternion.identity;
        }
        private void Update()
        {
            #region Delete
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(Vector3.up, 0.5f * Time.deltaTime);
            }
            Debug.Log("Hor" + _joystick.Horizontal);

            #endregion

            GetInput();


        }

        private void GetInput()
        {
            var rotData = new Vector3(0, _joystick.Horizontal, 0);
            if (Mathf.Abs(rotData.y)>0.01f)
                Rotate(rotData);
        }

        public void Rotate(Vector3 data)
        {
            var lerp = Mathf.Lerp(transform.rotation.y, data.y, Time.deltaTime * 10f);
            
            Quaternion targetRotation = Quaternion.Lerp(transformInterpolater.oldQuaternion,
                Quaternion.Euler(data*360),
                transformInterpolater.quaternionLerpCoefficient);

            transformInterpolater.oldQuaternion = transform.rotation;
            transform.rotation = targetRotation;
        }



    }
}
