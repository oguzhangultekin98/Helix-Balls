using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Passables.Entities;
using System.Linq;
using Assets.Scripts.Environment.Spawners;

namespace Assets.Scripts.Behaviours
{
    public class StagePassBehaviour : MonoBehaviour
    {

        List<StageEntrance> _stages;
        private int _currentStageIndex; //NeedToKnow How many balls we have
        private BallSpawner _ballSpawner;
        private RingSpawner _ringSpawner;
        private bool reachedToEnd;

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
        }
        private void Update()
        {

            #region DELETE
            if (Input.GetKeyDown(KeyCode.Q))
            {
                UIManager.instance.GameOver();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                UIManager.instance.Success();
            }
            #endregion


            if (reachedToEnd)
                return;


            if (_stages[_currentStageIndex].BallCountNeeded < _ballSpawner.GetBallCount)//Ballswe have2)
            {
                _stages[_currentStageIndex].PlatformMovement();
                _ringSpawner.StagePass();
                ++_currentStageIndex;
                if (_currentStageIndex >= _stages.Count)
                    reachedToEnd = true;
            }


        }

        public Vector3 GetCurrentPlatformLoc()
        {
            return _stages[_currentStageIndex].transform.position;
        }
    }
}
