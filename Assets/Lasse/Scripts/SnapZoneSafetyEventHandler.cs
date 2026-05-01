using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SnapZoneSafetyEventHandler : MonoBehaviour
{
    public UnityEvent delayedSnapZoneOnSnapEvent, delayedSnapZoneOnDetachEvent;
    bool isAfterDelay = false;
    public void Start()
    {
        StartCoroutine(DelayCheck());
    }
    
    public void DelayerOnSnap()
    {
        if(isAfterDelay)
        {
            delayedSnapZoneOnSnapEvent.Invoke();
        }
    }
    public void DelayerOnDetatch()
    {
        if (isAfterDelay)
        {
            delayedSnapZoneOnDetachEvent.Invoke();
        }
    }
    IEnumerator DelayCheck()
    {
        yield return new WaitForSeconds(3f);
        isAfterDelay = true;
    }
}
