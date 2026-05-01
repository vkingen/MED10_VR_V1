using BNG;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class StepID
{
    public string eventName;
    public UnityEvent publicEvent;

}

public class GuidingSystem : MonoBehaviour
{

    public StepID[] steps;

    private void Start()
    {
        SetCurrentCondition("Gloves");
    }

    public void SetCurrentCondition(string state)
    {
        foreach (StepID step in steps)
        {
            if(state == step.eventName)
            {
                step.publicEvent.Invoke();
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Debuggeren();
        }
    }
    public void Debuggeren()
    {
        SetCurrentCondition("StomaAdd");
    }
}
