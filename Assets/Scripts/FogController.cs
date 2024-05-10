using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    [SerializeField] Material cloudMaterial;
    public Transform fogPoint;
    public ParticleSystem overheadFog;
    [SerializeField]
    private float maxDistance = 50.0f;
    [SerializeField]
    private float minFogDensity = 0.0006f;
    [SerializeField]
    private float maxFogDensity = 1f;
    public float activationDistance = 500f;

    void Update()
    {
        if (fogPoint == null) {return;}

        float distance = Vector3.Distance(transform.position, fogPoint.position);
        //Debug.Log("Current Distance: " + distance);

        //Debug.Log(RenderSettings.fogDensity);
        //Debug.Log(distance);
        if (distance <= activationDistance)
        {
            if (!overheadFog.isPlaying)
                overheadFog.Play();
                overheadFog.gameObject.SetActive(true);
        }
        else if (distance > activationDistance)
        {
            if (overheadFog.isPlaying)
                {
                    overheadFog.Stop();
                    overheadFog.gameObject.SetActive(false);
                }
        }
        distance = Mathf.Min(distance, maxDistance);
        if (distance >= 500)
        {
            cloudMaterial.SetFloat("_CloudsAlpha", 0f);

        }
        if(distance>450 && distance < 500)
        {
            cloudMaterial.SetFloat("_CloudsAlpha", Mathf.Lerp(0, 1, (500 - distance) / 50));
        }
        float newFogDensity = Mathf.Lerp(maxFogDensity, minFogDensity, distance / maxDistance);
        RenderSettings.fogDensity = newFogDensity;
    }
}
