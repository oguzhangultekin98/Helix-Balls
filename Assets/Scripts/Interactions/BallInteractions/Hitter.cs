using UnityEngine;

namespace Assets.Scripts.Interactions.BallInteractions
{
    public class Hitter:MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Hittable _hittable))
            {
                Vector3 normalizedCollisionVector = (other.transform.position - transform.position).normalized;
                _hittable.GetHit(normalizedCollisionVector);
            }
        }
    }
}
