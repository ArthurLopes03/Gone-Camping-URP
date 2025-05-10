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
    bool isFadingOut = false;

    Action onFadeInComplete;

    public void StartBlackout(Action action)
    {
        isFadingIn = true;

        onFadeInComplete = action;
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
            isFadingIn = false;
            onFadeInComplete?.Invoke();
            isFadingOut = true;
        }
    }

    void FadeOut()
    {
        blackoutImage.color = new Color(0, 0, 0, Mathf.Clamp(blackoutImage.color.a - fadeSpeed * Time.deltaTime, 0, 1));
        if (blackoutImage.color.a <= 0)
        {
            onFadeInComplete = null;
            isFadingOut = false;
        }
    }
}
