using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private Button _rollButton;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Text _scoreText;

        private Score _score;
        private GamePanelController _gamePanelController;

        public void Construct(Score score, GamePanelController gamePanelController)
        {
            _score = score;
            _gamePanelController = gamePanelController;
            score.OnUpdated += UpdateText;
        }

        private void Start()
        {
            _rollButton.onClick.AddListener(PressedRollButton);
            _selectButton.onClick.AddListener(PressedSelectButton);
            _saveButton.onClick.AddListener(PressedSaveButton);
        }

        public void EnableSelectButton()
        {
            _rollButton.gameObject.SetActive(false);
            _selectButton.gameObject.SetActive(true);
        }

        public void EnableRollButton()
        {
            _selectButton.gameObject.SetActive(false);
            _rollButton.gameObject.SetActive(true);
        }

        private void UpdateText()
        {
            _scoreText.text = $"{_score.Value}";
        }

        private void PressedRollButton()
        {
            _gamePanelController.PressedRollButton();
        }
        
        private void PressedSelectButton()
        {
            _gamePanelController.PressedSelectButton();
        }
        
        private void PressedSaveButton()
        {
            _gamePanelController.PressedSaveButton();
        }
    }
}