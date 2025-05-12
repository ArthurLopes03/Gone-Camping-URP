using System;
using UnityEngine;
using UnityEngine.UI;
public class Blackout : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 1f;

    [SerializeField]
    Image blackoutImage;

    bool isFadingIn = false;
    bool isFadingOut = true;

    Action onFadeInComplete;

    float waitDuration = 1f;

    public void StartBlackout(Action action, float waitTime)
    {
        waitDuration = waitTime;

        isFadingIn = true;

        onFadeInComplete = action;

        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Player").GetComponent<ObjectInteraction>().enabled = false;
    }

    void EndBlackout()
    {
        onFadeInComplete = null;
        isFadingOut = false;

        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponent<ObjectInteraction>().enabled = true;
    }

    private void Update()
    {
        if (isFadingIn)
        {
            FadeIn();
        }
        if (isFadingOut)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        blackoutImage.color = new Color(0, 0, 0, Mathf.Clamp(blackoutImage.color.a + fadeSpeed * Time.deltaTime, 0, 1));

        if (blackoutImage.color.a >= 1)
        {
            onFadeInComplete?.Invoke();

            Invoke("StartFadeOut", waitDuration);
        }
    }

    void StartFadeOut()
    {
        isFadingIn = false;
        isFadingOut = true;
    }

    void FadeOut()
    {
        blackoutImage.color = new Color(0, 0, 0, Mathf.Clamp(blackoutImage.color.a - fadeSpeed * Time.deltaTime, 0, 1));
        if (blackoutImage.color.a <= 0)
        {
            EndBlackout();
        }
    }
}
