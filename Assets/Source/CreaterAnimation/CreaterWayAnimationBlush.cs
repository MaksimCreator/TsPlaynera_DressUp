using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using Zenject;

public class CreaterWayAnimationBlush : CreaterWayAnimation
{
    private readonly BlushMakeupAnimationPoint _blushMakeupPosition;
    private readonly BlushMakeupAnimationConfig _blushMakeupConfig;
    private readonly TakeBlushAnimationConfig _takeBlushConfig;

    [Inject]
    public CreaterWayAnimationBlush(Hand hand,
        ItemCatalog itemCatalog,
        ItemViewCatalog itemViewCatalog,
        PresenterControl presenterControl,
        StartPositionCatalog startPositionCatalog,
        BlushMakeupAnimationPoint blushMakeupAnimationPoint,
        BlushMakeupAnimationConfig blushMakeupAnimationConfig,
        TakeBlushAnimationConfig blushAnimationConfig) : base(hand,
            itemCatalog,
            itemViewCatalog,
            presenterControl,
            startPositionCatalog)
    {
        _takeBlushConfig = blushAnimationConfig;
        _blushMakeupPosition = blushMakeupAnimationPoint;
        _blushMakeupConfig = blushMakeupAnimationConfig;
    }

    public MoveStep[] GenerateTakeBlushAnimation(TonComponent tonComponent, BlushView blushView)
    {
        Blush blush = GetItem(blushView) as Blush;
        blush.SetMakeupComponent(tonComponent);

        List<MoveStep> steps = new();

        steps.Add(new MoveStep(_takeBlushConfig.DurationMoveBlush, blush.StartPosition, async () =>
        {
            blush.SetStatic(false);
            __hand.SetItem(blush);
            await UniTask.Delay(_takeBlushConfig.DelayStep);
        }));

        steps.Add(new MoveStep(_takeBlushConfig.DurationBlushToTon, tonComponent.Position,
            async () => await UniTask.Delay(_takeBlushConfig.DelayStep)));

        for (int i = 0; i < _takeBlushConfig.NumberOfRepetitions; i++)
        {
            steps.Add(new MoveStep(_takeBlushConfig.DurationMoveLeftPositionTon, tonComponent.LeftPosition));
            steps.Add(new MoveStep(_takeBlushConfig.DurationMoveRightPositionTon, tonComponent.RightPosition));
        }

        steps.Add(new MoveStep(_takeBlushConfig.DurationEdgeToCenterTon, tonComponent.Position, async () =>
        {
            blushView.SetTon(tonComponent.ColorBlush);
            await UniTask.Delay(_takeBlushConfig.DelayStep);
        }));

        steps.Add(new MoveStep(_takeBlushConfig.DurationCenterScrean, __startPositionCatalog.StartPositionDragMove));

        return steps.ToArray();
    }

    public MoveStep[] GenerateMakeupBlushAnimation(Blush blush, CharacterView characterView)
    {
        Action onEnd = null;
        List<MoveStep> moveSteps = new List<MoveStep>();

        moveSteps.Add(new MoveStep(_blushMakeupConfig.DurationMoveFace, _blushMakeupPosition.FacePosition,
            async () => await UniTask.Delay(_blushMakeupConfig.DelayStep)));

        for (int i = 0; i < _blushMakeupConfig.NumberOfRepetitions; i++)
        {
            if (CanLastIterationBlush(i))
                onEnd = () => characterView.SetRouge(blush.GetSprite());

            moveSteps.Add(new MoveStep(_blushMakeupConfig.DurationMoveLeftPoint, _blushMakeupPosition.LeftPoint));
            moveSteps.Add(new MoveStep(_blushMakeupConfig.DurationMoveRightPoint, _blushMakeupPosition.RightPoint, onEnd));
        }

        MoveStep[] returnItem = GenerateReturnBlushAnimaiton(blush);

        for (int i = 0; i < returnItem.Length; i++)
            moveSteps.Add(returnItem[i]);

        return moveSteps.ToArray();
    }

    public MoveStep[] GenerateReturnBlushAnimaiton(Blush blush)
    {
        ItemView view = GetItemView(blush);

        BlushView blushView = view as BlushView;
        List<MoveStep> moveSteps = new();

        moveSteps.Add(new MoveStep(_blushMakeupConfig.DurationReturnPositionBlush, blush.StartPosition,
        async () =>
        {
            OnStartPositionItem(blushView, blush);
            blushView.ResetSprite();
            await UniTask.Delay(_blushMakeupConfig.DelayStep);
        }));

        moveSteps.Add(new MoveStep(_blushMakeupConfig.DurationReturnPositionHand,
            __startPositionCatalog.StartPositionHand, () => OnStartPositionHand()));

        return moveSteps.ToArray();
    }

    private bool CanLastIterationBlush(int index)
    => index + 1 == _blushMakeupConfig.NumberOfRepetitions;
}