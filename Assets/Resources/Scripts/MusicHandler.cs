using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    private AudioSource audioSource; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        SetVolume(1f);
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
    }
}
