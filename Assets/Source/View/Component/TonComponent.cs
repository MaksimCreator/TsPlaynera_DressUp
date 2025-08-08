using UnityEngine;

public class TonComponent : MakeupComponent
{
    [SerializeField] private Sprite _colorBlush;
    [SerializeField] private RectTransform _leftPosition;
    [SerializeField] private RectTransform _rightPosition;

    private RectTransform _ton;

    public Vector3 Position => _ton.position;

    public Vector3 LeftPosition => _leftPosition.position;

    public Vector3 RightPosition => _rightPosition.position;

    public Sprite ColorBlush => _colorBlush;

    private void OnValidate()
    {
        _ton = GetComponent<RectTransform>();
    }
}
