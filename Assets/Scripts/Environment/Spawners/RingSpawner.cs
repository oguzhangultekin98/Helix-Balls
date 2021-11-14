using Assets.Scripts.Behaviours;
using Assets.Scripts.Interactions.HoopInteractions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Environment.Spawners
{
    public class RingSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] ringPrefabs;
        [SerializeField] private Transform ringHolderParent;
        [SerializeField] private Vector3 additionalHeigh;

        private StagePassBehaviour _stagePassBehaviour;
        private int lastPrefabIndex;

        private int _ringCount;
        private bool onStagePass;


        private void Awake()
        {
            _stagePassBehaviour = FindObjectOfType<StagePassBehaviour>();
        }

        public void SpawnRing()
        {
            _ringCount = ringHolderParent.childCount;
            if (_ringCount > 1 || onStagePass || _stagePassBehaviour.isReachedToEnd)
                return;



            var awayFromPole = new Vector3(Random.Range(-1, 1f), 0f, Random.Range(-1, 1f)).normalized;
            awayFromPole *= 1.4f;


            var pos = _stagePassBehaviour.GetCurrentPlatformLoc() + additionalHeigh + awayFromPole;
            var prefab = ringPrefabs[lastPrefabIndex++ % ringPrefabs.Length];

            var spawnedRing = Instantiate(prefab, pos, prefab.transform.rotation, ringHolderParent);
        }
        public void StagePass()
        {
            onStagePass = true;
            var vanish = ringHolderParent.GetComponentsInChildren<Vanishable>();
            for (int i = 0; i < vanish.Length; i++)
            {
                vanish[i].GetVanish();
            }
            StartCoroutine(FixPassStatus());
        }

        IEnumerator FixPassStatus()
        {
            yield return new WaitForSeconds(1f);
            onStagePass = false;
            SpawnRing();
        }

    }
}