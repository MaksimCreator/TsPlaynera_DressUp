using DG.Tweening;
using UnityEngine;

public class HandView : MonoBehaviour
{
    [SerializeField] private RectTransform _handDown;
    [SerializeField] private RectTransform _transform;

    public Vector3 Position => _transform.position;

    public void SetParentToHandDown(RectTransform transform)
    => transform.SetParent(_handDown);

    public Tween GetAnimationMove(MoveStep moveStep)
    {
        return _transform.DOMove(moveStep.EndPosition, moveStep.Duration)
            .SetEase(moveStep.TypeAnimation)
            .OnComplete(() => moveStep.OnEnd?.Invoke());
    }
}
