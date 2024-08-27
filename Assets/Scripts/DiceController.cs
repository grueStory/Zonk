using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    [SerializeField] private Button _button;
    private DiceFactory _diceFactory;
    private DiceCombinations _diceCombinations;
    private bool _isStartRound = false;

    public void Construct(DiceFactory diceFactory, DiceCombinations diceCombinations)
    {
        _diceFactory = diceFactory;
        _diceCombinations = diceCombinations;
    }

    public void Update()
    {
        HandleStartGame();
    }

    private void HandleStartGame()
    {
        if (_isStartRound)
        {
            Text buttonText = _button.GetComponentInChildren<Text>();
            buttonText.text = "Select";
        }

        else
        {
            Text buttonText = _button.GetComponentInChildren<Text>();
            buttonText.text = "Roll";
        }
    }

    public void HandleDiceActionButton()
    {
        if (!_diceFactory.ActiveDice.Any(dice => dice.IsClicked) && !_isStartRound)
        {
            Text buttonText = _button.GetComponentInChildren<Text>();
            buttonText.text = "Roll";
            _diceFactory.Spawn();
            _isStartRound = true;
        }

        else if (_diceFactory.ActiveDice.Any(dice => dice.IsClicked) && _isStartRound)
        {
            foreach (Dice dice in _diceFactory.ActiveDice)
            {
                if (dice.IsClicked)
                {
                    _diceCombinations.HandleDiceSelected(dice);
                    dice.gameObject.SetActive(false);
                    _diceFactory.DiceCount--;
                }
            }

            _diceCombinations.AddScore();
            _diceCombinations.ClearSelectedDices();
            _diceFactory.Spawn();
        }
    }

    public void HandleSaveRoundButton()
    {
        _isStartRound = false;
        _diceFactory.DestroyActiveDice();
        _diceFactory.DiceCount = 6;
    }
}