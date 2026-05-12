using BNG;
using UnityEngine;

public class DebugButtons : MonoBehaviour
{
    public Button[] debugButtons;

    public void ActivateButtons()
    {
        foreach (Button button in debugButtons)
        {
            button.enabled = true;
        }
    }
    public void DeactivateButtons()
    {
        foreach (Button button in debugButtons)
        {
            button.enabled = false;
        }
    }
}
