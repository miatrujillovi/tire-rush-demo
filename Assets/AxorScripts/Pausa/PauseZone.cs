using UnityEngine;

public class PauseZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Algo entro");

        if (col.CompareTag("Player"))
        {
            Debug.Log("Player entro zona pausa");
            PauseController.instance.inPauseZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Algo entro");

        if (col.CompareTag("Player"))
        {
            Debug.Log("Player entro zona pausa");
            PauseController.instance.inPauseZone = false;
        }
    }
}
