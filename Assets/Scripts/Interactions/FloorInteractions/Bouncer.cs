using Assets.Scripts.Interactions.BallInteractions;
using UnityEngine;

namespace Assets.Scripts.Interactions.FloorInteractions
{
    public class Bouncer : MonoBehaviour
    {
        [SerializeField] private float timeSpendOnAirSeed;
        [SerializeField] private Vector3 reflectVector;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bouncable _bouncable))
            {
                _bouncable.GetBounce(reflectVector,
                    (timeSpendOnAirSeed*UnityEngine.Random.Range(0.85f,1.25f)));
                Debug.Log("BOUNCER : OnTrigger");
            }
        }
    }
}
