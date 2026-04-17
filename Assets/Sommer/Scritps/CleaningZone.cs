using UnityEngine;
using System.Collections;

public class CleaningZone : MonoBehaviour
{
    [Header("Water Effects")]
    public GameObject waterEffect;
    public AudioSource waterSound;

    private Coroutine stopSoundRoutine;

    private void OnTriggerEnter(Collider other)
    {
        InnerCannula innerCannula = other.GetComponentInParent<InnerCannula>();
        if (innerCannula == null) return;

        // Cancel delayed stop if re-entering
        if (stopSoundRoutine != null)
        {
            StopCoroutine(stopSoundRoutine);
            stopSoundRoutine = null;
        }

        if (waterEffect != null)
            waterEffect.SetActive(true);

        if (waterSound != null && !waterSound.isPlaying)
            waterSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        InnerCannula innerCannula = other.GetComponentInParent<InnerCannula>();
        if (innerCannula == null) return;

        if (waterEffect != null)
            waterEffect.SetActive(false);

        if (stopSoundRoutine != null)
            StopCoroutine(stopSoundRoutine);

        stopSoundRoutine = StartCoroutine(StopSoundAfterDelay(1f));
    }

    private IEnumerator StopSoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (waterSound != null)
            waterSound.Stop();

        stopSoundRoutine = null;
    }

    private void OnTriggerStay(Collider other)
    {
        InnerCannula innerCannula = other.GetComponentInParent<InnerCannula>();
        if (innerCannula == null) return;

        innerCannula.Clean();
    }
}