using System;
using UnityEngine;

namespace Assets.Scripts.Interactions.BallInteractions
{
    public class Hittable:MonoBehaviour
    {
        public event Action<Vector3> OnHit;

        public void GetHit(Vector3 collisionVector)
        {
            OnHit?.Invoke(collisionVector);
        }
    }
}
