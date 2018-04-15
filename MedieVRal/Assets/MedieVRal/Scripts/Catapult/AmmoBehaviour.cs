using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehaviour : MonoBehaviour {

    private Rigidbody myRB;

    public Quaternion orientation;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody>();
        myRB.AddForce(-transform.right * 1000f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
