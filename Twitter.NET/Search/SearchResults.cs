using System;
using System.Collections;
using System.Collections.Generic;

namespace Twitter.Net.Search
{
    public class SearchResults : ICollection<Tweet>, IList<Tweet>, IEnumerable
    {
        public Tweet this[int index] { get => Data[index]; set => Data[index] = value; }

        public List<Tweet> Data { get; set; }
        public Metadata Meta { get; set; }

        public int Count => Data.Count;

        public bool IsReadOnly => false;

        public void Add(Tweet item)
        {
            Data.Add(item);
        }

        public void Clear()
        {
            Data.Clear();
        }

        public bool Contains(Tweet item)
        {
            return Data.Contains(item);
        }

        public void CopyTo(Tweet[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Tweet> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        public int IndexOf(Tweet item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Tweet item)
        {
            Data.Insert(index, item);
        }

        public bool Remove(Tweet item)
        {
            return Data.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Data.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }
    }
}