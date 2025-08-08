using UnityEngine;
using Zenject;

public class GameplayController :  IControl
{
    private readonly Hand _hand;
    private readonly HandMovement _movement;
    private readonly InputRouter _dragAndDrop;
    private readonly RaycastSystem _raycastSystem;
    private readonly HandAnimation _handAnimation;
    private readonly CreaterPathMakeup _pathCreaterMakeup;

    [Inject]
    public GameplayController(InputRouter dragAndDrop,
        RaycastSystem raycastSystem,
        HandMovement movement,
        HandAnimation handAnimation,
        CreaterPathMakeup pathCreaterMakeup,
        Hand hand)
    {
        _hand = hand;
        _movement = movement;
        _dragAndDrop = dragAndDrop;
        _handAnimation = handAnimation;
        _raycastSystem = raycastSystem;
        _pathCreaterMakeup = pathCreaterMakeup;
    }

    public void OnDisable()
    {
        _dragAndDrop.onMove -= Move;
        _dragAndDrop.onUp -= OnEnd;
    }

    public void OnEnable()
    {
        _dragAndDrop.onMove += Move;
        _dragAndDrop.onUp += OnEnd;
    }

    private void Move(Vector2 endPosition)
    => _movement.SetNewPosition(endPosition);

    private async void OnEnd(Vector2 endPosition)
    {
        _dragAndDrop.SetActive(false);

        Item item = _hand.GetItem();

        if(_movement.IsKill == false)
            await _movement.IsCompletion;

        if (_raycastSystem.TryGetCharacterView(endPosition, out CharacterView characterView) == false)
            _handAnimation.SetAnimation(_pathCreaterMakeup.GetWayNotCharacterView(item));
        else
            _handAnimation.SetAnimation(_pathCreaterMakeup.GetWayEatCharacterView(item, characterView));
    }  
}
