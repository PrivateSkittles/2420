using System;
using System.Diagnostics;


class List<T>
{
    T[] underlyingArray = new T[3];

    public void Add(T value)
    {
        if (Count == underlyingArray.Length)
            growUnderlyingArray();
        underlyingArray[Count] = value;
        Count++;
    }

    private void growUnderlyingArray()
    {
        T[] newArray = new T[underlyingArray.Length * 2];
        for (int i = 0; i < underlyingArray.Length; i++)
            newArray[i] = underlyingArray[i];
        underlyingArray = newArray;    
    }

    public T this[int index]
    {
        get
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();
            return underlyingArray[index];
        }

        set
        {
            if (index >= Count)
                throw new IndexOutOfRangeException();
            underlyingArray[index] = value;
        }
    }

    public int Count { get; private set; }
}
