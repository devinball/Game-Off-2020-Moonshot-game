using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

	public static ObjectPooler SharedInstance;

	public List<GameObject> PooledObjects;
	public GameObject PoolObject;
	public int PoolAmount;

	void Awake() {
	  SharedInstance = this;
	}

	void Start() {
		PooledObjects = new List<GameObject>();
			for (int i = 0; i < PoolAmount; i++) {
			  GameObject obj = (GameObject)Instantiate(PoolObject);
			  obj.SetActive(false);
			  PooledObjects.Add(obj);
			}
	}

	public GameObject PoolRequest() {
	  for (int i = 0; i < PooledObjects.Count; i++) {
	    if (!PooledObjects[i].activeInHierarchy) {
	      return PooledObjects[i];
	    }
	  }
	  return null;
	}
}
