using UnityEngine;

namespace Assets.Scripts.Interactions.HoopInteractions
{
    public class Vanishable : MonoBehaviour //Pool Interface
    {
        public void GetVanish()
        {
            Destroy(this);
        }
    }
}
