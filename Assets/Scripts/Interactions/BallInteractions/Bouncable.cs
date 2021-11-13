using System;
using UnityEngine;

namespace Assets.Scripts.Interactions.BallInteractions
{
    public class Bouncable : MonoBehaviour
    {
        public event Action<Vector3> OnBounce;

        public void GetBounce(Vector3 normalizedCollisionVector)
        {
            OnBounce?.Invoke(normalizedCollisionVector);
        }
    }
}