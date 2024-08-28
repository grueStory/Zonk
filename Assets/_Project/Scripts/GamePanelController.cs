using System;

namespace _Project.Scripts
{
    public class GamePanelController
    {
        private readonly GamePanel _gamePanel;

        public event Action OnRollPressed;
        public event Action OnSelectPressed;
        public event Action OnSavePressed;

        public GamePanelController(GamePanel gamePanel)
        {
            _gamePanel = gamePanel;
        }

        public void EnableSelectButton()
        {
            _gamePanel.EnableSelectButton();
        }

        public void EnableRollButton()
        {
            _gamePanel.EnableRollButton();
        }
        
        public void PressedRollButton()
        {
            OnRollPressed?.Invoke();
        }

        public void PressedSelectButton()
        {
            OnSelectPressed?.Invoke();
        }

        public void PressedSaveButton()
        {
            OnSavePressed?.Invoke();
        }

    }
}