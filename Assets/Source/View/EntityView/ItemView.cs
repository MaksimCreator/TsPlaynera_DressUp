using UnityEngine;

public abstract class ItemView : MonoBehaviour
{
    [SerializeField] private RectTransform _parent;
    [SerializeField] private RectTransform _transform;
    [SerializeField] private HandView _handView;

    private Item _item;

    public Vector3 Position => _transform.position;

    public string FieldNameTransform => nameof(_transform);

    public ItemView BindItem(Item item)
    {
        _item = item;
        return this;
    }

    public void SetStartParent()
    {
        _transform.SetParent(_parent);
        _transform.SetSiblingIndex(_item.IndexParent);
    }

    public void SetTransformToHandParent()
    => _handView.SetParentToHandDown(_transform);

    public void SetStartPosition()
    => _transform.position = _item.StartPosition;

    private void LateUpdate()
    {
        if (_item.IsStatic)
            _transform.position = _item.StartPosition;
    }
}