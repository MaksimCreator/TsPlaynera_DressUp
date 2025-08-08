using UnityEngine;
using Zenject;

public class BookLipstickPanel : BookPanel
{
    [SerializeField] private MakeupComponent[] _lipsticks;

    private LipstickView[] _lipstickViews;
    private BookPresenter _bookPresenter;

    [Inject]
    private void Construct(BookPresenter bookPresenter)
    => _bookPresenter = bookPresenter;

    private void Awake()
    {
        _lipstickViews = new LipstickView[_lipsticks.Length];

        for (int i = 0; i < _lipsticks.Length; i++)
            _lipstickViews[i] = _lipsticks[i].GetComponent<LipstickView>();
    }

    private new void OnEnable()
    {
        for (int i = 0; i < _lipsticks.Length; i++)
        {
            LipstickView view = _lipstickViews[i];
            MakeupComponent makeupComponent = _lipsticks[i];
            makeupComponent.Button.onClick.AddListener(() => _bookPresenter.TakeLipstick(makeupComponent, view));
        }

        base.OnEnable();
    }

    private new void OnDisable()
    {
        for (int i = 0; i < _lipsticks.Length; i++)
            _lipsticks[i].Button.onClick.RemoveAllListeners();

        base.OnDisable();
    }

    private void Update()
    {
        if (_bookPresenter.CanActiveLipstickPanel == false && __canActive)
            Hide();
        else if (_bookPresenter.CanActiveLipstickPanel && __canActive == false)
            Show();

        if (_bookPresenter.IsActive == false)
        {
            DisableButton();
            for (int i = 0; i < _lipsticks.Length; i++)
                _lipsticks[i].Button.enabled = false;
        }
        else
        {
            EnableButton();
            for (int i = 0; i < _lipsticks.Length; i++)
                _lipsticks[i].Button.enabled = true;
        }
    }

    protected override void OnClickActiveButton()
    => _bookPresenter.EnterLipstickPanel();
}
