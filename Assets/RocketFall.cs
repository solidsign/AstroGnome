using System.Collections;
using UnityEngine;

public class RocketFall : MonoBehaviour
{
    [SerializeField] private Animator rocketAnimator;
    [SerializeField] private Transform rocket;
    [SerializeField] private float longFallDistance;
    [SerializeField] private float longFallTime;
    [SerializeField] private float fastFallDistance;
    [SerializeField] private float fastFallTime;

    public void FallAnimation()
    {
        rocketAnimator.SetTrigger("Fall");
    }

    public void FallLong()
    {
        StartCoroutine(Fall(longFallDistance, longFallTime));
    }

    public void FallFast()
    {
        StartCoroutine(Fall(fastFallDistance, fastFallTime));
    }

    private IEnumerator Fall(float distance, float time)
    {
        float timer = 0f;
        float distancePerSec = distance / time;
        while(timer < time)
        {
            rocket.position = rocket.position + distance * Time.deltaTime * Vector3.up;
            yield return null;
        }
    }
}
