using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheatHandler : MonoBehaviour
{
    [SerializeField] private List<Cheat> cheatCodes;
    [SerializeField] private List<UnityEvent> cheatEvents;
    [SerializeField] private AudioClip audioClip;
    private int[] submitProgress;
    private AudioSource audioSource;
    private void Start()
    {
        submitProgress = new int[cheatCodes.Count];
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!Input.anyKeyDown)
        {
            return;
        }

        for (int i = 0; i < cheatCodes.Count; i++)
        {
            if(Input.GetKeyDown(cheatCodes[i].Keys[submitProgress[i]]))
            {
                ++submitProgress[i];
                if(submitProgress[i] >= cheatCodes[i].Keys.Count)
                {
                    submitProgress[i] = 0;
                    cheatEvents[i].Invoke();
                    audioSource.PlayOneShot(audioClip);
                }
            }
            else
            {
                submitProgress[i] = 0;
            }
        }
    }
}
