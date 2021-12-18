using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public GameObject fade;
    public Image fadeImage;

    GameObject tempFade;
    Image tempFadeImage;

    public bool fadeSetActive = false;

    public float waitTime = 0f;

    void Start()
    {
        fade.SetActive(fadeSetActive);
        tempFade = fade;
        tempFadeImage = fadeImage;
    }

    public void FadeReset()
    {
        fade = tempFade;
        fadeImage = tempFadeImage;
    }

    public IEnumerator FadeIn(string type = "",float fadeCountMax = 0.0f)
    {
        fade.SetActive(true);

        if (type == "Game")
        {
            for (int i = 1; i < 4; i++)
                fade.transform.GetChild(i).gameObject.SetActive(false);
        }

        float fadeCount = fadeImage.color.a;
        while (fadeCount > fadeCountMax)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSecondsRealtime(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadeCount);
        }
        fade.SetActive(false);

        if (type == "Game")
            Time.timeScale = 1;
    }

    public IEnumerator FadeOut(string type = "", float fadeCountMax = 1.0f)
    {
        fade.SetActive(true);

        if (type == "Game")
            Time.timeScale = 0;

        float fadeCount = 0;
        while (fadeCount < fadeCountMax)
        {
            fadeCount += 0.02f;
            yield return new WaitForSecondsRealtime(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadeCount);
        }

        if (type == "Game")
        {
            for (int i = 1; i < 4;i++)
                fade.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
