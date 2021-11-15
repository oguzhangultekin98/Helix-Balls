using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    
    public class HoopsMovement : MovementBase
    {
      private Joystick _joystick;

        private void Awake()
        {
            _joystick = FindObjectOfType<Joystick>(true);
        }
        private void Update()
        {
            #region Delete
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(Vector3.up, 0.5f * Time.deltaTime);
            }
            Debug.Log("Hor" + _joystick.Horizontal);

            Debug.Log("Ver" + _joystick.Vertical);

            #endregion
        }
    }
}
