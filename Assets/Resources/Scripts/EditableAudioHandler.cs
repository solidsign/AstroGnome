using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditableAudioHandler : AudioHandler
{
    [SerializeField] private List<string> soundNames;
    [SerializeField] private List<AudioClip> sounds;

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < soundNames.Count; i++)
        {
            audioClips.Add(soundNames[i], sounds[i]);
        }
    }
}
