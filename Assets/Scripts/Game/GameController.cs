using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        public float gameTime = 1f;
        public PenguinSpawner penguinSpawner;
        
        private int _money = 0;
        private bool _gameRunning = true;

        void Start()
        {
            _gameRunning = true;
            penguinSpawner.enabled = true;
        }

        void Update()
        {
            if (!_gameRunning) return;
            if (Time.time > gameTime)
            {
                _gameRunning = false;
                penguinSpawner.enabled = false;
            }
        }

        public void IncreaseMoney(int amount)
        {
            _money += amount;
        }
    }
}