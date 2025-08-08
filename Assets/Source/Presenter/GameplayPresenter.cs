using Cysharp.Threading.Tasks;
using Zenject;

public class GameplayPresenter
{
    private readonly CreaterWayAnimationCream _createrWayAnimationCream;
    private readonly GameplayPresenterControl _gameplayPresenterControl;
    private readonly PresenterControl _presenterControl;
    private readonly HandAnimation _handAnimation;
    private readonly InputRouter _inputRouter;

    public bool IsActive => _gameplayPresenterControl.IsActive;
    
    [Inject]
    public GameplayPresenter(GameplayPresenterControl gameplayPresenterControl,
        PresenterControl presenterControl,
        InputRouter inputRouter,
        HandAnimation handAnimation,
        HandView handView,
        CreaterWayAnimationCream createrWayAnimationCream)
    {
        _presenterControl = presenterControl;
        _gameplayPresenterControl = gameplayPresenterControl;
        _inputRouter = inputRouter;
        _handAnimation = handAnimation;
        _createrWayAnimationCream = createrWayAnimationCream;
    }

    public void ResetMakeup(CharacterView characterView)
    => characterView.Reset();

    public async UniTaskVoid TakeCream(CreamView view)
    {
        _presenterControl.DisablePresenters();

        view.SetTransformToHandParent();
        MoveStep[] way = _createrWayAnimationCream.GenerateTakeCreamAnimation(view);

        await _handAnimation.SetAnimation(way);
        _inputRouter.SetActive(true);
    }
}