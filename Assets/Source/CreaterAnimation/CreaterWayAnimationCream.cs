using Cysharp.Threading.Tasks;
using System.Collections.Generic;

public class CreaterWayAnimationCream : CreaterWayAnimation
{
    private readonly CreamMakeupAnimationConfig _creamMakeupAnimationConfig;
    private readonly CreamTakeAnimationConfig _creamTakeAnimationConfig;
    private readonly CreamMakeupAnimationPoint _creamMakeupAnimationPoint;

    public CreaterWayAnimationCream(Hand hand,
        ItemCatalog itemCatalog,
        ItemViewCatalog itemViewCatalog,
        PresenterControl presenterControl,
        StartPositionCatalog startPositionCatalog,
        CreamMakeupAnimationConfig creamMakeupAnimationConfig,
        CreamTakeAnimationConfig creamTakeAnimationConfig,
        CreamMakeupAnimationPoint creamMakeupAnimationPoint) : base(hand, itemCatalog, itemViewCatalog, presenterControl, startPositionCatalog)
    {
        _creamMakeupAnimationConfig = creamMakeupAnimationConfig;
        _creamMakeupAnimationPoint = creamMakeupAnimationPoint;
        _creamTakeAnimationConfig = creamTakeAnimationConfig;
    }

    public MoveStep[] GenerateTakeCreamAnimation(CreamView view)
    {
        Cream cream = GetItem(view) as Cream;

        List<MoveStep> way = new List<MoveStep>();

        way.Add(new MoveStep(_creamTakeAnimationConfig.DurationMoveHandToCream, view.Position,
        async () =>
        {
            cream.SetStatic(false);
            __hand.SetItem(cream);
            await UniTask.Delay(_creamTakeAnimationConfig.DelayStep);
        }));

        way.Add(new MoveStep(_creamTakeAnimationConfig.DurationMoveHandToCenter, __startPositionCatalog.StartPositionDragMove,
        async () => await UniTask.Delay(_creamTakeAnimationConfig.DelayStep)));

        return way.ToArray();
    }

    public MoveStep[] GenerateMakeupCreamAnimation(Cream cream, CharacterView characterView)
    {
        List<MoveStep> moveSteps = new List<MoveStep>();

        moveSteps.Add(new MoveStep(_creamMakeupAnimationConfig.DurationFirstPoint,_creamMakeupAnimationPoint.FirstPoint));
        moveSteps.Add(new MoveStep(_creamMakeupAnimationConfig.DurationSecondPoint, _creamMakeupAnimationPoint.SecondPoint));
        moveSteps.Add(new MoveStep(_creamMakeupAnimationConfig.DurationThirdPoint, _creamMakeupAnimationPoint.ThirdPoint,
        async () => 
        {
            characterView.DelayAcne();
            await UniTask.Delay(_creamMakeupAnimationConfig.DelayStep);
        }));

        MoveStep[] returnItem = GenerateReturnCreamAnimation(cream);

        for (int i = 0; i < returnItem.Length; i++)
            moveSteps.Add(returnItem[i]);

        return moveSteps.ToArray();
    }

    public MoveStep[] GenerateReturnCreamAnimation(Cream cream)
    {
        CreamView lipstickView = GetItemView(cream) as CreamView;

        List<MoveStep> moveSteps = new();

        moveSteps.Add(new MoveStep(_creamMakeupAnimationConfig.DurationReturnItem, cream.StartPosition,
        async () =>
        {
            OnStartPositionItem(lipstickView, cream);
            await UniTask.Delay(_creamMakeupAnimationConfig.DelayStep);
        }));

        moveSteps.Add(new MoveStep(_creamMakeupAnimationConfig.DurationReturnHand,
            __startPositionCatalog.StartPositionHand, () => OnStartPositionHand()));

        return moveSteps.ToArray();
    }
}