using UnityEngine;

public class IconTrigger : MonoBehaviour
{
    [SerializeField] private string iconType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             IconsLogic.instance.ShowIcon(iconType);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IconsLogic.instance.HideIcon();
        }
    }
}
