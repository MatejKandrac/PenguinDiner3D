using UnityEngine;

namespace Game
{
    public class PenguinSpawner : MonoBehaviour
    {
        private float _nextPenguinSpawn = 0f;

        public GameObject penguinPrefab;
        
        public float penguinSpawnOffset = 7f;
        public float penguinSpawnMaxDelay = 5f;

        void Start()
        {
            GetNextSpawn(0f);
        }

        void Update()
        {
            var curTime = Time.time;

            if (curTime - _nextPenguinSpawn > 0)
            {
                Debug.Log("Spawning Penguin");
                Instantiate(penguinPrefab, transform.position, Quaternion.identity);
                GetNextSpawn(curTime);
            }
        }

        private void GetNextSpawn(float time)
        {
            var randomDelay = Random.Range(0, penguinSpawnMaxDelay);
            _nextPenguinSpawn = time + penguinSpawnOffset + randomDelay;
            Debug.Log($"Next spawn at:  {_nextPenguinSpawn}");
        }
    }
}