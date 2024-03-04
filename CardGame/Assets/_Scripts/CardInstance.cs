public class CardInstance
{
    public readonly CardAsset CardAsset;
    public int LayoutId;
    public int CardPosition;

    public CardInstance(CardAsset cardAsset)
    {
        CardAsset = cardAsset;
    }

    public void MoveToLayout(int newLayoutId, int cardPosition)
    {
        LayoutId = newLayoutId;
        CardPosition = cardPosition;
    }
}