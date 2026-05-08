using BNG;
using System;
using System.Collections.Generic;
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
    List<string> doneIDNames = new List<string>();

    private void Start()
    {
        SetCurrentCondition("Gloves");
    }

    public void SetCurrentCondition(string state)
    {
        
        foreach (StepID step in steps)
        {
            if(state == step.eventName && !doneIDNames.Contains(state))
            {
                doneIDNames.Add(state);
                step.publicEvent.Invoke();
            }
        }
    }
}
