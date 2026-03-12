using UnityEngine;
using DG.Tweening;

public class MenuAnimation : MonoBehaviour
{
    [Header("References for Objects")]
    [SerializeField] private GameObject[] upObjects; //Logotipo, creditos y Space Button
    [SerializeField] private GameObject[] leftObjects; //Camioneta y Señor
    [Space]
    [SerializeField] private float duration = 1f;
    [SerializeField] private float moveDistance = 5f;

    public void DisappearObjectsFromMain()
    {
        AnimateUpObjects();
        AnimateLeftObjects();
    }

    private void AnimateUpObjects()
    {
        foreach (GameObject obj in upObjects)
        {
            obj.transform.DOLocalMoveY(obj.transform.position.y + moveDistance, duration).SetEase(Ease.OutCubic);
        }
    }

    private void AnimateLeftObjects()
    {
        foreach (GameObject obj in leftObjects)
        {
            obj.transform.DOMoveX(obj.transform.position.x - moveDistance, duration).SetEase(Ease.OutCubic);
        }
    }
}
