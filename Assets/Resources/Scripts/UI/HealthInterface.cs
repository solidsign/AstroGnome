using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HealthInterface : MonoBehaviour
{
    [SerializeField] private HealthHandler player;
    [Range(0f, 1f)] [SerializeField] private float maxVignetteIntensity;
    [Range(0f, 1f)] [SerializeField] private float maxChromaticAberationIntensity;
    [SerializeField] private float maxHP;
    [SerializeField] private AnimationCurve intensityCurve;
    [SerializeField] private float intensityChangeSpeed;
    private Volume volume;
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;
    private AudioSource audioSource;
    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float intensity = intensityCurve.Evaluate(player.HP / maxHP);
        chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, maxChromaticAberationIntensity * intensity, intensityChangeSpeed * Time.deltaTime) ;
        vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, maxVignetteIntensity * intensity, intensityChangeSpeed * Time.deltaTime);
        audioSource.volume = intensity == 1f ? 0f : intensity;
    }
}
