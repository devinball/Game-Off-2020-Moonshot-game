using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

	//define varibles
	public int PoolAmount;
	public static ObjectPooler SharedInstance;
	public GameObject PoolObject;
	public List<GameObject> PooledObjects;

	//runs before start
	void Awake() {
	  SharedInstance = this;
	}

	//start
	void Start() {
		CreateObjects();
	}

	//instantiate x amount of objects. x is poolamount.
	void CreateObjects() {
		PooledObjects = new List<GameObject>();
		for (int i = 0; i < PoolAmount; i++) {
		  GameObject pooledObject = (GameObject)Instantiate(PoolObject);
		  pooledObject.SetActive(false);
		  PooledObjects.Add(pooledObject);
		}
	}

	//function for requesting a pooled object.
	public GameObject PoolRequest() {
	  for (int i = 0; i < PooledObjects.Count; i++) {
	    if (!PooledObjects[i].activeInHierarchy) {
	      return PooledObjects[i];
	    }
	  }
	  return null;
	}
}
