using UnityEngine;
using UnityEngine.UI;

public class BlushView : ItemView
{
    [SerializeField] private Image _colorTon;

    public void SetTon(Sprite ton)
    { 
        if(_colorTon.gameObject.activeSelf == false)
            _colorTon.gameObject.SetActive(true);

        _colorTon.sprite = ton;
    }

    public void ResetSprite()
    => _colorTon.gameObject.SetActive(false);
}