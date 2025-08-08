using Cysharp.Threading.Tasks;
using Zenject;

public class BookPresenter
{
    private readonly HandAnimation _handAnimation;
    private readonly InputRouter _dragAndDropSystem;
    private readonly CreaterWayAnimationBlush _createrWayBlush;
    private readonly CreaterWayAnimationLipstick _createrWayLipstick;
    private readonly BookPresenterControl _bookPresenterControl;
    private readonly PresenterControl _gameplayPresenterControl;

    public bool IsActive => _bookPresenterControl.IsActive;

    public bool CanActiveLipstickPanel => _bookPresenterControl.CanActiveLipstickPanel;

    public bool CanActiveBlushPanel => _bookPresenterControl.CanActiveBlushPanel;

    [Inject]
    public BookPresenter(HandAnimation handAnimation,
        CreaterWayAnimationBlush createrWayAnimation,
        CreaterWayAnimationLipstick createrWayLipstick,
        InputRouter dragAndDropSystem,
        BookPresenterControl bookPanelControl,
        PresenterControl presenterControl)
    {
        _handAnimation = handAnimation;
        _createrWayBlush = createrWayAnimation;
        _dragAndDropSystem = dragAndDropSystem;
        _bookPresenterControl = bookPanelControl;
        _createrWayLipstick = createrWayLipstick;
        _gameplayPresenterControl = presenterControl;
    }

    public async UniTaskVoid TakeBlush(TonComponent tonComopnent,BlushView blushView)
    {
        _gameplayPresenterControl.DisablePresenters();

        MoveStep[] moveSteps = _createrWayBlush.GenerateTakeBlushAnimation(tonComopnent,blushView);
        blushView.SetTransformToHandParent();
        
        await _handAnimation.SetAnimation(moveSteps);
        _dragAndDropSystem.SetActive(true);
    }

    public async UniTaskVoid TakeLipstick(MakeupComponent makeupComponent,LipstickView lipstickView)
    {
        _gameplayPresenterControl.DisablePresenters();

        MoveStep[] moveSteps = _createrWayLipstick.GenerateTakeLipstikAnimation(makeupComponent, lipstickView);
        lipstickView.SetTransformToHandParent();

        await _handAnimation.SetAnimation(moveSteps);
        _dragAndDropSystem.SetActive(true);
    }

    public void EnterLipstickPanel()
    => _bookPresenterControl.EnterLipstickPanel();

    public void EnterBlushPanel()
    => _bookPresenterControl.EnterBlushPanel();
}
