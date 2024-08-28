using UnityEngine;

namespace _Project.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScoreConfig _scoreConfig;
        [SerializeField] private SceneReferences _sceneReferences;
        [SerializeField] private GamePanel _gamePanel;
        private DiceController _diceController;
        private DiceFactory _diceFactory;
        [SerializeField] private GameOverController _gameOverController;

        private void Start()
        {
            _diceFactory = new DiceFactory(_sceneReferences);
            Round round = new();
            Score score = new(_scoreConfig);
            _gameOverController.Construct(_diceFactory, score);
            GamePanelController gamePanelController = new(_gamePanel);
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