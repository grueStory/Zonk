using System.Collections.Generic;
using UnityEngine;

public class DiceCombinations : MonoBehaviour
{
    private List<Dice> _selectedDices = new List<Dice>();
    [SerializeField] private Score _score;
    
    public void HandleDiceSelected(Dice dice)
    {
        _selectedDices.Add(dice);
    }

    public void ClearSelectedDices()
    {
        _selectedDices.Clear();
    }

    public void AddScore()
    {
        Dictionary<int, int> diceCounts = new Dictionary<int, int>();
        
        foreach (Dice dice in _selectedDices)
        {
            if (diceCounts.ContainsKey(dice.DiceValue))
            {
                diceCounts[dice.DiceValue]++;
            }
            
            else
            {
                diceCounts[dice.DiceValue] = 1;
            }
        }
        
        foreach (var entry in diceCounts)
        {
            int value = entry.Key;
            int count = entry.Value;

            if (count == 3)
            {
                switch (value)
                {
                    case 1:
                        _score.AddThreeOne();
                        break;
                    case 5:
                        _score.AddThreeFive();
                        break;
                    case 2:
                        _score.AddThreeTwo();
                        break;
                    case 3:
                        _score.AddThreeThree();
                        break;
                    case 4:
                        _score.AddThreeFour();
                        break;
                    case 6:
                        _score.AddAddThreeSix();
                        break;
                }
            }

            else
            {
                if (value == 1)
                {
                    _score.AddOne(count);
                }
                
                else if (value == 5)
                {
                    _score.AddFive(count);
                }
            }
        }
        
        if (diceCounts.Count == 6)
        {
            _score.AddStreet();
        }
    }
}