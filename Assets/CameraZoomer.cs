using System.Collections;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    [SerializeField] private AnimationCurve zoomCurve;
    [SerializeField] private float timeOfZooming;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        StartZooming();
    }

    public void StartZooming()
    {
        StartCoroutine(Zoom());
    }

    private IEnumerator Zoom()
    {
        float timer = 0f;
        while(timer < timeOfZooming)
        {
            cam.orthographicSize = zoomCurve.Evaluate(timer / timeOfZooming);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
