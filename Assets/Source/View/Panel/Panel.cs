using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class BookPanel : MonoBehaviour
{
    [SerializeField] private Image _panel;
    [SerializeField] private Image _activeButton;
    [SerializeField] private Sprite _enable;
    [SerializeField] private Sprite _disable;
    [SerializeField] private Button _activePanel;

    protected bool __canActive => _panel.gameObject.activeSelf;

    public void Show()
    {
        if (_panel.gameObject.activeSelf)
            throw new InvalidOperationException();

        _panel.gameObject.SetActive(true);
        _activeButton.sprite = _enable;
    }

    public void Hide()
    {
        if (_panel.gameObject.activeSelf == false)
            throw new InvalidOperationException();

        _panel.gameObject.SetActive(false);
        _activeButton.sprite = _disable;
    }

    protected void EnableButton()
    => _activePanel.enabled = true;

    protected void DisableButton()
    => _activePanel.enabled = false;

    protected void OnEnable()
    => _activePanel.onClick.AddListener(OnClickActiveButton);

    protected void OnDisable()
    => _activePanel.onClick.RemoveListener(OnClickActiveButton);

    protected abstract void OnClickActiveButton();
}