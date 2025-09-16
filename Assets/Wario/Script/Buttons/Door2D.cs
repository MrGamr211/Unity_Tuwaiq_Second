using UnityEngine;

public class Door2D : MonoBehaviour
{
    [Header("Door Settings")]
    public bool startOpen = false;

    private Collider2D col;
    private SpriteRenderer sprite;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();

        SetOpen(startOpen);
    }

    public void SetOpen(bool open)
    {
        if (col != null) col.enabled = !open; // disable collider when open
        if (sprite != null) sprite.color = open ? Color.green : Color.red; // visual feedback
    }
}
