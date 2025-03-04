using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotArea : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _slingShotAreaMask;

    public bool IsWithinSlingShotArea()
    {
        Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Physics2D.OverlapPoint(worldPosition, _slingShotAreaMask))
            return true;
        
        return false;
    }
}
