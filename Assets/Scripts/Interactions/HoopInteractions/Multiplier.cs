using UnityEngine;

namespace Assets.Scripts.Interactions.HoopInteractions
{
    public class Multiplier : MonoBehaviour
    {
        [SerializeField] private int multiplier;

        private void OnTriggerEnter(Collider other)
        {
            GetComponent<Vanishable>().GetVanish();
        }
    }
}
