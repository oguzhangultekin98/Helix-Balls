using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Passables.Entities
{
    public class PlatformForceHandler : MonoBehaviour
    {
        Rigidbody _rigidbody;
        public void GetScatter()
        {
            transform.parent.parent = null;
            _rigidbody = gameObject.AddComponent<Rigidbody>();

            _rigidbody.isKinematic = false;

            _rigidbody.AddForce(Random.onUnitSphere * Random.Range(4f, 8f), ForceMode.Impulse);
            _rigidbody.AddTorque(Random.insideUnitSphere * Random.Range(1f, 10f));
            StartCoroutine(FixPassStatus());
        }

        IEnumerator FixPassStatus()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }

    }
}
