using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class MyHashTable<TKey, TValue> : IDictionary<TKey, TValue>
{
    LinkedList<KeyValuePair<TKey, TValue>>[] baseArray = new LinkedList<KeyValuePair<TKey, TValue>>[3];
    private int count = 0;

    public TValue this[TKey key]
    {
        get
        {
            int bucketIndex = Math.Abs(key.GetHashCode() % baseArray.Length);
            LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[bucketIndex];
            foreach (KeyValuePair<TKey, TValue> pair in bucket)
                if (pair.Key.Equals(key))
                    return pair.Value;
            throw new Exception("Out of Range");
           
        }
        set
        {
            int bucketIndex = Math.Abs(key.GetHashCode() % baseArray.Length);
            if (baseArray[bucketIndex] == null)
            {
                Add(key, value);
                return;
            }
            LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[bucketIndex];
            foreach (KeyValuePair<TKey, TValue> pair in bucket)
                if (pair.Key.Equals(key))
                {
                    bucket.Remove(pair);
                    bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
                    return;
                }
            bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
            count++;
        }
    }
    public int Count
    {
        get
        {
            return count;
        }
    }
    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }
    public ICollection<TKey> Keys
    {
        get
        {
            List<TKey> keyList = new List<TKey>();
            for (int i = 0; i < baseArray.Length; i++)
            {
                if (baseArray[i] == null)
                    continue;
                LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[i];
                foreach (KeyValuePair<TKey, TValue> pair in bucket)
                    keyList.Add(pair.Key);
            }
            return keyList;
        }
    }
    public ICollection<TValue> Values
    {
        get
        {
            List<TValue> valueList = new List<TValue>();
            for (int i = 0; i < baseArray.Length; i++)
            {
                if (baseArray[i] == null)
                    continue;
                LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[i];
                foreach (KeyValuePair<TKey, TValue> pair in bucket)
                    valueList.Add(pair.Value);
            }
            return valueList;
        }
    }
    public void Add(KeyValuePair<TKey, TValue> item)
    {
        if (count > baseArray.Length * .75) //90%, expands base array
            expandBaseArray();
        int bucketIndex = Math.Abs(item.Key.GetHashCode() % baseArray.Length);
        if (baseArray[bucketIndex] == null)
            baseArray[bucketIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
        LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[bucketIndex];
        bucket.AddLast(item);
        count++;
    }
    public void Add(TKey key, TValue value)
    {
        if (count > baseArray.Length * .75) //90% expands base array
            expandBaseArray();
        int bucketIndex = Math.Abs(key.GetHashCode() % baseArray.Length);
        if (baseArray[bucketIndex] == null)
            baseArray[bucketIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
        LinkedList<KeyValuePair<TKey,TValue >> bucket = baseArray[bucketIndex];
        bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
        count++;
    }
    public void Clear()
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] newArray = new LinkedList<KeyValuePair<TKey, TValue>>[10];
        baseArray = newArray;
        count = 0;
    }
    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        int bucketIndex = Math.Abs(item.Key.GetHashCode() % baseArray.Length);
        LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[bucketIndex];
        foreach (KeyValuePair<TKey, TValue> pair in bucket)
            if (pair.Key.Equals(item.Key) && pair.Value.Equals(item.Value))
                return true;
        return false;
    }
    public bool ContainsKey(TKey key)
    {
        int bucketIndex = Math.Abs(key.GetHashCode() % baseArray.Length);
        LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[bucketIndex];
        foreach (KeyValuePair<TKey, TValue> pair in bucket)
            if (pair.Key.Equals(key))
                return true;
        return false;
    }
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < baseArray.Length; i++)
        {
            if (baseArray[i] == null)
                continue;
            LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[i];
            foreach (KeyValuePair<TKey, TValue> pair in bucket)
                yield return pair;
        }
    }
    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        int bucketIndex = Math.Abs(item.Key.GetHashCode() % baseArray.Length);
        LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[bucketIndex];
        if (bucket.Contains(item))
        {
            bucket.Remove(item);
            count--;
            return true;
        }
        return false;
    }
    public bool Remove(TKey key)
    {
        int bucketIndex = Math.Abs(key.GetHashCode() % baseArray.Length);
        LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[bucketIndex];
        foreach(KeyValuePair<TKey,TValue> pair in bucket)
        {
            if (pair.Key.Equals(key))
            {
                bucket.Remove(pair);
                count--;
                return true;
            }
        }
        return false;
    }
    public bool TryGetValue(TKey key, out TValue value)
    {
        value = default(TValue);
        int bucketIndex = Math.Abs(key.GetHashCode() % baseArray.Length);
        LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[bucketIndex];
        foreach (KeyValuePair<TKey,TValue> pair in bucket)
            if (pair.Key.Equals(key))
            {
                value = pair.Value;
                return true;
            }
        return false;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    //Expands base array
    private void expandBaseArray()
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] newBaseArray = new LinkedList<KeyValuePair<TKey, TValue>>[baseArray.Length * 2];
        for (int i = 0; i < baseArray.Length - 1; i++)
        {
            LinkedList<KeyValuePair<TKey, TValue>> bucket = baseArray[i];
            foreach (KeyValuePair<TKey,TValue> pair in bucket)
            {
                int bucketIndex = Math.Abs(pair.Key.GetHashCode() % newBaseArray.Length);
                if (newBaseArray[bucketIndex] == null)
                    newBaseArray[bucketIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                LinkedList<KeyValuePair<TKey, TValue>> newBucket = newBaseArray[bucketIndex];
                newBucket.AddLast(pair);
            }
        }
        baseArray = newBaseArray;
    }
}
class MainClass
{
    static void Main()
    {
        MyHashTable<string, string> hashtable = new MyHashTable<string, string>();


        //Add functions
        //Contains and ContainsKey functions used for asserting
        hashtable.Add("Mark", "Football player");
        hashtable.Add(new KeyValuePair<string, string>("Jerry", "Engineer"));
        hashtable.Add("Tina", "Ballerina");
        hashtable.Add(new KeyValuePair<string, string>("Susan", "Architect"));

        Debug.Assert(hashtable.Count == 4);
        Debug.Assert(hashtable.Contains(new KeyValuePair<string, string>("Jerry", "Engineer")) == true);
        Debug.Assert(hashtable.ContainsKey("Tina") == true);

        //Prints hashtable
        Console.WriteLine("Table: ");
        foreach(KeyValuePair<string,string > pair in hashtable)
        {
            Console.WriteLine(pair.Key + " - " +  pair.Value);
        }

        Console.WriteLine();
        Console.WriteLine("Keys only: ");
        foreach (string key in hashtable.Keys)
        {
            Console.WriteLine(key);
        }

        Console.WriteLine();
        Console.WriteLine("Value only: ");
        foreach (string value in hashtable.Values)
        {
            Console.WriteLine(value);
        }


        //Remove functions
        hashtable.Remove("Mark");
        hashtable.Remove(new KeyValuePair<string, string> ("Tina", "Ballerina"));

        Debug.Assert(hashtable.Count == 2);
        Debug.Assert(hashtable.ContainsKey("Tina") == false);
        Debug.Assert(hashtable.Contains(new KeyValuePair<string, string>("Mark", "Football player")) == false);


        Console.WriteLine();
        Console.WriteLine("Table with Mark and Tina using both Remove methods: ");
        foreach(KeyValuePair < string, string > pair in hashtable)
        {
            Console.WriteLine(pair.Key + " - " + pair.Value);
        }


        //Try Get Value function
        Console.WriteLine();
        string gotValue = "";
        if (hashtable.TryGetValue("Jerry", out gotValue))
        {
            Console.WriteLine("Value out of key 'Jerry' using TryGetValue: ");
            Console.WriteLine(gotValue);
        }

        Debug.Assert(gotValue == "Engineer");


        //Clear function
        Console.WriteLine();
        Console.WriteLine("Table cleared: ");
        hashtable.Clear();
        foreach (KeyValuePair<string, string> pair in hashtable)
        {
            Console.WriteLine(pair.Key + " - " + pair.Value);
        }
        Debug.Assert(hashtable.Count == 0);

        Console.WriteLine();
    }
}