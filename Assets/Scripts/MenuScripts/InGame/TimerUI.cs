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

        //StartCoroutine(AnimateSandFill(MainManager.maxTime));
        StartCoroutine(AnimateSandFill(10));
    }

    IEnumerator AnimateSandFill(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            sandTop.style.scale = new Scale(new Vector2(1, 1 - t)); // shrink vertically

            sandBottom.style.scale = new Scale(new Vector2(1, 0 + t)); // grow vertically

            // The commented out code bellow is for later use

            //float streamOpacity = Mathf.PingPong(Time.time * 5f, 1f);
            //sandStream.style.opacity = streamOpacity;

            yield return null;
        }
    }
}
