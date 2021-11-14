using Assets.Scripts.Behaviours;
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

        


        private void Awake()
        {
            _stagePassBehaviour = FindObjectOfType<StagePassBehaviour>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SpawnRing();
            }
        }

        public void SpawnRing()
        {
            var awayFromPole = new Vector3(Random.Range(-1,1f),0f, Random.Range(-1, 1f)).normalized;
            awayFromPole *= 1.4f;


            var pos = _stagePassBehaviour.GetCurrentPlatformLoc() + additionalHeigh+awayFromPole;
            var prefab = ringPrefabs[lastPrefabIndex++ % ringPrefabs.Length];




            var spawnedBall = Instantiate(prefab, pos, prefab.transform.rotation, ringHolderParent);
            //Platform + yükseklik + merkezden uzaklık
        }


    }
}
