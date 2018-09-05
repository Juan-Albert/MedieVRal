using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public Transform sparkPosition;
    public GameObject particle;

    void Start () {
        GameObject bombSpark = Instantiate(particle, sparkPosition.position, sparkPosition.rotation) as GameObject;
        bombSpark.gameObject.transform.SetParent(this.transform);
    }
	

}
