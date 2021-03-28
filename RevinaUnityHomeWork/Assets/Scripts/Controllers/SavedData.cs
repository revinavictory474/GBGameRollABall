namespace Geekbrains
{
    public sealed class SavedData<T> where T: struct
    {
        public int CountBonuses;
        public T IdPlayer = default;
    }
}