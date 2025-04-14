using UnityEngine;

public class SlingShotService
{
    private SlingShotController _slingShotController;

    public SlingShotService(SlingShotController slingShotController, SlingshotConfig config)
    {
        _slingShotController = slingShotController;
        _slingShotController.Initialize(config);
    }
}
