using Assets.Scripts.Passables.Entities.Helpers;
using UnityEngine;

namespace Assets.Scripts.Passables.Entities
{
    public class StageEntrance : MonoBehaviour,IPlatformDeformer
    {
        [SerializeField] private int ballsNeeded;
        public int BallCountNeeded
        {
            get { return ballsNeeded; }
        }
        public void PlatformMovement()
        {
            var stage = transform.parent;
            var forceHandlers = stage.GetComponentsInChildren<PlatformForceHandler>();
            for (int i = 0; i < forceHandlers.Length; i++)
            {
                forceHandlers[i].GetScatter();
            }
            Destroy(transform.parent.gameObject);
        }
    }
}
