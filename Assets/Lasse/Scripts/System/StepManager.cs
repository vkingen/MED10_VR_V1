using UnityEngine;

public class StepManager : MonoBehaviour
{
    public Step[] steps;

    private int currentStepIndex = -1;
    private Step currentStep;

    void Start()
    {
        GoToNextStep();
    }

    void Update()
    {
        if (currentStep == null) return;

        // Check completion
        if (currentStep.completionCondition != null &&
            currentStep.completionCondition.Evaluate())
        {
            CompleteStep();
        }
    }

    public void GoToNextStep()
    {
        currentStepIndex++;

        if (currentStepIndex >= steps.Length)
        {
            Debug.Log("All steps completed");
            return;
        }

        currentStep = steps[currentStepIndex];

        SetupStep(currentStep);
    }

    void SetupStep(Step step)
    {
        Debug.Log($"Starting step: {step.stepName}");

        // Disable everything first (optional global reset)
        DisableAllObjects();

        // Enable allowed objects
        foreach (var obj in step.enabledObjects)
            obj.Enable();

        // Disable blocked objects
        foreach (var obj in step.disabledObjects)
            obj.Disable();

        step.onStepStart?.Invoke();
    }

    void CompleteStep()
    {
        Debug.Log($"Step completed: {currentStep.stepName}");

        currentStep.onStepComplete?.Invoke();

        GoToNextStep();
    }

    void DisableAllObjects()
    {
        var all = FindObjectsOfType<InteractableObject>();
        foreach (var obj in all)
            obj.Disable();
    }
}