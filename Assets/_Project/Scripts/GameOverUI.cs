using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts
{
    public enum GameStatus
    {
        Win,
        Loose,
    }
    
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _winPanel;

        public void GameOver()
        {
            StartCoroutine(Restart(GameStatus.Loose));
        }

        public void Win()
        {
            StartCoroutine(Restart(GameStatus.Win));
        }

        private IEnumerator Restart(GameStatus status)
        {
            if (status == GameStatus.Loose)
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

            else if (status == GameStatus.Win)
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
}