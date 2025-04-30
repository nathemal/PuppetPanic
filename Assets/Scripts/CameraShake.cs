using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    CinemachineVirtualCameraBase cam;
    CinemachineBasicMultiChannelPerlin cameraNoise;

    float startShakeAmout;

    bool shaking;
    float _shakeAmount;
    float _shakeTime;
    bool _lerp;
    float timer;

    private void Start()
    {
        cam = CinemachineCore.GetVirtualCamera(0);

        if(cam.GetComponent<CinemachineBasicMultiChannelPerlin>() == null)
        {
            Debug.LogError("Missing CinemachineBasicMultiChannelPerlin in Cinemachine");
        }
        cameraNoise = cam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        startShakeAmout = cameraNoise.AmplitudeGain;
    }

    private void Update()
    {
        if(shaking)
        {
            timer += Time.deltaTime;

            if(_lerp)
            {
                cameraNoise.AmplitudeGain = Mathf.SmoothStep(_shakeAmount, startShakeAmout, timer / _shakeTime);
            }
            else
            {
                cameraNoise.AmplitudeGain = _shakeAmount;
            }

            if(timer >= _shakeTime)
            {
                cameraNoise.AmplitudeGain = startShakeAmout;
                shaking = false;
                timer = 0;
            }
        }
    }

    public void ShakeCamera(float shakeAmount, float shakeTime, bool lerp, bool overrideCurrentShake)
    {
        if(overrideCurrentShake)
        {
            shaking = true;
            _shakeAmount = shakeAmount;
            _shakeTime = shakeTime;
            _lerp = lerp;
            timer = 0;
        }
    }
}
