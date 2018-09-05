using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBehaviour : MonoBehaviour {

    private Rigidbody myRB;

    private CatapultManager catapultManager;

    public GameObject particle;


    private void Start()
    {
        catapultManager = GameObject.Find("CatapultManager").GetComponent<CatapultManager>();
        catapultManager.UseAmmo();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Muro")
        {
            
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            catapultManager.IncreasePoints(1);
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Tower")
        {

            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            catapultManager.IncreasePoints(2);
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Casa")
        {
           
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            catapultManager.IncreasePoints(3);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
        
    }



    public void SetForce(float force)
    {
        this.transform.Rotate(0, 0, -30);
        myRB = GetComponent<Rigidbody>();
        myRB.AddForce(-transform.right * 5800f * force);
    }
}
