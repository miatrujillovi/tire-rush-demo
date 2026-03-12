using UnityEngine;

public class CollidingWithObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.gameOver = true;
            //Debug.Log("Player collided with: " + gameObject.name + " and lost.");
        }
    }
}
