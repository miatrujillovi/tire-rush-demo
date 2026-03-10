using UnityEngine;

public class SteppingOnEstepicursor : MonoBehaviour
{
    private GameObject estepicursorObject;
    private void Start()
    {
        estepicursorObject = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Player stepped on the Estepicursor");
            Destroy(estepicursorObject);
        }
    }
}
