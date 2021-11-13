using System;
using UnityEngine;

namespace Assets.Scripts.Interactions.BallInteractions
{
    public class Bouncable : MonoBehaviour
    {
        public event Action<Vector3,float> OnBounce;

        public void GetBounce(Vector3 normalizedCollisionVector,float timeSpendOnAirSetter)
        {
            OnBounce?.Invoke(normalizedCollisionVector,timeSpendOnAirSetter);
        }
    }
}