using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject _gameOverPanel;
    [SerializeField] 
    private GameObject _winPanel;
    
    private int _isGameOver = 1;
    private int _isWin = 2;

    public void GameOver()
    {
        StartCoroutine(Restart(_isGameOver));
    }
    
    public void Win()
    {
        StartCoroutine(Restart(_isWin));
    }

    private IEnumerator Restart(int status)
    {
        if (status == 1)
        {
            yield return new WaitForSeconds(1f);

            _gameOverPanel.SetActive(true);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            yield return null;
        }
        
        else if (status == 2)
        {
            yield return new WaitForSeconds(1f);

            _winPanel.SetActive(true);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            yield return null;
        }
    }
}