using DG.Tweening;
using System.Threading.Tasks;
using Zenject;

public class HandAnimation : IControl
{
    private readonly HandView _hand;

    private Tween _tween;

    [Inject]
    public HandAnimation(HandView handView)
    {
        _hand = handView;
    }

    public void OnEnable()
    {
        if (_tween == null)
            return;

        _tween.Play();
    }

    public void OnDisable()
    {
        if(_tween == null)
            return;

        _tween.Pause();
    }

    public async Task SetAnimation(MoveStep[] movementPoint)
    {
        for (int i = 0; i < movementPoint.Length; i++)
        {
            _tween = _hand.GetAnimationMove(movementPoint[i]);
            await _tween.AsyncWaitForCompletion();
        }
    }
}