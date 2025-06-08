using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

// This script controls the behaviour of the hourglass in the ui

public class TimerUI : MonoBehaviour
{
    private VisualElement sandTop, sandBottom, sandMiddle;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        sandTop = root.Q<VisualElement>("SandTop");
        sandMiddle = root.Q<VisualElement>("SandMiddle");
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
            float timeDifference = Mathf.Clamp01(elapsed / duration);

            sandTop.style.scale = new Scale(new Vector2(1, 1 - timeDifference)); // shrink vertically

            sandBottom.style.scale = new Scale(new Vector2(1, 0 + timeDifference)); // grow vertically

            float rawT = Mathf.Sin(Time.time * 2f) * 0.5f + 0.5f;  
            float easedT = Mathf.SmoothStep(0f, 1f, rawT);          
            float streamOpacity = Mathf.Lerp(0.5f, 1f, easedT);     
            sandMiddle.style.opacity = streamOpacity;

            yield return null;
        }
    }
}
