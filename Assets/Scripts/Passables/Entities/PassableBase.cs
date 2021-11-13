using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Passables.Entities
{
    public abstract class PassableBase : MonoBehaviour
    {
        protected virtual void Awake()
        {
            StageIndex = transform.parent.transform.GetSiblingIndex() + 1;
        }

        public int StageIndex { get; protected set; }
        [SerializeField] private int ballsNeeded;
        public abstract void OnHitPassable();
        public int BallCountNeeded
        {
            get { return ballsNeeded; }
        }

    }
}
