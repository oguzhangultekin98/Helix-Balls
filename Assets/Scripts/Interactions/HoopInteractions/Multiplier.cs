using Assets.Scripts.Environment.Spawners;
using UnityEngine;

namespace Assets.Scripts.Interactions.HoopInteractions
{
    public class Multiplier : MonoBehaviour
    {
        private BallSpawner _ballSpawner;
        private RingSpawner _ringSpawner;
        private void Awake()
        {
            _ballSpawner = FindObjectOfType<BallSpawner>();
            _ringSpawner = FindObjectOfType<RingSpawner>();
        }

        [SerializeField] private int multiplier;

        private void OnTriggerEnter(Collider other)
        {
            GetComponent<Vanishable>().GetVanish();
            _ballSpawner.SpawnBall(other.transform.position - Vector3.one*0.5f);
            _ringSpawner.SpawnRing();
        }
    }
}
