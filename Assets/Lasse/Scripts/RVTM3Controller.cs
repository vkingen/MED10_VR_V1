using UnityEngine;

public class RVTM3Controller : MonoBehaviour
{
    [Header("Pressure (mbar)")]
    public float minPressure = -1000f;   // max vacuum
    public float maxPressure = 0f;       // no vacuum

    [Tooltip("Current output pressure")]
    public float currentPressure;

    float targetPressure;

    [Header("Knob Input")]
    [Range(0f, 1f)]
    public float knobValue = 0f; // from BNG knob (0–1)

    [Tooltip("Curve for realism (1 = linear, >1 = more sensitive at end)")]
    public float responseCurve = 1.5f;

    [Tooltip("How quickly pressure changes")]
    public float smoothingSpeed = 5f;

    [Header("Gauge Needle")]
    public Transform needleTransform;

    [Tooltip("Angle at 0 mbar")]
    public float angleAtZero = -120f;

    [Tooltip("Angle at -1000 mbar")]
    public float angleAtMaxVacuum = 120f;

    float currentNeedleAngle;

    bool turnedOn = false;

    void Start()
    {
        currentPressure = 0f;
        targetPressure = 0f;
        UpdatePressure();
        UpdateNeedle();
    }

    void Update()
    {
        if (!turnedOn) return;
        UpdatePressure();
        UpdateNeedle();
    }

    
    public void SetKnobValue(float value)
    {
        knobValue = Mathf.Clamp01(value);
    }

    public void Debugger(float value)
    {
        Debug.Log(value);
    }

    public void TurnOn()
    {
        turnedOn = true;
        UpdatePressure();
        UpdateNeedle();
    }
    public void TurnOff()
    {
        turnedOn = false;
        UpdatePressure();
        UpdateNeedle();
    }
    
    void UpdatePressure()
    {
        // Non-linear response (more realistic)
        float curved = Mathf.Pow(knobValue, responseCurve);

        // Map: 0 → 0 mbar, 1 → -1000 mbar
        targetPressure = Mathf.Lerp(maxPressure, minPressure, curved);

        // Smooth transition (mechanical feel)
        currentPressure = Mathf.Lerp(
            currentPressure,
            targetPressure,
            Time.deltaTime * smoothingSpeed
        );
    }

    
    void UpdateNeedle()
    {
        if (needleTransform == null) return;

        // Normalize (0 mbar → 0, -1000 → 1)
        float normalized = Mathf.InverseLerp(maxPressure, minPressure, currentPressure);

        float targetAngle = Mathf.Lerp(angleAtZero, angleAtMaxVacuum, normalized);

        // Damped movement (important for realism)
        currentNeedleAngle = Mathf.Lerp(
            currentNeedleAngle,
            targetAngle,
            Time.deltaTime * 8f
        );

        needleTransform.localRotation = Quaternion.Euler(currentNeedleAngle, 0, 0);
    }
}