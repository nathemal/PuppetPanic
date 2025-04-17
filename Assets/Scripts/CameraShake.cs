using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    CinemachineVirtualCameraBase camera;
    CinemachineBasicMultiChannelPerlin cameraNoise;

    float startShakeAmout;

    bool shaking;
    float _shakeAmount;
    float _shakeTime;
    bool _lerp;
    float timer;

    private void Start()
    {
        camera = CinemachineCore.GetVirtualCamera(0);
        if(camera.GetComponent<CinemachineBasicMultiChannelPerlin>() == null)
        {
            Debug.LogError("You are missing a CineMachineBasicMultiCannelPerlin");
        }
        cameraNoise = camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        startShakeAmout = cameraNoise.AmplitudeGain;
    }

    private void Update()
    {
        if(shaking)
        {
            timer += Time.deltaTime;
            
            if(_lerp)
            {
                cameraNoise.AmplitudeGain = Mathf.SmoothStep(_shakeAmount, startShakeAmout, _shakeTime);
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

    public void ShakeCamera(float shakeAmount, float shakeTime, bool lerp, bool shaking)
    {
            shaking = true;
            _shakeAmount = shakeAmount;
            _shakeTime = shakeTime;
            _lerp = lerp;
            timer = 0;
    
    }
}
