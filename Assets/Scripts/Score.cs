using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private int _pointsOne = 100;
    [SerializeField] private int _pointsFive = 50;
    [SerializeField] private int _pointsThreeOne = 1000;
    [SerializeField] private int _pointsThreeTwo = 200;
    [SerializeField] private int _pointsThreeThree = 300;
    [SerializeField] private int _pointsThreeFour = 400;
    [SerializeField] private int _pointsThreeFive = 500;
    [SerializeField] private int _pointsThreeSix = 600;
    [SerializeField] private int _pointsStreet = 1500;
    [SerializeField] private int _pointsToWin = 1500;
    
    public int Value { get; private set; }

    public event Action OnUpdated;
    public event Action OnWin;

    public void AddOne(int count)
    {
        AddScore(_pointsOne * count);
    }

    public void AddFive(int count)
    {
        AddScore(_pointsFive * count);
    }

    public void AddStreet()
    {
        AddScore(_pointsStreet);
    }

    public void AddThreeOne()
    {
        AddScore(_pointsThreeOne);
    }

    public void AddAddThreeSix()
    {
        AddScore(_pointsThreeSix);
    }

    public void AddThreeFive()
    {
        AddScore(_pointsThreeFive);
    }

    public void AddThreeFour()
    {
        AddScore(_pointsThreeFour);
    }

    public void AddThreeThree()
    {
        AddScore(_pointsThreeThree);
    }

    public void AddThreeTwo()
    {
        AddScore(_pointsThreeTwo);
    }

    public void Update()
    {
        _scoreUI.Construct(this);
    }

    private void AddScore(int value)
    {
        Value += value;
        OnUpdated?.Invoke();

        if (Value >= _pointsToWin)
        {
            OnWin?.Invoke();
        }
    }
}