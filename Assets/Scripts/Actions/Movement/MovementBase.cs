using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected float speedMultiplier;
        [SerializeField] protected float maxSpeed;
        public virtual float SpeedMultiplier
        {
            get => speedMultiplier;
            set => speedMultiplier = value;
        }
    }
}
