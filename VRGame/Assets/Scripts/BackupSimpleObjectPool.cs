using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupSimpleObjectPool : MonoBehaviour
{

/*

    //the prefab that this object pool returns instances of
    public GameObject prefab;
    //collection of currently inactive instances of this prefab
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    //a component that simply identifies the pool that a Gameobject came from
    
    
    
    //Returns an instance of the prefab
    public GameObject GetObject() {
        GameObject spawnedGameObject;

        //if there is an inactive instance of the prefab ready to return, return that
        if (inactiveInstances.Count > 0) {
            //remove the instance from the collection of inactive instances
            spawnedGameObject = inactiveInstances.Pop();
        } else { //otherwise, create an instance
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

            //add the PooledObject component to the prefab so we know it came from this pool
            PooledObject var pooledObjecttemp = spawnedGameObject.AddComponent<pooledObjecttemp>();
            pooledObjecttemp.pool = this;
        }

        //put the instance in the root of the scene and enable it
        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);

        //return a reference to the instance
        return spawnedGameObject;
    }

    //return an instance of the prefab to the pool
    public void ReturnObject(GameObject toReturn) {
        PooledObject var pooledObjecttemp = toReturn.GetComponent<pooledObjecttemp>();

        //if the instance came from this pool, return it to the pool
        if (pooledObjecttemp != null && pooledObjecttemp.pool == this) {
            //make the instance a child of this and diable it
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            //add the instance to the collection of inactive instances
            inactiveInstances.Push(toReturn);
        } else { //otherwise, just destroy it
            Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from destroying.");
            Destroy(toReturn);
        }
    }

    

*/
}

/*
public class PooledObject : MonoBehaviour {
    public SimpleObjectPool pool;
}
*/