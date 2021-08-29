using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetSFX(float volume)
    {
        mixer.SetFloat("sfxVolume", volume);
    }
    public void SetMusic(float volume)
    {
        mixer.SetFloat("musicVolume", volume);
    }
    public void SetMaster(float volume)
    {
        mixer.SetFloat("masterVolume", volume);
    }
}
