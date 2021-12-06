using System;
using UnityEngine;

public class LevelObjectView : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Transform Transform;
    public Collider2D Collider2D;
    public Rigidbody2D Rigidbody2D;

    public Action<LevelObjectView> OnLevelObjectContact { get; set; }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<LevelObjectView>();
        OnLevelObjectContact?.Invoke(levelObject);
    }

}