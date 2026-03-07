using UnityEngine;

public class DoubleJumpTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CharacterController>().canDoubleJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CharacterController>().canDoubleJump = false;
        }   
    }
}
