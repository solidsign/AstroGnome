using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>(5);
    private AudioSource src;
    private const string PATH = "Sound/SFX/";
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    
    public void PlaySound(string soundName)
    {
        src.PlayOneShot(audioClips[soundName]);
    }

    public void AddSound(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>(PATH + soundName);
        if (clip == null) return;

        audioClips.Add(soundName, clip);
    }
}
