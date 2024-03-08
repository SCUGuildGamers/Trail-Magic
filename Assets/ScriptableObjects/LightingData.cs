using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName ="ScriptableObjects/LightingData", order = 1)]
public class LightingData : ScriptableObject
{
    //skybox data
    public float skyBoxIntensity;
    public Color skyTopColor;
    public Color skyBottomColor;
    public float skyGradExponent;

    //fog settings

    //directional light data

    //other light data? (maybe lights in the cabin)

    //weather (clouds, stars, etc.)

    //terrain data

    //post-processing data
    //bloom
    //vignette
    //shadows midtones highlights
    //color adjustments
    //tonemapping

}
