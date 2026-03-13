using UnityEngine;

public class ManAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float animationSpeed = 0.1f;

    private SpriteRenderer spriteRenderer;
    private int currentFrame;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(NextFrame), 0f, animationSpeed);
    }

    private void NextFrame()
    {
        currentFrame++;

        if (currentFrame >= sprites.Length)
            currentFrame = 0;

        spriteRenderer.sprite = sprites[currentFrame];
    }
}
