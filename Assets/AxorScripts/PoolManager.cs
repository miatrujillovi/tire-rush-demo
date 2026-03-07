using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    public ObjectPool[] pools;

    private Dictionary<string, ObjectPool> poolDictionary;

    void Awake()
    {
        instance = this;

        poolDictionary = new Dictionary<string, ObjectPool>();

        foreach (ObjectPool pool in pools)
        {
            poolDictionary.Add(pool.poolName, pool);
        }
    }

    public GameObject GetObject(string poolName)
    {
        if (poolDictionary.ContainsKey(poolName))
        {
            return poolDictionary[poolName].GetObject();
        }

        return null;
    }
}