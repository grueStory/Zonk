using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public bool Roll => OnButtonClick();
    
    public bool OnButtonClick()
    {
        return true;
    }
}