using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Image flashImage;
    public float flashHoldDuration = 0.1f; // white flash hold duration
    public float flashFadeDuration = 0.2f; // white flash duration
    public float fadeToBlackDuration = 1.0f; //fade to black duration
    
    // Start is called before the first frame update
    void Start()
    {
        flashImage.gameObject.SetActive(false); // disable the image
        flashImage.color = new Color(1, 1, 1, 0); // set the initial color to transparent white
    }

    public void PlayButtonPressed()
    {
        StartCoroutine(FlashAndLoadScene());
    }

    private IEnumerator FlashAndLoadScene()
    {
        flashImage.gameObject.SetActive(true); //enable the image

        flashImage.color = new Color(1, 1, 1, 1); // flash white instantly
        yield return new WaitForSeconds(flashHoldDuration); // hold the white flash
        
        // //flash white
        // float elapsedFlashTime = 0f;
        // while (elapsedFlashTime < flashDuration)
        // {
        //     elapsedFlashTime += Time.deltaTime;
        //     float alpha = Mathf.Clamp01(elapsedFlashTime / flashDuration);
        //     flashImage.color = new Color(1, 1, 1, alpha);
        //     yield return null;
        // }

        // flashImage.color = new Color(1, 1, 1, 1); //set the color to white

        // gradually fade to transparent
        float elapsedFlashFadeTime = 0f;
        while (elapsedFlashFadeTime < flashFadeDuration)
        {
            elapsedFlashFadeTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedFlashFadeTime / flashFadeDuration);
            flashImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        flashImage.color = new Color(1, 1, 1, 0); //set the color to transparent white

        yield return new WaitForSeconds(0.1f); // short pause before fading to black

        // fade to black
        float elapsedTime = 0f;
        while (elapsedTime < fadeToBlackDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeToBlackDuration);
            flashImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        flashImage.color = new Color(0, 0, 0, 1); //set the color to black

        //load the scene
        SceneManager.LoadScene(1);
    }
}
