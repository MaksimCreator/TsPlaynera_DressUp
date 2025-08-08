using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private RectTransform _startPositionDragMove;

    [Header("EntityView")]
    [SerializeField] private BlushView _blushView;
    [SerializeField] private HandView _handView;
    [SerializeField] private LipstickView[] _lipsticks;
    [SerializeField] private CreamView _creamView;

    [Header("RongMakeupPoint")]
    [SerializeField] private RectTransform _pointLeftBlush;
    [SerializeField] private RectTransform _pointRightBlush;
    [SerializeField] private RectTransform _pointFaceBlush;

    [Header("LipsMakeupPoint")]
    [SerializeField] private RectTransform _pointLeftLips;
    [SerializeField] private RectTransform _pointRightLips;

    [Header("AcneMakeupPoint")]
    [SerializeField] private RectTransform _firstPoint;
    [SerializeField] private RectTransform _secondPoint;
    [SerializeField] private RectTransform _thirdPoint;

    [Header("System")]
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;

    [Header("SO")]
    [SerializeField] private MovementConfig _movementConfig;
    [SerializeField] private TakeBlushAnimationConfig _blushAnimationConfig;
    [SerializeField] private BlushMakeupAnimationConfig _blushMakeupAnimationConfig;
    [SerializeField] private LipstickTakeAnimationConfig _lipstickTakeAnimationConfig;
    [SerializeField] private LipstickMakeupAnimationConfig _lipstickMakeupAnimationConfig;
    [SerializeField] private CreamMakeupAnimationConfig _creamMakeupAnimationConfig;
    [SerializeField] private CreamTakeAnimationConfig _creamTakeAnimationConfig;

    [Header("Blush")]
    [SerializeField] private RectTransform _blush;

    [Header("Hand")]
    [SerializeField] private RectTransform _hand;
    [SerializeField] private RectTransform _handDown;

    public override void InstallBindings()
    {
        RegistarySO();
        RegistarySystem();
        RegistaryEntity();
        RegistaryCatalog();
        RegistaryCreater();
        RegistaryMovement();
        RegistaryPresenter();
        RegistaryAnimation();
        RegistaryController();
        RegistaryAnimationPointers();
        RegistaryPresenterControler();
    }

    private void RegistarySystem()
    {
        Container.Bind<InputRouter>()
            .FromNew()
            .AsSingle();

        Container.Bind<RaycastSystem>()
            .FromInstance(new RaycastSystem(_graphicRaycaster, _eventSystem))
            .AsSingle();
    }

    private void RegistaryMovement()
    {
        Container.Bind<HandMovement>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryPresenterControler()
    {
        Container.Bind<BookPresenterControl>()
            .FromNew()
            .AsSingle();

        Container.Bind<GameplayPresenterControl>()
            .FromNew()
            .AsSingle();

        Container.Bind<PresenterControl>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryAnimation()
    {
        Container.Bind<HandAnimation>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryAnimationPointers()
    {
        Container.Bind<BlushMakeupAnimationPoint>()
            .FromInstance(new BlushMakeupAnimationPoint(_pointFaceBlush.position, _pointLeftBlush.position, _pointRightBlush.position))
            .AsSingle();

        Container.Bind<LipstickMakeupAnimationPoint>()
            .FromInstance(new LipstickMakeupAnimationPoint(_pointLeftLips.position, _pointRightLips.position))
            .AsSingle();

        Container.Bind<CreamMakeupAnimationPoint>()
           .FromInstance(new CreamMakeupAnimationPoint(_firstPoint.position, _secondPoint.position,_thirdPoint.position))
           .AsSingle();
    }

    private void RegistaryEntity()
    {
        Container.Bind<Hand>()
            .FromNew()
            .AsSingle();

        Container.Bind<HandView>()
            .FromInstance(_handView)
            .AsSingle();
    }

    private void RegistarySO()
    {
        Container.Bind<MovementConfig>()
            .FromInstance(_movementConfig)
            .AsSingle();

        Container.Bind<TakeBlushAnimationConfig>()
            .FromInstance(_blushAnimationConfig)
            .AsSingle();

        Container.Bind<BlushMakeupAnimationConfig>()
            .FromInstance(_blushMakeupAnimationConfig)
            .AsSingle();

        Container.Bind<LipstickTakeAnimationConfig>()
            .FromInstance(_lipstickTakeAnimationConfig)
            .AsSingle();

        Container.Bind<LipstickMakeupAnimationConfig>()
            .FromInstance(_lipstickMakeupAnimationConfig)
            .AsSingle();

        Container.Bind<CreamMakeupAnimationConfig>()
            .FromInstance(_creamMakeupAnimationConfig)
            .AsSingle();

        Container.Bind<CreamTakeAnimationConfig>()
            .FromInstance(_creamTakeAnimationConfig)
            .AsSingle();
    }

    private void RegistaryCatalog()
    {
        Container.Bind<StartPositionCatalog>()
            .FromInstance(new StartPositionCatalog(_hand.position,_startPositionDragMove.position))
            .AsSingle();

        ItemViewCatalog itemViewCatalog = new ItemViewCatalog();
        ItemCatalog itemCatalog = new ItemCatalog();

        Blush blush = new Blush(GetTransform(_blushView));
        _blushView.BindItem(blush);

        Cream cream = new Cream(GetTransform(_creamView));
        _creamView.BindItem(cream);

        for (int i = 0; i < _lipsticks.Length; i++)
        {
            Lipstick lipstick = new Lipstick(GetTransform(_lipsticks[i]));
            _lipsticks[i].BindItem(lipstick);
            itemViewCatalog.AddPar(lipstick, _lipsticks[i]);
            itemCatalog.AddPar(_lipsticks[i], lipstick);
        }

        itemViewCatalog.AddPar(blush, _blushView);
        itemCatalog.AddPar(_blushView, blush);
        itemViewCatalog.AddPar(cream, _creamView);
        itemCatalog.AddPar(_creamView, cream);

        Container.Bind<ItemViewCatalog>()
            .FromInstance(itemViewCatalog)
            .AsSingle();

        Container.Bind<ItemCatalog>()
            .FromInstance(itemCatalog)
            .AsSingle();
    }

    private void RegistaryCreater()
    {
        Container.Bind<CreaterWayAnimationBlush>()
            .FromNew()
            .AsSingle();

        Container.Bind<CreaterWayAnimationLipstick>()
            .FromNew()
            .AsSingle();

        Container.Bind<CreaterPathMakeup>()
            .FromNew()
            .AsSingle();

        Container.Bind<CreaterWayAnimationCream>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryPresenter()
    {
        Container.Bind<BookPresenter>()
            .FromNew()
            .AsSingle();

        Container.Bind<GameplayPresenter>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryController()
    {
        Container.Bind<GameplayController>()
            .FromNew()
            .AsSingle();
    }

    private RectTransform GetTransform(ItemView view)
    {
        Type itemViewType = typeof(ItemView);
        FieldInfo transformField = itemViewType.GetField(view.FieldNameTransform, BindingFlags.NonPublic | BindingFlags.Instance);
        return transformField.GetValue(view) as RectTransform;
    }
}