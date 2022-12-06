using InvokeSystem;
using UnityEngine;

[System.Serializable]
public class CameraGameBound : MonoBehaviour, IInvoke
{
    public Vector3 WorldTopLeft { get; private set; }
    public Vector3 WorldTopRight { get; private set; }
    public Vector3 WorldBottomLeft { get; private set; }
    public Vector3 WorldBottomRight { get; private set; }

    [SerializeField] private Camera cam;
    
    [Space]
    [Range(0,0.5f)]
    [SerializeField] private float leftOffset = 0f;
    [Range(0,0.5f)]
    [SerializeField] private float rightOffset = 0f;
    [Range(-1,1)]
    [SerializeField] private float topOffset = 0f;
    [Range(-1,1)]
    [SerializeField] private float bottomOffset = 0f;
    
    [Space]
    [SerializeField] private Color boundColor = Color.yellow;
    
    private Vector3 ViewportTopLeft => new (leftOffset, 1 + topOffset, 0);
    private Vector3 ViewportTopRight => new (1 - rightOffset, 1 + topOffset, 0);
    private Vector3 ViewportBottomLeft => new (leftOffset, bottomOffset, 0);
    private Vector3 ViewportBottomRight => new (1 - rightOffset, bottomOffset, 0);

    public void SetUp()
    {
        WorldTopLeft = cam.ViewportToWorldPoint(ViewportTopLeft);
        WorldTopRight = cam.ViewportToWorldPoint(ViewportTopRight);
        WorldBottomLeft = cam.ViewportToWorldPoint(ViewportBottomLeft);
        WorldBottomRight= cam.ViewportToWorldPoint(ViewportBottomRight);
    }

    #region Gizmos

    private void OnDrawGizmos()
    {
        if(cam == null) return;

        Vector3 topLeft = cam.ViewportToWorldPoint(ViewportTopLeft);
        Vector3 topRight = cam.ViewportToWorldPoint(ViewportTopRight);
        Vector3 bottomLeft = cam.ViewportToWorldPoint(ViewportBottomLeft);
        Vector3 bottomRight= cam.ViewportToWorldPoint(ViewportBottomRight);

        Gizmos.color = boundColor;
        
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }

    #endregion
}