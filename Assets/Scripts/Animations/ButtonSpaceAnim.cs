using UnityEngine;
using UnityEngine.UI;

public class ButtonSpaceAnim : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float animationSpeed = 0.1f;

    private Image image;
    private int currentFrame;

    private void Start()
    {
        image = GetComponent<Image>();
        InvokeRepeating(nameof(NextFrame), 0f, animationSpeed);
    }

    private void NextFrame()
    {
        currentFrame++;

        if (currentFrame >= sprites.Length)
            currentFrame = 0;

        image.sprite = sprites[currentFrame];
    }
}
