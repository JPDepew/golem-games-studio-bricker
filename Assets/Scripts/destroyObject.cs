using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour {

    public float timeToDestroy = 2;

	void Start () {
        StartCoroutine(DestroyThis());
	}

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
