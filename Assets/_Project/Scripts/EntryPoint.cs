using UnityEngine;

namespace _Project.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScoreConfig _scoreConfig;
        [SerializeField] private SceneReferences _sceneReferences;
        [SerializeField] private GamePanel _gamePanel;
        [SerializeField] private GameOverController _gameOverController;
        private DiceController _diceController;
        private DiceFactory _diceFactory;
        
        private void Start()
        {
            Round round = new();
            Score score = new(_scoreConfig);
            GamePanelController gamePanelController = new(_gamePanel);
            _diceFactory = new DiceFactory(_sceneReferences);
            _gameOverController.Construct(_diceFactory, score);
            _gamePanel.Construct(score, gamePanelController);
            _diceController = new(_diceFactory, new DiceCombinations(score), gamePanelController, round);
            _diceController.Initialize();
        }

        private void Update()
        {
            _diceController.Update();
        }
    }
}