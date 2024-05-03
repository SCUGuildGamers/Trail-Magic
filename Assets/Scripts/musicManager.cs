using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private float timer;
    [SerializeField]
    private float initialTime = 60f;
    [SerializeField]
    private float repeatTime = 240f;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer += initialTime;
    }

    void Update()
    {
        Debug.Log(timer);
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                timer = repeatTime;
            }
        }
    }
}
