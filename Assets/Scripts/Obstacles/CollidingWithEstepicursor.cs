using UnityEngine;

public class CollidingWithEstepicursor : MonoBehaviour
{
    [SerializeField] private float slowMultiplier = 0.5f;
    [SerializeField] private float slowDuration = 1.5f;
    [SerializeField] private float scorePenalty = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();

        // If player is falling on top of the obstacle
        if (playerRB.linearVelocity.y < 0)
        {
            gameObject.SetActive(false);
            //Debug.Log("Player stepped on the Estepicursor");
        }
        // If player collides with the obstacle
        else
        {
            AudioManager.Instance.PlaySpecialCollision();
            GameManager.instance.SlowSpeed(slowMultiplier, slowDuration);
            GameManager.instance.ReduceScore(scorePenalty);
            gameObject.SetActive(false);
            //Debug.Log("Player slowed!");
        }
    }
}
