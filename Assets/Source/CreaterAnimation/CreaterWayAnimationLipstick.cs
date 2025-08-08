using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

public class CreaterWayAnimationLipstick : CreaterWayAnimation
{
    private readonly LipstickTakeAnimationConfig _lipstickTakeAnimationConfig;
    private readonly LipstickMakeupAnimationPoint _lipstickMakeupAnimationPoint;
    private readonly LipstickMakeupAnimationConfig _lipstickMakeupAnimationConfig;

    public CreaterWayAnimationLipstick(Hand hand,
        ItemCatalog itemCatalog, 
        ItemViewCatalog itemViewCatalog,
        PresenterControl presenterControl,
        StartPositionCatalog startingPositionCatalog,
        LipstickTakeAnimationConfig lipstickTakeAnimationConfig,
        LipstickMakeupAnimationPoint lipstickMakeupAnimationPoint,
        LipstickMakeupAnimationConfig lipstickMakeupAnimationConfig) 
        : base(hand, 
            itemCatalog,
            itemViewCatalog,
            presenterControl,
            startingPositionCatalog)
    {
        _lipstickMakeupAnimationConfig = lipstickMakeupAnimationConfig;
        _lipstickMakeupAnimationPoint = lipstickMakeupAnimationPoint;
        _lipstickTakeAnimationConfig = lipstickTakeAnimationConfig;
    }

    public MoveStep[] GenerateTakeLipstikAnimation(MakeupComponent makeupComponent, LipstickView lipstickView)
    {
        Lipstick lipstick = GetItem(lipstickView) as Lipstick;
        lipstick.SetMakeupComponent(makeupComponent);

        List<MoveStep> moveSteps = new();

        moveSteps.Add(new MoveStep(_lipstickTakeAnimationConfig.DurationTakeLipstick,
            lipstickView.Position, async () =>
            {
                lipstick.SetStatic(false);
                __hand.SetItem(lipstick);
                await UniTask.Delay(_lipstickTakeAnimationConfig.DelayStep);
            }));

        moveSteps.Add(new MoveStep(_lipstickTakeAnimationConfig.DurationLipstickMoveCenter,
            __startPositionCatalog.StartPositionDragMove,
            async () => await UniTask.Delay(_lipstickTakeAnimationConfig.DelayStep)));

        return moveSteps.ToArray();
    }

    public MoveStep[] GenerateMakeupLipstickAnimation(Lipstick lipstick, CharacterView characterView)
    {
        Action onEnd = null;
        List<MoveStep> moveSteps = new List<MoveStep>();

        for (int i = 0; i < _lipstickMakeupAnimationConfig.NumberOfRepetitions; i++)
        {
            if (CanLastIterationLipstick(i))
                onEnd = () => characterView.SetLips(lipstick.GetSprite());

            moveSteps.Add(new MoveStep(_lipstickMakeupAnimationConfig.DurationLeftPoint, _lipstickMakeupAnimationPoint.LeftPoint));
            moveSteps.Add(new MoveStep(_lipstickMakeupAnimationConfig.DurationRightPoint, _lipstickMakeupAnimationPoint.RightPoint, onEnd));
        }

        MoveStep[] returnItem = GenerateReturnLipstickAnimation(lipstick);

        for (int i = 0; i < returnItem.Length; i++)
            moveSteps.Add(returnItem[i]);

        return moveSteps.ToArray();
    }

    public MoveStep[] GenerateReturnLipstickAnimation(Lipstick lipstick)
    {
        LipstickView lipstickView = GetItemView(lipstick) as LipstickView;

        List<MoveStep> moveSteps = new();

        moveSteps.Add(new MoveStep(_lipstickMakeupAnimationConfig.DurationReturnItem, lipstick.StartPosition,
        async () =>
        {
            OnStartPositionItem(lipstickView, lipstick);
            await UniTask.Delay(_lipstickMakeupAnimationConfig.DelayStep);
        }));

        moveSteps.Add(new MoveStep(_lipstickMakeupAnimationConfig.DurationReturnHand,
            __startPositionCatalog.StartPositionHand, () => OnStartPositionHand()));

        return moveSteps.ToArray();
    }

    private bool CanLastIterationLipstick(int index)
    => index + 1 == _lipstickMakeupAnimationConfig.NumberOfRepetitions;
}