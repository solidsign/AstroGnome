using System.Collections.Generic;
using UnityEngine;

public class GameObjectsPool : MonoBehaviour
{
    private Queue<GameObject> objects;

    public void CreateGameObjectsPool(int capacity, GameObject prefab)
    {
        objects = new Queue<GameObject>(capacity);
        for (int i = 0; i < capacity; i++)
        {
            GameObject obj = Instantiate(prefab);
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
