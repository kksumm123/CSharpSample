namespace 머드게임
{
    internal class Item
    {
        public TypeOfStats typeOfStats;
        internal int value;

        public Item(TypeOfStats typeOfStats, int value)
        {
            this.typeOfStats = typeOfStats;
            this.value = value;
        }

    }
}