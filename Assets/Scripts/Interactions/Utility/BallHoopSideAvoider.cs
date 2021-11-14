using UnityEngine;

namespace Assets.Scripts.Interactions.Utility
{
    public class BallHoopSideAvoider : MonoBehaviour
    {
        [SerializeField] private BoxCollider _ringSideAvoideCollider;
        private void OnTriggerStay(Collider other)
        {
            if (other.transform.position.y > this.transform.position.y)
            {
                Physics.IgnoreCollision(other, _ringSideAvoideCollider);
            }
            else
                Physics.IgnoreCollision(other, _ringSideAvoideCollider, false);

        }
    }

}
