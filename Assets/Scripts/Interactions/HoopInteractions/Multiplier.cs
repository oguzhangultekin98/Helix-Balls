using Assets.Scripts.Environment;
using UnityEngine;

namespace Assets.Scripts.Interactions.HoopInteractions
{
    public class Multiplier : MonoBehaviour
    {
        private BallSpawner _ballSpawner;
        private void Awake()
        {
            _ballSpawner = FindObjectOfType<BallSpawner>();
        }

        [SerializeField] private int multiplier;

        private void OnTriggerEnter(Collider other)
        {
            //GetComponent<Vanishable>().GetVanish();
            _ballSpawner.SpawnBall(other.transform.position - Vector3.one*0.5f);
        }
    }
}
