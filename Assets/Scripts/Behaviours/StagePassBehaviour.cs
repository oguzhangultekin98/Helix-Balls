using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Passables.Entities;
using System.Linq;
using Assets.Scripts.Environment.Spawners;
using Assets.Scripts.Actions.Movement;

namespace Assets.Scripts.Behaviours
{
    public class StagePassBehaviour : MonoBehaviour
    {

        List<StageEntrance> _stages;
        private int _currentStageIndex; //NeedToKnow How many balls we have
        private BallSpawner _ballSpawner;
        private RingSpawner _ringSpawner;
        private bool reachedToEnd;
        private SimpleCameraMovement _simpleCameraMovement;

        public bool isReachedToEnd
        {
            get { return reachedToEnd; }
        }

        private void Awake()
        {
            _stages = GameObject.FindObjectsOfType<StageEntrance>()
                .OrderBy(s => -s.transform.position.y).ToList();

            _ballSpawner = FindObjectOfType<BallSpawner>();
            _ringSpawner = FindObjectOfType<RingSpawner>();
            _simpleCameraMovement = FindObjectOfType<SimpleCameraMovement>();
        }
        private void Update()
        {
            if (reachedToEnd)
                return;


            if (_stages[_currentStageIndex].BallCountNeeded < _ballSpawner.GetBallCount)
            {
                _stages[_currentStageIndex].PlatformMovement();
                _ringSpawner.StagePass();
                ++_currentStageIndex;
                if (_currentStageIndex >= _stages.Count) { 
                    reachedToEnd = true;
                    UIManager.instance.Success();
                    _simpleCameraMovement.EndGameCamera();
                }
                else { 
                    _simpleCameraMovement.MoveCamera(_stages[_currentStageIndex].transform.parent.transform.position.y);
                    Debug.Log("Parent Y"+_stages[_currentStageIndex].transform.parent.transform.position.y);    
                    Debug.Log("Chield Y" + _stages[_currentStageIndex].transform.position.y);

                }
            }

        }

        public Vector3 GetCurrentPlatformLoc()
        {
            return _stages[_currentStageIndex].transform.position;
        }
    }
}
