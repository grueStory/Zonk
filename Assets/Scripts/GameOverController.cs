using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] 
    private DiceFactory _diceFactory;
    [SerializeField] 
    private Score _score;
    [SerializeField] 
    private GameOverUI _gameOverUI;

    private void Start()
    {
        _diceFactory.OnGameOver += OnGameOver;
        _score.OnWin += OnWin;
    }

    private void OnGameOver()
    {
        Debug.Log("Game Over");
        _gameOverUI.GameOver();
    }

    private void OnWin()
    {
        Debug.Log("Win");
        _gameOverUI.Win();
    }
}