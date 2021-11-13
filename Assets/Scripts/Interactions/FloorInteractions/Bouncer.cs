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
            RegularBounce,
            HoopBounce
        }


        private void OnTriggerEnter(Collider other)
        {
           
            if (other.TryGetComponent(out Bouncable _bouncable))
            {
                var reflectVector = Vector3.down;
                var randomnessOnBounce = UnityEngine.Random.Range(0.5f, 1f);
                var colDir = (transform.position - other.transform.position);

                if (reflectType != ReflectType.RegularBounce)
                    colDir.y = 0;


                if (reflectType == ReflectType.InsideBounce)
                {
                    reflectVector -= colDir.normalized;
                }
                else if (reflectType == ReflectType.HoopBounce)
                {
                    if (colDir.y>0.1f) //Over hoop
                    {
                        reflectVector -= colDir.normalized;
                        Debug.Log("OVER HOOP INTERACTOR");
                    }
                    else if (colDir.y<0.1f)//Under hoop
                    {
                        randomnessOnBounce = 0f;
                    }
                }

                _bouncable.GetBounce(reflectVector,
                    (timeSpendOnAirSeed)*randomnessOnBounce);
            }
        }
    }
}
