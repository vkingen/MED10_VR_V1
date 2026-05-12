using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Play()
    {
        audioSource.Play();
    }
}
