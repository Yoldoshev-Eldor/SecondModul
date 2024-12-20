namespace Generik
{
    public interface IMyList<T>
    {
        public void AddItem(T item);
        public T GetItemAt(int index);
        public void RemoveItemAt(int index);
        public void ReplaceAllItems(T oldElement, T newElement);
        public bool Contains(T item);
        public void Clear();
        public void InsertAt(int index, T item);
    }
}