using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public float disableX = -15f;

    void Update()
    {
        if (transform.position.x < disableX)
        {
            gameObject.SetActive(false);
        }
    }
}
