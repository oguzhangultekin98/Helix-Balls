using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected float maxSpeed;
        [SerializeField] protected float speedMultiplier;

        public virtual float SpeedMultiplier
        {
            get => speedMultiplier;
            set => speedMultiplier = value;
        }
    }
}
