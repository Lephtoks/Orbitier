namespace Game.Scripts.Items
{
    public interface ILinkItem
    {
        int GetCount();
        ILinkItem WithCount(int count);
    }
}