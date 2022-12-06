using System;
using System.Collections.Generic;
using InvokeSystem;
using UnityEngine;

namespace ObjectPoolSystem
{
    
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObjectPool : MonoBehaviour, IInvoke
    {
        [Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
            public Transform container;
        }
        
        public static ObjectPool instance;

        [SerializeField] private Pool[] pools;

        private Dictionary<string, Queue<GameObject>> poolDictionary;

        public void SetUp()
        {
            instance = this;
            
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int j = 0; j < pool.size; j++)
                {
                    GameObject obj = Instantiate(pool.prefab, pool.container);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                
                poolDictionary.Add(pool.tag, objectPool);
            }
        }
        
        public GameObject Spawn(string objTag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(objTag)) return null;

            GameObject objectToSpawn = poolDictionary[objTag].Dequeue();
            
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();
            
            if (pooledObject != null)
            {
                pooledObject.OnObjectSpawn();
            }
            
            poolDictionary[objTag].Enqueue(objectToSpawn);
            
            return objectToSpawn;
        }
        
        public void DeSpawn(GameObject obj)
        {
            obj.SetActive(false);
        }

        public void ResetAllPools()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int j = 0; j < pool.container.childCount; j++)
                {
                    GameObject child = pool.container.GetChild(j).gameObject;
                    
                    child.SetActive(false);
                    objectPool.Enqueue(child);
                }
                
                poolDictionary.Add(pool.tag, objectPool);
            }
        }
    }
}