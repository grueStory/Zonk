using UnityEngine;

namespace _Project.Scripts
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private GameOverUI _gameOverUI;
        private DiceFactory _diceFactory;
        private Score _score;

        public void Construct(DiceFactory diceFactory, Score score)
        {
            _diceFactory = diceFactory;
            _score = score;
        }
        
        private void Start()
        {
            _diceFactory.OnGameOver += OnGameOver;
            _score.OnWin += OnWin;
        }

        private void OnGameOver()
        {
            _gameOverUI.GameOver();
        }

        private void OnWin()
        {
            _gameOverUI.Win();
        }
    }
}