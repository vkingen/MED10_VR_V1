using System.Collections;
using UnityEngine;

public class PauseParticleEffect : MonoBehaviour
{
    public ParticleSystem[] particleSystems;
    public float delay = 1f;

    private void Start()
    {
        PauseAll();
    }

    public void PauseAll()
    {
        StartCoroutine(PauseAfterDelay());
    }

    private IEnumerator PauseAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        foreach (ParticleSystem ps in particleSystems)
        {
            if (ps != null && ps.isPlaying)
            {
                ps.Pause();
            }
        }
    }
}