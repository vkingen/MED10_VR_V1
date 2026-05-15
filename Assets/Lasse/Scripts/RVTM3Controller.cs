using System.Collections;
using Unity.VisualScripting;
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
    public float angleAtZero = -230f;

    [Tooltip("Angle at -1000 mbar")]
    public float angleAtMaxVacuum = 47f;

    float currentNeedleAngle;

    bool turnedOn = false;
    bool stopping = false;
    bool firstTurnOn = false;

    [Header("Audio")]
    public AudioSource suctionSource;

    [Tooltip("Pitch at 0 mbar")]
    public float minPitch = 0.8f;

    [Tooltip("Pitch at max vacuum (-1000 mbar)")]
    public float maxPitch = 1.5f;

    [Tooltip("Volume when fully active")]
    public float maxVolume = 1f;

    [Tooltip("Fade speed for audio")]
    public float audioSmoothSpeed = 3f;

    void Start()
    {
        targetPressure = 0f;

        if (suctionSource != null)
        {
            suctionSource.loop = true;
            suctionSource.playOnAwake = false;
            //suctionSource.volume = 0f;
        }
    }

    void Update()
    {
        if (turnedOn)
        {
            UpdatePressure();
        }
        if (stopping)
        {
            //smooth transition
            currentPressure = Mathf.Lerp(
                currentPressure,
                targetPressure,
                Time.deltaTime * smoothingSpeed
            );
        }
        
        UpdateNeedle();
        UpdateAudio(); 
    }

    void UpdateAudio()
    {
        if (suctionSource == null) return;

        // normalize pressure 
        float normalized = Mathf.InverseLerp(maxPressure, minPressure, currentPressure);

        // audio pitch follows pressure (maybe change later?)
        float targetPitch = Mathf.Lerp(minPitch, maxPitch, normalized);
        suctionSource.pitch = Mathf.Lerp(
            suctionSource.pitch,
            targetPitch,
            Time.deltaTime * audioSmoothSpeed
        );

        // Play
        if ((turnedOn || stopping) && !suctionSource.isPlaying)
        {
            suctionSource.Play();
        }

        // Stop
        if (!turnedOn && suctionSource.volume < 0.01f && suctionSource.isPlaying)
        {
            suctionSource.Stop();
        }
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
        stopping = false;
        turnedOn = true;
        
        if (!firstTurnOn)
        {
            firstTurnOn = true;
            targetPressure = -400f;
        }
    }
    public void TurnOff()
    {
        turnedOn = false;
        stopping = true;

        targetPressure = 0;
    }
    void UpdatePressure()
    {
        float curved = Mathf.Pow(knobValue, responseCurve);

        targetPressure = Mathf.Lerp(maxPressure, minPressure, curved);

        // smooth lerping
        currentPressure = Mathf.Lerp(
            currentPressure,
            targetPressure,
            Time.deltaTime * smoothingSpeed
        );
    }
    void UpdateNeedle()
    {
        if (needleTransform == null) return;
        
        float normalized = Mathf.InverseLerp(maxPressure, minPressure, currentPressure);

        float targetAngle = Mathf.Lerp(angleAtZero, angleAtMaxVacuum, normalized);

        currentNeedleAngle = Mathf.Lerp(
            currentNeedleAngle,
            targetAngle,
            Time.deltaTime * 8f
        );

        needleTransform.localRotation = Quaternion.Euler(currentNeedleAngle, 0, 0);
    }
}