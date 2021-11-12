using UnityEngine;

namespace Assets.Scripts.Actions.Movement
{
    [System.Serializable]
    public class TransformInterpolator
    {
        [Range(0f, 1f)] public float vectorLerpCoefficient;
        [HideInInspector] public Vector3 oldVector;

        [Range(0f, 1f)] public float quaternionLerpCoefficient;
        [HideInInspector] public Quaternion oldQuaternion;
    }
}