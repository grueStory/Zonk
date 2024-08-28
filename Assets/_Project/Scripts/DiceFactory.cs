using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Project.Scripts
{
    public class DiceFactory
    {
        public int DiceCount = 6;
        public List<Dice> ActiveDice = new List<Dice>();
        
        private Dice[] _dicePrefabs;
        private Transform[] _diceSpawnPoints;
        private ParticleSystem _particles;
        private Score _score;
        private List<int> _usedSpawnIndices = new List<int>();
        private readonly SceneReferences _sceneReferences;

        public event Action OnGameOver;

        public DiceFactory(SceneReferences sceneReferences)
        {
            _sceneReferences = sceneReferences;
            _dicePrefabs = _sceneReferences._dicePrefabs;
            _diceSpawnPoints = _sceneReferences._diceSpawnPoints;
            _particles = _sceneReferences._particles;
        }
        
        public void Spawn()
        {
            DestroyActiveDice();
            _usedSpawnIndices.Clear();

            for (int i = 0; i < DiceCount; i++)
            {
                Transform spawnPoint = GetRandomAvailableSpawnPoint();
                int diceValue = Random.Range(1, 6);
                Dice dice = Object.Instantiate(_dicePrefabs[diceValue - 1], spawnPoint.position, Quaternion.identity);
                Object.Instantiate(_particles, spawnPoint.position, Quaternion.identity);
                ActiveDice.Add(dice);
                dice.SetValue(diceValue);
            }

            EmptySpawnCheck();
        }

        private Transform GetRandomAvailableSpawnPoint()
        {
            List<int> availableIndices = new List<int>();

            for (int i = 0; i < _diceSpawnPoints.Length; i++)
            {
                if (!_usedSpawnIndices.Contains(i))
                {
                    availableIndices.Add(i);
                }
            }

            int randomIndex = Random.Range(0, availableIndices.Count);
            int spawnIndex = availableIndices[randomIndex];
            _usedSpawnIndices.Add(spawnIndex);

            return _diceSpawnPoints[spawnIndex];
        }

        public void DestroyActiveDice()
        {
            foreach (Dice dice in ActiveDice)
            {
                Object.Destroy(dice.gameObject);
            }

            ActiveDice.Clear();
        }

        private void EmptySpawnCheck()
        {
            if (!ActiveDice.Any(dice => dice.DiceValue == 1 || dice.DiceValue == 5))
            {
                OnGameOver?.Invoke();
                //DestroyActiveDice();
            }
        }
    }
}