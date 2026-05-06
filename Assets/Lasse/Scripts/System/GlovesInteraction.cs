using UnityEngine;
using UnityEngine.Events;
public class GlovesInteraction : MonoBehaviour
{
    public UnityEvent glovesAreOn;
    public OnTriggerEvents[] triggers;
    int num = 0;


    bool leftGloveOn, rightGloveOn;
    public void LeftGlove()
    {
        if (!leftGloveOn)
        {
            leftGloveOn = true;
            num++;
            GloveCheck();
        }
    }

    public void RightGlove()
    {
        if (!rightGloveOn)
        {
            rightGloveOn = true;
            num++;
            GloveCheck();
        }
    }

    public void GloveCheck()
    {
        if (num == 2)
        {
            glovesAreOn.Invoke();
        }
    }

}