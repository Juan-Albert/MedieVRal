using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBehaviour : MonoBehaviour {

    private Rigidbody myRB;

    public GameObject particle;

    public Text score;


    void Start () {
        this.transform.Rotate(0,0,-30);
        myRB = GetComponent<Rigidbody>();
        myRB.AddForce(-transform.right * 4500f);
    }
	
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Muro")
        {
            
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            //score.text = (int.Parse(score.text) + 1).ToString();
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);

        }

        if (collision.gameObject.tag == "Casa")
        {
           
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            //score.text = (int.Parse(score.text) + 3).ToString();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }
}
