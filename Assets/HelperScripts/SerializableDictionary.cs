using System.Collections.Generic;
using UnityEngine;

namespace Utilties{
    [System.Serializable]
    public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver {
        [SerializeField] private List<SerializableKeyValuePair<TKey, TValue>> list = new List<SerializableKeyValuePair<TKey, TValue>>();
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        // This method is called after deserialization
        public void OnAfterDeserialize() {
            dictionary.Clear();
            foreach (var pair in list) {
                if (!dictionary.ContainsKey(pair.Key))
                    dictionary.Add(pair.Key, pair.Value);
            }
        }

        // This method is called before serialization
        public void OnBeforeSerialize() {}

        // Public method to access the dictionary
        public TValue GetValue(TKey key) {
            return dictionary[key];
        }

        // Other dictionary methods like Add, Remove, etc.
        public void Add(TKey key, TValue value) {
            dictionary.Add(key, value);
        }
        public void Remove(TKey key) {
            dictionary.Remove(key);
        }
        public bool ContainsKey(TKey key) {
            return dictionary.ContainsKey(key);
        }
        public bool ContainsValue(TValue value) {
            return dictionary.ContainsValue(value);
        }
        public Dictionary<TKey, TValue>.Enumerator GetEnumerator() {
            return dictionary.GetEnumerator();
        }
        public void Clear() {
            dictionary.Clear();
        }
        public int Count() {
            return dictionary.Count;
        }
        public TValue this[TKey key]{
            get => dictionary[key];
            set => dictionary[key] = value;
        }
        //Extend as needed
    }

}