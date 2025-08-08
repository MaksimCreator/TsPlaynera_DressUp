using UnityEngine;
using Zenject;

public class BookBlushPanel : BookPanel
{
    [SerializeField] private TonComponent[] _blushsTon;
    [SerializeField] private BlushView _blushView;

    private BookPresenter _bookPresenter;

    [Inject]
    private void Construct(BookPresenter animationPresenter)
    {
        _bookPresenter = animationPresenter;
    }

    private new void OnEnable()
    {
        for (int i = 0; i < _blushsTon.Length; i++)
        {
            TonComponent tonComponent = _blushsTon[i];
            _blushsTon[i].Button.onClick.AddListener(() => EnterAnimationBlush(tonComponent));
        }

        base.OnEnable();
    }

    private new void OnDisable()
    {
        for (int i = 0; i < _blushsTon.Length; i++)
            _blushsTon[i].Button.onClick.RemoveAllListeners();

        base.OnDisable();
    }

    private void Update()
    {
        if (_bookPresenter.CanActiveBlushPanel == false && __canActive)
            Hide();
        else if (_bookPresenter.CanActiveBlushPanel && __canActive == false)
            Show();

        if (_bookPresenter.IsActive == false)
        {
            DisableButton();
            for (int i = 0; i < _blushsTon.Length; i++)
                _blushsTon[i].Button.enabled = false;
        }
        else
        {
            EnableButton();
            for (int i = 0; i < _blushsTon.Length; i++)
                _blushsTon[i].Button.enabled = true;
        }
    }

    private void EnterAnimationBlush(TonComponent tonComponent)
    => _bookPresenter.TakeBlush(tonComponent,_blushView);

    protected override void OnClickActiveButton()
    => _bookPresenter.EnterBlushPanel();
}
