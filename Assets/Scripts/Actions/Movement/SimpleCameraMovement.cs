using Assets.Scripts.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    public class SimpleCameraMovement:MonoBehaviour
    {
        [SerializeField] private TransformInterpolator _transformInterpolater;
        private bool endGame;
        private float currentPlatformLocY;
        private float endGamePlatformLocY;
        private void Start()
        {
            endGamePlatformLocY = FindObjectOfType<EndGamePlatform>().transform.position.y;
            _transformInterpolater.oldVector = transform.position;
        }


        private void Update()
        {
            if (endGame)
            {
                var targetPosY = endGamePlatformLocY+2f;

                transform.position = new Vector3
                    (transform.position.x, Mathf.Lerp(_transformInterpolater.oldVector.y, targetPosY, 0.18f), transform.position.z) ;
            }
            else
            {
                var targetPosY = currentPlatformLocY + 2f;

                transform.position = new Vector3
                    (transform.position.x, Mathf.Lerp(_transformInterpolater.oldVector.y, targetPosY, 0.18f), transform.position.z);

            }
            _transformInterpolater.oldVector = transform.position;


            #region Delete
            if (Input.GetKey(KeyCode.W))
            {
                endGame = true;
            }

            #endregion
        }

        public void MoveCamera(float toYAxis)
        {
            currentPlatformLocY = toYAxis;
        }

        public void EndGameCamera()
        {
            endGame = true;
        }
    }
}
