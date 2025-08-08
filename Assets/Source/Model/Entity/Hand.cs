public class Hand
{
    private Item _item;

    public void SetItem(Item typeItem)
    => _item = typeItem;

    public void ResetItem()
    => _item = null;

    public Item GetItem()
    => _item;
}