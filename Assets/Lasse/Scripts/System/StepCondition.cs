using System;

[Serializable]
public class StepCondition
{
    public bool isMet;

    public virtual bool Evaluate()
    {
        return isMet;
    }
}