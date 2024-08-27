using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceFactory : MonoBehaviour
{
    [SerializeField] 
    private Dice[] _dicePrefabs;
    [SerializeField] 
    private Transform[] _diceSpawnPoints;
    [SerializeField] 
    private ParticleSystem _particles;
    
    private Camera _camera;
    private Score _score;
    private List<int> _usedSpawnIndices = new List<int>();
    
    public int DiceCount = 6;
    public List<Dice> ActiveDice = new List<Dice>();
    
    public event Action OnGameOver;
    
    private void Awake()
    {
        _camera = Camera.main;
    }

    public void Spawn()
    {
        DestroyActiveDice();
        _usedSpawnIndices.Clear();
        
        for (int i = 0; i < DiceCount; i++)
        {
            Transform spawnPoint = GetRandomAvailableSpawnPoint();
            int diceValue = Random.Range(1, 6);
            Dice dice = Instantiate(_dicePrefabs[diceValue - 1], spawnPoint.position, Quaternion.identity);
            Instantiate(_particles, spawnPoint.position, Quaternion.identity);
            ActiveDice.Add(dice);
            dice.SetValue(diceValue);
            
            Debug.Log(dice.DiceValue);
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
            Destroy(dice.gameObject);
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