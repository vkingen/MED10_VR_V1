using UnityEngine;
using UnityEngine.Events;

public class StartOfScene : MonoBehaviour
{
    public UnityEvent StartOfSceneEvent;

    private void Start()
    {
        StartOfSceneEvent.Invoke(); 
    }
}
