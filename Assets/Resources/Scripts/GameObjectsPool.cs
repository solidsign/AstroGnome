using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsPool
{
    private Queue<GameObject> objects;

    public GameObjectsPool(int capacity, GameObject prefab)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject obj = Object.Instantiate(prefab);
            objects.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        GameObject obj = objects.Dequeue();
        objects.Enqueue(obj);
        return obj;
    }
}
