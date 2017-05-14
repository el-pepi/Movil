using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool {

    List<GameObject> objects;
    
    public Pool()
    {
        objects = new List<GameObject>();
    }

    public GameObject GetFromPool()
    {
        foreach(GameObject o in objects)
        {
            if (o.activeSelf == false)
            {
                return o;
            }
        }
        return null;
    }

    public void AddToPool(GameObject g)
    {
        objects.Add(g);
    }

    public void ResetAll()
    {
        foreach (GameObject o in objects)
        {
            o.SetActive(false);
        }
    }
}
