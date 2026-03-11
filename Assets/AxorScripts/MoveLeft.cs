using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float disableX = -15f;
    public bool returnToPool = false;

    void Update()
    {
        if (GameManager.instance.gameOver)
            return;

        transform.position += Vector3.left * GameManager.instance.speed * Time.deltaTime;

        if (returnToPool && transform.position.x < disableX)
        {
            gameObject.SetActive(false);
        }
    }
}

