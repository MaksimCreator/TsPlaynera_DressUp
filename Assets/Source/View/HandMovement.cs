using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class HandMovement : IControl
{
    private readonly MovementConfig _movementConfig;
    private readonly HandView _handView;

    private Tween _tween;

    public bool IsKill => _tween.IsActive();

    public Task IsCompletion => _tween.AsyncWaitForCompletion();

    [Inject]
    public HandMovement(MovementConfig movementConfig, HandView handView)
    {
        _movementConfig = movementConfig;
        _handView = handView;
    }

    public void SetNewPosition(Vector2 endPosition)
    {
        _tween.Kill();
        _tween = _handView.GetAnimationMove(new MoveStep(_movementConfig.DurationMove, endPosition));
    }

    public void OnDisable()
    {
        if (_tween == null)
            return;

        _tween.Pause();
    }

    public void OnEnable()
    {
        if (_tween == null)
            return;

        _tween.Play();
    }
}
