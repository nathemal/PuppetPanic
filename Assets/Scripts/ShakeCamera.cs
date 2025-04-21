using UnityEngine;
using Unity.Cinemachine;

public class ShakeCamera : MonoBehaviour
{
    public CinemachineImpulseSource _impulseScore;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _impulseScore.GenerateImpulse();
        }
    }
}
