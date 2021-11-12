using Assets.Scripts.Interactions.BallInteractions;
using UnityEngine;

namespace Assets.Scripts.Interactions.FloorInteractions
{
    public class Bouncer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bouncable _bouncable))
            {
                Vector3 normalizedCollisionVector = (other.transform.position - transform.position).normalized;
                _bouncable.GetBounce(normalizedCollisionVector);
                Debug.Log("BOUNCER : OnTrigger");
            }
        }
    }
}
