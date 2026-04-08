using UnityEngine;

public class BNG_KnobAdapter : MonoBehaviour
{
    public Transform knobTransform;
    public RVTM3Controller controller;

    [Header("Rotation Settings")]
    public float minAngle = -170f;     // start position
    public float maxAngle = 170f;   // end position

    float startAngle;

    void Start()
    {
        // Store initial rotation as reference
        startAngle = knobTransform.localEulerAngles.y;
    }

    void Update()
    {
        float currentAngle = knobTransform.localEulerAngles.y;

        // Get signed difference from start angle
        float delta = Mathf.DeltaAngle(startAngle, currentAngle);

        // Clamp to your knob range
        float clamped = Mathf.Clamp(delta, minAngle, maxAngle);

        // Normalize to 0–1
        float normalized = Mathf.InverseLerp(minAngle, maxAngle, clamped);

        controller.SetKnobValue(normalized);
    }
}