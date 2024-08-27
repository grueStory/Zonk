using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private DiceFactory _diceFactory;
    [SerializeField] private DiceController _diceController;
    [SerializeField] private DiceCombinations _diceCombinations;
    [SerializeField] private ScoreUI _scoreUI;
    
    private void Start()
    {
        _diceController.Construct(_diceFactory, _diceCombinations);
    }
}