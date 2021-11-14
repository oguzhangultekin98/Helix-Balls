using Assets.Scripts.Actions.Movement;
using UnityEngine;

namespace Assets.Scripts.Environment.Spawners
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private Material[] ballMaterials;
        [SerializeField] private GameObject ballPrefab;

        [SerializeField] private Transform ballHolderParent;

        private int lastMaterialIndex;

        public void SpawnBall(Vector3 pos)
        {
            var spawnedBall = Instantiate(ballPrefab,pos,Quaternion.identity, ballHolderParent);

            spawnedBall.GetComponent<MeshRenderer>().material = ballMaterials[++lastMaterialIndex%ballMaterials.Length];
            var ballMovement = spawnedBall.GetComponent<BallMovement>();
            
            Vector3 subDirection = (Random.Range(0,1) < 0.5f) ? Vector3.right : Vector3.left;
            ballMovement.Activate(subDirection);
        }
        public int GetBallCount
        {
            get { return ballHolderParent.childCount; }
        }

        private void Update()
        {
            #region Delete
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("SSSSSSPAWN");
                SpawnBall(Vector3.up);
            }
            #endregion
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }
    }
}
