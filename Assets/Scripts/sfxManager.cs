using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour
{
    [SerializeField]
    private int minWaitTime = 8;
    [SerializeField]
    private int maxWaitTime = 20;
    private float waitTime = 0;
    private int soundCount;
    private List<AudioSource> soundList = new List<AudioSource>();
    private bool canPlay = true;
    void Start()
    {
        foreach (Transform sfx in transform)
        {
            AudioSource audioSource = sfx.GetComponent<AudioSource>();
            if (audioSource != null)
            {soundList.Add(audioSource);}
        }
        soundCount = soundList.Count;
        StartCoroutine(playNewSFX());
    }
IEnumerator playNewSFX()
{
    System.Random rnd = new System.Random();
    while (true)
    {
        waitTime = rnd.Next(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        int soundIndex = rnd.Next(0, soundCount-1);
        AudioSource selectedSFX = soundList[soundIndex];

        canPlay = true;
        foreach (AudioSource audioSource in soundList)
        {
            if (audioSource.isPlaying)
            {canPlay = false; break;}
        }
        if (canPlay)
        {
            selectedSFX.Play();
            Debug.Log("Sound selected: " + selectedSFX.gameObject.name + ". Next sound playing in: " + waitTime);
        }
        else
        {
            Debug.LogWarning("No sounds are available to play.");
        }
    }
}

    void Update()
    {
        //continue;
    }
}
