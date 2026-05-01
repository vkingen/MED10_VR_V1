using System;
using UnityEngine;

[Serializable]
public class Step
{
    public string stepName;

    [TextArea]
    public string instruction;

    // What interactions are allowed in this step
    public InteractableObject[] enabledObjects;

    // What interactions are blocked
    public InteractableObject[] disabledObjects;

    // Condition to complete step
    public StepCondition completionCondition;

    // Optional validation (e.g. "must be cleaned")
    public StepCondition validationCondition;

    // Events
    public Action onStepStart;
    public Action onStepComplete;
    public Action onStepFailed;
}