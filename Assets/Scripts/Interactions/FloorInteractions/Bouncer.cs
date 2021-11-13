using Assets.Scripts.Interactions.BallInteractions;
using UnityEngine;

namespace Assets.Scripts.Interactions.FloorInteractions
{
    public class Bouncer : MonoBehaviour
    {
        [SerializeField] private float timeSpendOnAirSeed;
        [SerializeField] private ReflectType reflectType;
        public enum ReflectType
        {
            InsideBounce,
            RegularBounce
        }


        private void OnTriggerEnter(Collider other)
        {
           
            if (other.TryGetComponent(out Bouncable _bouncable))
            {
                var reflectVector = Vector3.down;
                if (reflectType == ReflectType.InsideBounce)
                {
                    var colDir = ( transform.position- other.transform.position).normalized;
                    colDir.y = 0;
                    reflectVector -= colDir;
                }
                /*
                else if (reflectType == ReflectType.Ouside)
                {
                    var colDir = (other.transform.position - transform.position).normalized;
                    colDir.y = 0;
                    reflectVector -= colDir;

                    Debug.Log("CYLINDER");

                }
                */

                _bouncable.GetBounce(reflectVector,
                    (timeSpendOnAirSeed*UnityEngine.Random.Range(0.85f,1.25f)));
            }
        }
    }
}
