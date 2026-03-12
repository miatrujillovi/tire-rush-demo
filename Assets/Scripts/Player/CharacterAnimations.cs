using UnityEngine;
using DG.Tweening;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;

    private Tween rotationTween;

    public void StartRotation()
    {
        rotationTween = transform.DORotate(new Vector3(0, 0, -360), rotationSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }

    public void StopRotation()
    {
        rotationTween.Kill();
    }
}
