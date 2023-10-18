using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ObjectPooler : MonoBehaviour
{
    
    public GameObject pooledObject;
    public int numberOfObject;
    private List<GameObject> gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new List<GameObject>();
        for (int i = 0; i < numberOfObject; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            gameObjects.Add(obj);
        }
    }
    public GameObject GetPooledGameObject(){
        foreach(GameObject obj in gameObjects){
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject gameObject = Instantiate(pooledObject);
        gameObject.SetActive(false);
        gameObjects.Add(gameObject);
        return gameObject;
    }
}