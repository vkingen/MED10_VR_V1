using UnityEngine;
using TMPro;

public class MonitorDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text spo2Text;

    [Header("Saturation Settings")]
    [SerializeField] private float currentSaturation = 98f;
    [SerializeField] private float normalSaturation = 98f;
    [SerializeField] private float minimumSaturation = 75f;

    [Header("Idle Fluctuation")]
    [SerializeField] private float minFluctuationInterval = 3f;
    [SerializeField] private float maxFluctuationInterval = 4f;

    private float fluctuationTimer;
    private float nextFluctuationTime;
    private float idleTargetSaturation = 98f;

    [Header("Change Speeds")]
    [SerializeField] private float dropSpeedWhileSuctioning = 0.5f;
    [SerializeField] private float recoverySpeed = 1f;

    [Header("Colors")]
    [SerializeField] private Color normalColor = Color.green;
    [SerializeField] private Color yellowColor = Color.yellow;
    [SerializeField] private Color orangeColor = new Color(1f, 0.5f, 0f);
    [SerializeField] private Color redColor = Color.red;

    [Header("State")]
    [SerializeField] private bool isPerformingSuction = false;

    private void Start()
    {
        SetNextFluctuationTime();
        UpdateDisplay();
    }

    private void Update()
    {
        if (isPerformingSuction)
        {
            currentSaturation -= dropSpeedWhileSuctioning * Time.deltaTime;
        }
        else
        {
            HandleIdleFluctuation();
        }

        currentSaturation = Mathf.Clamp(currentSaturation, minimumSaturation, 100f);

        UpdateDisplay();
    }

    private void HandleIdleFluctuation()
    {
        fluctuationTimer += Time.deltaTime;

        if (fluctuationTimer >= nextFluctuationTime)
        {
            fluctuationTimer = 0f;
            SetNextFluctuationTime();

            // Randomly choose 97 or 98
            idleTargetSaturation = Random.Range(0, 2) == 0 ? 97f : 98f;
        }

        // Smoothly move toward the chosen idle value
        currentSaturation = Mathf.MoveTowards(
            currentSaturation,
            idleTargetSaturation,
            recoverySpeed * Time.deltaTime
        );
    }

    private void SetNextFluctuationTime()
    {
        nextFluctuationTime = Random.Range(minFluctuationInterval, maxFluctuationInterval);
    }

    private void UpdateDisplay()
    {
        int displayedValue = Mathf.RoundToInt(currentSaturation);
        spo2Text.text = "SAT " + displayedValue.ToString();

        if (currentSaturation >= 94f)
        {
            spo2Text.color = normalColor;
        }
        else if (currentSaturation >= 92f)
        {
            spo2Text.color = yellowColor;
        }
        else if (currentSaturation >= 90f)
        {
            spo2Text.color = orangeColor;
        }
        else
        {
            spo2Text.color = redColor;
        }
    }

    public void SetSuctionState(bool suctioning)
    {
        isPerformingSuction = suctioning;
    }

    public float GetCurrentSaturation()
    {
        return currentSaturation;
    }
}