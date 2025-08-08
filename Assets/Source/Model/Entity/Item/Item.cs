using UnityEngine;

public abstract class Item
{
    public readonly int IndexParent;
    private readonly Vector3 _startPosition;

    private MakeupComponent _makeupComponent;

    public Vector3 StartPosition => _startPosition;

    public bool IsStatic { get; private set; } = true;

    public Item(RectTransform item)
    {
        IndexParent = item.GetSiblingIndex();
        _startPosition = item.position;
    }

    public void SetStatic(bool value)
    => IsStatic = value;

    public void SetMakeupComponent(MakeupComponent makeupComponet)
    => _makeupComponent = makeupComponet;

    public Sprite GetSprite()
    => _makeupComponent.SpriteMakeup;
}
