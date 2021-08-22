using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    protected Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>(5);
    protected AudioSource src;
    protected const string PATH = "Sound/SFX/";
    protected void Start()
    {
        src = GetComponent<AudioSource>();
    }
    
    public void PlaySound(string soundName, float volume)
    {
        if (!audioClips.ContainsKey(soundName))
        {
            Debug.LogWarning(name + "tried to play sound " + soundName + "but it does not exist");
            return;
        }

        src.PlayOneShot(audioClips[soundName], volume);
    }

    public void AddSound(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>(PATH + soundName);
        if (clip == null) return;

        audioClips.Add(soundName, clip);
    }
}
