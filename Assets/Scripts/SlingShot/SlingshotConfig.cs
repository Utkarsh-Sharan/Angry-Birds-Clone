using UnityEngine;

//Here I am following Parameter-Object Pattern
//Instead of passing dependencies individually, I am binding those depedencies into an object, and then passing that object to the sling shot service
public class SlingshotConfig
{
    public SlingshotScriptableObject slingShotSO;
    public Camera mainCamera;
    public Transform centerTransform;
    public Transform idleTransform;
    public SlingShotArea slingShotArea;
    public SlingShotView slingShotView;
}
