using UnityEngine;

public class IconsLogic : MonoBehaviour
{
    public static IconsLogic instance;

    [SerializeField] private Sprite doubleJumpIcon;
    [SerializeField] private Sprite holdJumpIcon;
    [SerializeField] private SpriteRenderer iconLocation;

    private bool active;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public void ShowIcon(string _iconType)
    {
        active = true;

        if (active)
        {
            iconLocation.gameObject.SetActive(true);

            if (_iconType == "Double Jump")
            {
                iconLocation.sprite = doubleJumpIcon;
            }
            else if (_iconType == "Hold Jump")
            {
                iconLocation.sprite = holdJumpIcon;
            }
        }
        else
        {
            Debug.LogError("Icon already working");
        }
    }

    public void HideIcon()
    {
        active = false;
        iconLocation.gameObject.SetActive(false);
    }
}
