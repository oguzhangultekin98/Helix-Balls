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
        private float currentPlatformLocY = 5.55f;
        private float endGamePlatformLocY;
        private Transform _ringHolder;

        private void Start()
        {
            endGamePlatformLocY = FindObjectOfType<EndGamePlatform>().transform.position.y;
            _transformInterpolater.oldVector = transform.position;
            _ringHolder = FindObjectOfType<HoopsMovement>().transform;
        }


        private void Update()
        {
            if (endGame)
            {
                var targetPosY = endGamePlatformLocY-4.5f;

                transform.position = new Vector3
                    (transform.position.x, Mathf.Lerp(_transformInterpolater.oldVector.y, targetPosY, 0.1f), transform.position.z);

                transform.rotation = new Quaternion
                    (transform.rotation.x, Mathf.Lerp(_transformInterpolater.oldQuaternion.y,0f,0.01f), transform.rotation.z, transform.rotation.w);
            }
            else
            {
                var targetPosY = currentPlatformLocY-5.5f;

                transform.position = new Vector3
                    (transform.position.x, Mathf.Lerp(_transformInterpolater.oldVector.y, targetPosY, 0.07f), transform.position.z);


                
                transform.rotation = new Quaternion
                    (transform.rotation.x, Mathf.Lerp(_transformInterpolater.oldQuaternion.y, _ringHolder.rotation.y, 0.1f), transform.rotation.z, transform.rotation.w);
            }
            _transformInterpolater.oldVector = transform.position;
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
