using System;
using UnityEngine;

namespace Assets.Scripts.Interactions.BallInteractions
{
    public class Bouncable : MonoBehaviour
    {
        public event Action<bool> OnBounce;

        private Animator _animator;


        private void Awake()
        {
            //_animator = transform.parent.GetComponentInChildren<Animator>();
        }

        public void GetBounce(Vector3 normalizedCollisionVector)
        {
            //_animator.SetTrigger("HasBounce");
            OnBounce?.Invoke(true);
            Debug.Log("BOUNCER : OnTrigger");
        }
    }
}