using Zenject;

public class CreaterPathMakeup : IItemVisiter
{
    private readonly CreaterWayAnimationBlush _createrWayAnimationBlush;
    private readonly CreaterWayAnimationLipstick _createrWayAnimationLipstick;
    private readonly CreaterWayAnimationCream _createrWayAnimationCream;

    private TypeWay _typeWay;
    private MoveStep[] _way;
    private CharacterView _characterView;

    [Inject]
    public CreaterPathMakeup(CreaterWayAnimationBlush createrWayAnimationBlush,
        CreaterWayAnimationLipstick createrWayAnimationLipstick,
        CreaterWayAnimationCream createrWayAnimationCream)
    {
        _createrWayAnimationBlush = createrWayAnimationBlush;
        _createrWayAnimationLipstick = createrWayAnimationLipstick;
        _createrWayAnimationCream = createrWayAnimationCream;
    }

    public MoveStep[] GetWayNotCharacterView(Item item)
    {
        _typeWay = TypeWay.NotCharacterView;
        Visit((dynamic)item);
        return _way;
    }

    public MoveStep[] GetWayEatCharacterView(Item item, CharacterView characterView)
    {
        _characterView = characterView;
        _typeWay = TypeWay.EatCharacterView;
        Visit((dynamic)item);
        return _way;
    }

    public void Visit(Blush blush)
    {
        if (_typeWay == TypeWay.EatCharacterView)
            _way = _createrWayAnimationBlush.GenerateMakeupBlushAnimation(blush, _characterView);
        else
            _way = _createrWayAnimationBlush.GenerateReturnBlushAnimaiton(blush);
    }

    public void Visit(Lipstick lipstick)
    {
        if (_typeWay == TypeWay.EatCharacterView)
            _way = _createrWayAnimationLipstick.GenerateMakeupLipstickAnimation(lipstick, _characterView);
        else
            _way = _createrWayAnimationLipstick.GenerateReturnLipstickAnimation(lipstick);
    }

    public void Visit(Cream cream)
    {
        if (_typeWay == TypeWay.EatCharacterView)
            _way = _createrWayAnimationCream.GenerateMakeupCreamAnimation(cream, _characterView);
        else
            _way = _createrWayAnimationCream.GenerateReturnCreamAnimation(cream);
    }

    private enum TypeWay
    {
        NotCharacterView,
        EatCharacterView
    }
}