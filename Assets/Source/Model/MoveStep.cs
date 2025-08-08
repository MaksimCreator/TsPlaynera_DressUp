using DG.Tweening;
using System;
using UnityEngine;

public struct MoveStep
{
    public readonly float Duration;
    public readonly Vector3 EndPosition;
    public readonly Ease TypeAnimation;
    public readonly Action OnEnd;

    public MoveStep(float duration, Vector3 endMove, Action onEnd = null,Ease typeAnimation = Ease.Linear)
    {
        Duration = duration;
        EndPosition = endMove;
        OnEnd = onEnd;
        TypeAnimation = typeAnimation;
    }
}