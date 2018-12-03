using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public delegate void FadeHandler();

    public event FadeHandler OnFadeInEnd;
    public event FadeHandler OnFadeOutEnd;
    public event FadeHandler OnToBlackEnd;
    public event FadeHandler OnToWhiteEnd;

    public void fadein(Image image, float start, float value)
    {
        StartCoroutine(appear(image, start, value));
    }

    public void fadeout(Image image, float start, float value)
    {
        StartCoroutine(disappear(image, start, value));
    }

    public void toBlack(Image image, float start, float value)
    {
        StartCoroutine(black(image, start, value));
    }

    public void toWhite(Image image, float start, float value)
    {
        StartCoroutine(white(image, start, value));
    }

    public void clear()
    {
        OnFadeInEnd = null;
        OnFadeOutEnd = null;
        OnToBlackEnd = null;
        OnToWhiteEnd = null;
    }

    IEnumerator black(Image image, float start, float value)
    {
        yield return new WaitForSeconds(start);
        while (true)
        {
            if (image.color.r <= 0)
                break;

            Color bufferC = image.color;

            bufferC.r -= value;
            bufferC.g -= value;
            bufferC.b -= value;
            image.color = bufferC;

            yield return new WaitForSeconds(0.01f);
        }

        if (OnToBlackEnd != null)
            OnToBlackEnd();
    }

    IEnumerator white(Image image, float start, float value)
    {
        yield return new WaitForSeconds(start);
        while (true)
        {
            if (image.color.r >= 1)
                break;

            Color bufferC = image.color;

            bufferC.r += value;
            bufferC.g += value;
            bufferC.b += value;
            image.color = bufferC;
            yield return new WaitForSeconds(0.01f);
        }

        if (OnToWhiteEnd != null)
            OnToWhiteEnd();
    }

    IEnumerator appear(Image image, float start, float value)
    {
        yield return new WaitForSeconds(start);
        while (true)
        {
            if (image.color.a > 1)
                break;

            Color bufferC = image.color;
            bufferC.a += value;
            image.color = bufferC;
            yield return new WaitForSeconds(0.01f);
        }

        if (OnFadeInEnd != null)
            OnFadeInEnd();
    }

    IEnumerator disappear(Image image, float start, float value)
    {
        yield return new WaitForSeconds(start);
        while (true)
        {
            if (image.color.a < 0)
                break;

            Color bufferC = image.color;
            bufferC.a -= value;
            image.color = bufferC;
            yield return new WaitForSeconds(0.01f);
        }

        if (OnFadeOutEnd != null)
            OnFadeOutEnd();
    }
}