using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public void Construct(Score score)
    {
        _scoreText.text = $"{score.Value}";
    }
}