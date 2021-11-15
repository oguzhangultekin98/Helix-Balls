using System;
using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    public class HoopsMovement : MovementBase
    {
        private Joystick _joystick;

        //[SerializeField] protected TransformInterpolator transformInterpolater;

        private void Awake()
        {
            _joystick = FindObjectOfType<Joystick>(true);
        }

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            var rotData = new Vector3(0, _joystick.Horizontal, 0);
            if (rotData.y > 0.01f)
                Rotate(Vector3.down);
            else if (rotData.y < -0.01f)
                Rotate(Vector3.up);
        }

        private void Rotate(Vector3 data)
        {
            /* Shaking problems 
            Quaternion targetRotation = Quaternion.Lerp(transformInterpolater.oldQuaternion,
                Quaternion.Euler(data*speedMultiplier*Time.deltaTime)*transformInterpolater.oldQuaternion,
                transformInterpolater.quaternionLerpCoefficient);
            
            transformInterpolater.oldQuaternion = transform.rotation;
            transform.rotation = targetRotation;
        */
            transform.Rotate(data*Time.deltaTime*speedMultiplier);

        }



    }
}