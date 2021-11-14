using System;
using UnityEngine;

namespace Assets.Scripts.Interactions.HoopInteractions
{
    public class Vanishable : MonoBehaviour 
    {
        public void GetVanish()
        {
            Destroy(this.transform.parent.parent.gameObject);
        }
    }
}
