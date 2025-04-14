using UnityEngine;

public class SlingShotService
{
    private SlingShotController _slingShotController;

    public SlingShotService(SlingShotController slingShotController, SlingshotScriptableObject slingShotSO, Camera mainCamera, Transform centerTransform, Transform idleTransform, SlingShotArea slingShotArea, SlingShotView slingShotView)
    {
        _slingShotController = slingShotController;
        _slingShotController.Initialize(mainCamera, centerTransform, idleTransform, slingShotArea, slingShotSO, slingShotView);
    }
}
