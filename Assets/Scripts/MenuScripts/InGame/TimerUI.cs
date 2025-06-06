using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

// This script controls the behaviour of the hourglass in the ui

public class TimerUI : MonoBehaviour
{
    private VisualElement sandTop, sandBottom;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        sandTop = root.Q<VisualElement>("SandTop");
        sandBottom = root.Q<VisualElement>("SandBottom");

        //StartCoroutine(AnimateSandFillOld(MainManager.maxTime));
        //StartCoroutine(AnimateSandFillNew(5f));
    }

    IEnumerator AnimateSandFillOld(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            sandTop.style.scale = new Scale(new Vector2(1 - (t * 1.15f), 1 - t)); // shrink vertically

            sandBottom.style.scale = new Scale(new Vector2(1, 0 + t)); // grow vertically

            // The commented out code bellow is for later use

            //float streamOpacity = Mathf.PingPong(Time.time * 5f, 1f);
            //sandStream.style.opacity = streamOpacity;

            yield return null;
        }
    }

    public void TimerUIWorks()
    {
        StartCoroutine(AnimateSandFillOld(MainManager.maxTime));
    }

    IEnumerator AnimateSandFillNew(float duration)
    {
        float elapsed = 0f;
        float maxHeight = 90f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            float smoothT = Mathf.SmoothStep(0, 1, t);

            float topH = Mathf.Lerp(maxHeight, 0, smoothT);
            float bottomH = Mathf.Lerp(0, maxHeight, smoothT);

            sandTop.style.height = topH;
            sandTop.style.scale = new Scale(new Vector2(1 - (t * 1.15f), 1));
            sandBottom.style.height = bottomH;

            Debug.Log((90 - topH) + " / " + bottomH);

            yield return null;
        }
    }
}
