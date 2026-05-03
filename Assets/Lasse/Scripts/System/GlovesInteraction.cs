using UnityEngine;
using UnityEngine.Events;
public class GlovesInteraction : MonoBehaviour
{
    public UnityEvent glovesAreOn;
    public OnTriggerEvents[] triggers;
    
    public void GloveCheck()
    {
        int num = 0;
        foreach (var trigger in triggers)
        {
            if (trigger.hasCollidedWithOther)
            {
                num++;
            }
        }
        if(num == 2)
        {
            glovesAreOn.Invoke();
        }
    }

}