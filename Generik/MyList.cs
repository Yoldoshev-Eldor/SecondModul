namespace Generik;

public class MyList<T> : IMyList<T>
{
    private T[] items;
    private int count;

    public MyList()
    {
        items = new T[4];
        count = 0;
    }

    public MyList(int capacity)
    {
        items = new T[capacity];
        count = 0;
    }

    public void AddItem(T item)
    {
        if (count == items.Length)
        {
            Resize();
        }
        items[count++] = item;
    }

    public T GetItemAt(int index)
    {
        CheckIndex(index);
        return items[index];
    }

    private void Resize()
    {
        var newItems = new T[items.Length * 2];
        for (var i = 0; i < items.Length; i++)
        {
            newItems[i] = items[i];
        }

        items = newItems;
    }

    private void CheckIndex(int index)
    {
        if (0 > index || count <= index)
        {
            throw new IndexOutOfRangeException();
        }
    }

    public void RemoveItemAt(int index)
    {
        CheckIndex(index);
        for (var i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        count--;
        items[count] = default(T);


    }

    public void AddItemsRange(T[] nums)
    {
        foreach (var num in nums)
        {
            AddItem(num);
        }
    }

    public void ReplaceAllItems(T oldElement, T newElement)
    {
        for (var i = 0; i < count; i++)
        {
            if (object.Equals(items[i], oldElement))
            {
                items[i] = newElement;
            }
        }
    }

    public int GetItemIndex(T item)
    {
        for (var i = 0; i < count; i++)
        {
            if (object.Equals(items[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    public int GetCount()
    {
        return count;
    }

    public int GetCapacity()
    {
        return items.Length;
    }
    public bool Contains(T item)
    {
        var res = false;
        for (var i = 0; i < count; i++)
        {
            if (object.Equals(items[i], item))
            {
                res = true;
            }
        }
        return res;
    }
    public void Clear()
    {
        items = new T[0];

    }
    public void InsertAt(int index, T item)
    {
        var newItems = items;
        items = new T[newItems.Length];
        var copyCount = count;
        count = 0;
        var countSec = 0;
        for (var i = 0; i < copyCount; i++)
        {
            if (i != index)
            {
                AddItem(newItems[countSec]);
                countSec++;
            }
            else
            {
                AddItem(item);
                index = int.MaxValue;
                i--;
            }
        }
    }


}