#nullable enable
namespace Game.Scripts.Items
{
    public struct Energy : ILinkItem
    {
        public readonly float value;

        public Energy(float value)
        {
            this.value = value;
        }

        public int GetCount()
        {
            return (int) value;
        }

        public ILinkItem WithCount(int count)
        {
            return new Energy(count);
        }
    }
}