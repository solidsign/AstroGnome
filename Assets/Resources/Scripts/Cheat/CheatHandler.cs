using System.Collections.Generic;
using UnityEngine;

public class CheatHandler : MonoBehaviour
{
    [SerializeField] private List<Cheat> cheats;
    private int[] submitProgress;

    private void Start()
    {
        submitProgress = new int[cheats.Count];
    }

    private void Update()
    {
        if (!Input.anyKeyDown)
        {
            return;
        }

        for (int i = 0; i < cheats.Count; i++)
        {
            if(Input.GetKeyDown(cheats[i].Keys[submitProgress[i]]))
            {
                ++submitProgress[i];
                if(submitProgress[i] >= cheats[i].Keys.Count)
                {
                    submitProgress[i] = 0;
                    cheats[i].CheatEvent.Invoke();
                }
            }
            else
            {
                submitProgress[i] = 0;
            }
        }
    }
}
