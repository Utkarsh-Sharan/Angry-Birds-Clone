using UnityEngine;

public class CameraService
{
    private CameraController _cameraController;

    public CameraService(CameraController cameraController)
    {
        _cameraController = cameraController;
    }

    public void SwitchToIdleCamera() => _cameraController.SwitchToIdleCamera();

    public void SwitchToFollowCamera(Transform playerTransform) => _cameraController.SwitchToFollowCamera(playerTransform);
}
