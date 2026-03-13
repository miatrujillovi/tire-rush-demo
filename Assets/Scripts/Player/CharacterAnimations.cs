using UnityEngine;
using DG.Tweening;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;

    private Tween rotationTween;

    public void StartRotation()
    {
        if (rotationTween != null)
            rotationTween.Kill();
        rotationTween = transform.DORotate(new Vector3(0, 0, -360), rotationSpeed, RotateMode.FastBeyond360).SetRelative(true).
            SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }

    public void StopRotation()
    {
        if (rotationTween != null && rotationTween.IsActive())
        {
            rotationTween.Kill();
        }
    }
}
