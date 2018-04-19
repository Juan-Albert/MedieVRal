using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyPaticle());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DestroyPaticle()
    {

        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }
}
