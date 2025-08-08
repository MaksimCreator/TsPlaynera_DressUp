using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayPanel : MonoBehaviour
{
    [SerializeField] private Button _creamButton;
    [SerializeField] private Button _sponge;
    [SerializeField] private CreamView _creamView;
    [SerializeField] private CharacterView _characterView;

    private bool _isEnableButton;
    private GameplayPresenter _presenter;

    [Inject]
    private void Construct(GameplayPresenter gameplayPresenter)
    {
        _presenter = gameplayPresenter;
    }

    private void OnEnable()
    {
        _creamButton.onClick.AddListener(() => _presenter.TakeCream(_creamView));
        _sponge.onClick.AddListener(() => _presenter.ResetMakeup(_characterView));
    }

    private void OnDisable()
    {
        _creamButton.onClick.RemoveListener(() => _presenter.TakeCream(_creamView));
        _sponge.onClick.RemoveListener(() => _presenter.ResetMakeup(_characterView));
    }

    private void Update()
    {
        if (_presenter.IsActive == false && _isEnableButton)
        {
            _sponge.enabled = false;
            _creamButton.enabled = false;
            _isEnableButton = false;
        }
        else if (_presenter.IsActive && _isEnableButton == false)
        {
            _sponge.enabled = true;
            _creamButton.enabled = true;
            _isEnableButton = true;
        }
    }
}