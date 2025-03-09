using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerIdleCamera;
    [SerializeField] private CinemachineVirtualCamera _playerFollowCamera;

    private void Awake()
    {
        SwitchToIdleCamera();
    }

    public void SwitchToIdleCamera()
    {
        _playerIdleCamera.enabled = true;
        _playerFollowCamera.enabled = false;
    }

    public void SwitchToFollowCamera(Transform playerTransform)
    {
        _playerFollowCamera.Follow = playerTransform;

        _playerFollowCamera.enabled = true;
        _playerIdleCamera.enabled = false;
    }
}
