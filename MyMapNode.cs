using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableProblem
{
   class MyMapNode<K, V>
        {
            public struct KeyValue<k, v>
            {
                public k Key { get; set; }
                public v Value { get; set; }
            }
            private readonly int size;            
            private readonly LinkedList<KeyValue<K, V>>[] items;

            public MyMapNode(int size)
            {
                this.size = size;
                //arr=new int[size];
                this.items = new LinkedList<KeyValue<K, V>>[size];
            }
            protected int GetArrayPosition(K key)
            {
                int hash = key.GetHashCode(); 
                int position = hash % size; 
                return Math.Abs(position);
            }

            public V Get(K key)
            {
                var linkedList = GetArrayPositionAndLinkedList(key);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                        return item.Value;
                }

                return default(V);
            }

            public void Add(K key, V value)
            {
                var linkedList = GetArrayPositionAndLinkedList(key);
                KeyValue<K, V> item = new KeyValue<K, V>()
                { Key = key, Value = value };
                if (linkedList.Count != 0)
                {
                    foreach (KeyValue<K, V> item1 in linkedList)
                    {
                        if (item1.Key.Equals(key))
                        {
                            Remove(key);
                            break;
                        }
                    }
                }
                linkedList.AddLast(item); 
                                          
            }

            public bool Exists(K key)
            {
                var linkedList = GetArrayPositionAndLinkedList(key);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return true;
                    }
                }
                return false;
            }

            public LinkedList<KeyValue<K, V>> GetArrayPositionAndLinkedList(K key)
            {
                int position = GetArrayPosition(key); 
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                return linkedList;
            }


            public void Remove(K key)
            {
                var linkedList = GetArrayPositionAndLinkedList(key);
                bool itemFound = false;
                KeyValue<K, V> foundItem = default(KeyValue<K, V>);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        itemFound = true;
                        foundItem = item;
                    }
                }
                if (itemFound)
                {
                    linkedList.Remove(foundItem);
                }
            }

            protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
            {
                LinkedList<KeyValue<K, V>> linkedList = items[position]; 
                if (linkedList == null)
                {
                    linkedList = new LinkedList<KeyValue<K, V>>();
                    items[position] = linkedList;
                }
                return linkedList;
            }

            public void Display()
            {
                foreach (var linkedList in items)
                {
                    if (linkedList != null)
                        foreach (var element in linkedList)
                        {
                            string res = element.ToString();
                            if (res != null)
                                Console.WriteLine(element.Key + " " + element.Value);
                        }
                }
          }
    }
}