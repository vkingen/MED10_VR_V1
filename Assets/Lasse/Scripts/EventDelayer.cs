using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EventDelayer : MonoBehaviour
{
    public float delayTime = 0f;
    public UnityEvent newEvent;

    public void StartTheEngine()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        StartEvent();

    }
    private void StartEvent()
    {
        newEvent.Invoke();
    }
}
