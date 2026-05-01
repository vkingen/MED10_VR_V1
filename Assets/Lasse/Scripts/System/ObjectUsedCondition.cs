using System;

[Serializable]
public class ObjectUsedCondition : StepCondition
{
    public InteractableObject targetObject;
    public bool wasUsed = false;

    public override bool Evaluate()
    {
        return wasUsed;
    }
}