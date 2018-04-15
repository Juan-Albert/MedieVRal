﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzadera : MonoBehaviour {


    public GameObject manivela;
    public GameObject ammo;

    private bool activated = false;

    private float speed = 300f;

    private Transform roca;

    private Vector3 ammoPosition;
    private Quaternion ammoRotation;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(activated)
        {
            this.transform.Rotate(0, 0, speed * Time.deltaTime);
            
            if (this.transform.rotation.eulerAngles.z < 235 && this.transform.rotation.eulerAngles.z >= 0)
            {
                this.transform.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, 0);
                activated = false;
                manivela.transform.eulerAngles = new Vector3(0, 0, 0);
                roca = this.gameObject.transform.Find("rock");
                
                if(roca != null)
                {
                    ammoPosition = roca.position;

                    Destroy(roca.gameObject);
                    Instantiate(ammo, ammoPosition, this.transform.rotation);
                    ammo.transform.parent = this.transform.parent;
                    //ammo.transform.Translate(ammoPosition);
                    //ammo.GetComponent<Rigidbody>().AddForce(transform.forward * 1000000000f, ForceMode.VelocityChange);
                }
            }
            
        }
	}

    public void Activate()
    {
        activated = true;
    }
}
