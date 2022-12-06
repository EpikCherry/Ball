using System;
using ObjectPoolSystem;
using UnityEngine;

public class Ball : MonoBehaviour, IPooledObject
{
    public Action OnClick;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb2D;
    
    private void OnMouseDown()
    {
        DeSpawn();
        OnClick?.Invoke();
    }

    public void DeSpawn()
    {
        ObjectPool.instance.DeSpawn(gameObject);
    }
    
    public void SetSpriteColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public void SetSize(float size)
    {
        transform.localScale = new Vector3(size, size, size);
    }

    public void SetFallSpeed(float speed)
    {
        rb2D.drag = speed;
    }

    #region IPooledObject

    public void OnObjectSpawn()
    {
        rb2D.velocity = Vector2.zero;
    }

    #endregion
}