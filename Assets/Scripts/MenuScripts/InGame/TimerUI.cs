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
    }

    private void Update()
    {
        if (Timer.timerIsRunning)
        {
            UpdateSandAnimation();
        }
    }

    private void UpdateSandAnimation()
    {
        float remainingTime = Mathf.Clamp(MainManager.remainingTime, 0, MainManager.maxTime);
        float progress = 1f - (remainingTime / MainManager.maxTime); 

        sandTop.style.scale = new Scale(new Vector2(1f, 1f - progress));
        sandBottom.style.scale = new Scale(new Vector2(1f, progress));

        float rawT = Mathf.Sin(Time.time * 2f) * 0.5f + 0.5f;
        float easedT = Mathf.SmoothStep(0f, 1f, rawT);
        float streamOpacity = Mathf.Lerp(0.5f, 1f, easedT);
        sandMiddle.style.opacity = streamOpacity;
    }
}
