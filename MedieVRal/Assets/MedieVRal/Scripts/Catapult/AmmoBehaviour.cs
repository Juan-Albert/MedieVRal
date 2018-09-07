using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBehaviour : MonoBehaviour {

    private Rigidbody myRB;

    private CatapultManager catapultManager;

    public GameObject particle;

    public AudioClip impact;


    private void Start()
    {
        catapultManager = GameObject.Find("CatapultManager").GetComponent<CatapultManager>();
        StartCoroutine(AutoDestruccion());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("holi");
        if (collision.gameObject.tag == "Muro")
        {
            SoundManager.instance.PlaySingle(impact);
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            catapultManager.IncreasePoints(1);
            Destroy(collision.gameObject.transform.parent.gameObject);

        }
        else if (collision.gameObject.tag == "Tower")
        {
            SoundManager.instance.PlaySingle(impact);
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            catapultManager.IncreasePoints(2);
            Destroy(collision.gameObject.transform.parent.gameObject);

        }
        else if (collision.gameObject.tag == "Casa")
        {
            SoundManager.instance.PlaySingle(impact);
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            catapultManager.IncreasePoints(3);
            Destroy(collision.gameObject);

        }
        
    }



    public void SetForce(float force)
    {
        this.transform.Rotate(0, 0, -30);
        myRB = GetComponent<Rigidbody>();
        myRB.AddForce(-transform.right * 5800f * force);
    }

    IEnumerator AutoDestruccion()
    {
        yield return new WaitForSeconds(10);
        catapultManager.UseAmmo();
        Destroy(this.gameObject);
    }
}
