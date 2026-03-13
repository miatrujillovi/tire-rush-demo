using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public void Shake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
    }
}
