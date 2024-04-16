using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MidtonesExperiment : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] Vector4 shadow;
    [SerializeField] Vector4 midtone;
    [SerializeField] Vector4 highlight;
    Vector4 test;
    // Start is called before the first frame update
    void Start()
    {
        if (volume.profile.TryGet(out ShadowsMidtonesHighlights smh))
        {
            shadow = smh.shadows.value;
            midtone = smh.midtones.value;
            highlight = smh.highlights.value;
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if(volume.profile.TryGet(out ShadowsMidtonesHighlights smh)){
            smh.shadows.value = shadow;
            smh.midtones.value = midtone;
            smh.highlights.value = highlight;
        }*/
    }
}
