using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image panel;

    public void OnFade(float fadeTime, Color _color)
    {
        StartCoroutine( CoroutineFade(fadeTime, _color) );
    }

    IEnumerator CoroutineFade(float fadeTime, Color _color)
    {
        float timer = 0f;
        float percent = 0f;

        panel.gameObject.SetActive(true);

        while (percent <= 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;

            panel.color = new Color(_color.r, _color.g, _color.b, percent);
            yield return null;
        }

        panel.color = new Color(_color.r, _color.g, _color.b, 1f);
    }
}
