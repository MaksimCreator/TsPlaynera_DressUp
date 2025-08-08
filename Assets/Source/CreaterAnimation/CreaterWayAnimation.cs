using System;
using Zenject;

public abstract class CreaterWayAnimation
{
    private readonly ItemCatalog _itemCatalog;
    private readonly ItemViewCatalog _itemViewCatalog;
    private readonly PresenterControl _presenterControl;

    protected readonly Hand __hand;
    protected readonly StartPositionCatalog __startPositionCatalog;

    [Inject]
    public CreaterWayAnimation(Hand hand,
        ItemCatalog itemCatalog, 
        ItemViewCatalog itemViewCatalog,
        PresenterControl presenterControl,
        StartPositionCatalog startPositionCatalog)
    {
        __hand = hand;
        _itemCatalog = itemCatalog;
        _itemViewCatalog = itemViewCatalog;
        __startPositionCatalog = startPositionCatalog;
        _presenterControl = presenterControl;
    }

    protected void OnStartPositionItem(ItemView itemView, Item item)
    {
        itemView.SetStartParent();
        item.SetStatic(true);
    }

    protected void OnStartPositionHand()
    {
        __hand.ResetItem();
        _presenterControl.EnablePreseter();
    }

    protected Item GetItem(ItemView itemView)
    {
        if (_itemCatalog.TryGetValue(itemView, out Item item) == false)
            throw new InvalidOperationException();

        return item;
    }

    protected ItemView GetItemView(Item item)
    {
        if (_itemViewCatalog.TryGetValue(item, out ItemView view) == false)
            throw new InvalidOperationException();

        return view;
    }
}