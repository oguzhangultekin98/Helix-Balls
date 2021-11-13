using Assets.Scripts.Interactions.BallInteractions;
using UnityEngine;

namespace Assets.Scripts.Interactions.FloorInteractions
{
    public class Bouncer : MonoBehaviour
    {
        [SerializeField] private float timeSpendOnAirSeed;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bouncable _bouncable))
            {
                Vector3 normalizedCollisionVector = (other.transform.position - transform.position).normalized;
                
                _bouncable.GetBounce(normalizedCollisionVector,
                    (timeSpendOnAirSeed*UnityEngine.Random.Range(0.85f,1.25f)));
                Debug.Log("BOUNCER : OnTrigger");
            }
        }
    }
}
