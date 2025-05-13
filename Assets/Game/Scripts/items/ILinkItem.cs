namespace Game.Scripts.items
{
    public interface ILinkItem
    {
        int GetCount();
        ILinkItem WithCount(int count);
    }
}