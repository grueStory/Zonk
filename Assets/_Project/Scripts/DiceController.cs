using System.Linq;

namespace _Project.Scripts
{
    public class DiceController
    {
        private DiceFactory _diceFactory;
        private DiceCombinations _diceCombinations;
        private readonly GamePanelController _gamePanelController;
        private bool _isStartRound = false;

        public DiceController(DiceFactory diceFactory, DiceCombinations diceCombinations, GamePanelController gamePanelController, Round round)
        {
            _diceFactory = diceFactory;
            _diceCombinations = diceCombinations;
            _gamePanelController = gamePanelController;
        }

        public void Initialize()
        {
            _gamePanelController.OnRollPressed += HandleRollButton;
            _gamePanelController.OnSelectPressed += HandleSelectButton;
            _gamePanelController.OnSavePressed += HandleSaveButton;
        }

        public void Update()
        {
            HandleStartGame();
        }

        private void HandleStartGame()
        {
            if (_isStartRound)
            {
                _gamePanelController.EnableSelectButton();
            }
            else
            {
                _gamePanelController.EnableRollButton();
            }
        }

        public void HandleRollButton()
        {
            _diceFactory.Spawn();
            _isStartRound = true;
        }
        
        public void HandleSelectButton()
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
        
        public void HandleSaveButton()
        {
            _isStartRound = false;
            _diceFactory.DestroyActiveDice();
            _diceFactory.DiceCount = 6;
        }

        // public void HandleDiceActionButton()
        // {
        //     if (!_diceFactory.ActiveDice.Any(dice => dice.IsClicked) && !_isStartRound)
        //     {
        //         _diceFactory.Spawn();
        //         _isStartRound = true;
        //     }
        //     else if (_diceFactory.ActiveDice.Any(dice => dice.IsClicked) && _isStartRound)
        //     {
        //         foreach (Dice dice in _diceFactory.ActiveDice)
        //         {
        //             if (dice.IsClicked)
        //             {
        //                 _diceCombinations.HandleDiceSelected(dice);
        //                 dice.gameObject.SetActive(false);
        //                 _diceFactory.DiceCount--;
        //             }
        //         }
        //
        //         _diceCombinations.AddScore();
        //         _diceCombinations.ClearSelectedDices();
        //         _diceFactory.Spawn();
        //     }
        // }
        //
        // public void HandleSaveRoundButton()
        // {
        //     _isStartRound = false;
        //     _diceFactory.DestroyActiveDice();
        //     _diceFactory.DiceCount = 6;
        // }
    }
}