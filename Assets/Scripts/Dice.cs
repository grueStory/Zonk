using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] 
    private Color _diceClickedColor = Color.green;
    
    private Color _diceOriginalColor;
    private Renderer _diceRenderer;
    private Score _score;

    public int DiceValue { get; private set; }
    public bool IsClicked = false;
    
    public void SetValue(int value)
    { 
        DiceValue = value;
    }

    private void Start()
    {
        _diceRenderer = GetComponent<Renderer>();
        _diceOriginalColor = _diceRenderer.material.color;
    }

    private void OnMouseDown()
    {
        if (IsClicked)
        {
            _diceRenderer.material.color = _diceOriginalColor;
        }
        
        else
        {
            _diceRenderer.material.color = _diceClickedColor;
        }
        
        IsClicked = !IsClicked;
    }
}