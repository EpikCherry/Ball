using System;
using InvokeSystem;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObjectAutoDestroy : MonoBehaviour, IInvoke
{
    [SerializeField] private CameraGameBound cameraGameBound;
    [SerializeField] private float fixedYSize = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball == null) return;
        
        ball.DeSpawn();
    }

    public void SetUp()
    {
        BoxCollider2D triggerBox = GetComponent<BoxCollider2D>();

        float sizeX = Vector3.Distance(
            cameraGameBound.WorldBottomLeft, 
            cameraGameBound.WorldBottomRight);

        triggerBox.size = new(sizeX, fixedYSize);
    }
}