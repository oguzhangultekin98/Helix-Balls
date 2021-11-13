using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Passables.Entities;
using System.Linq;

namespace Assets.Scripts.Behaviours
{
    public class StagePassBehaviour : MonoBehaviour
    {
        
        List<StageEntrance> _stages;
        private int _currentStageIndex; //NeedToKnow How many balls we have
        private void Awake()
        {
            _stages = GameObject.FindObjectsOfType<StageEntrance>()
                .OrderBy(s => -s.transform.position.z).ToList();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Z");
                for (int i = 0; i < _stages.Count; i++)
                {
                    Debug.Log(_stages[i].BallCountNeeded);
                }
            }
        }
    }
}
