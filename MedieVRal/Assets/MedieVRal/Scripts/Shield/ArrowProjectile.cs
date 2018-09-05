using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour {

    private Rigidbody rb;

    private float t = 0.0f;
    private bool moving = false;

    private Vector3 dir;

    private GameObject player;
    private ShieldManager shieldManager;
 
    private bool hit = false;

    //Distancia entre una posición y la anterior para detectar colision.
    private float maxDistance;

    //Componentes para calcular la colisión: la posición actual, la posición anterior y la dirección.  
    private Vector3 actualPos;
    private Vector3 lastPos;
    private Vector3 direction;

    //Objeto que almacena la información de la colisión
    private RaycastHit info;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Camera (eye)");
        transform.LookAt(player.transform.position);
        shieldManager = GameObject.Find("ShieldManager").GetComponent<ShieldManager>();
    }

    void FixedUpdate()
    {
        if(!hit)
        {
            rb.velocity = transform.forward * 10;

            t = t + Time.deltaTime;
            if (t > 50.0f)
            {
                Destroy(this.gameObject);
            }
        }
        if(!hit)
        {
            lastPos = actualPos;
            actualPos = transform.position;
            direction = (actualPos - lastPos);
            maxDistance = Vector3.Distance(actualPos, lastPos);
            Debug.DrawRay(lastPos, direction, Color.green, 10f);
            //Se usa la herramienta Raycast para generar rayos que calculen la colisión con los objetivos dada una distancia máxima.
            if (Physics.Raycast(lastPos, direction, out info, maxDistance))
            {
                Debug.DrawRay(lastPos, direction, Color.red, 10f);
                //Se comprueba si se ha colisionado con una diana.

                if (info.collider.gameObject.tag == "MainCamera")
                {
                    Debug.DrawRay(lastPos, direction, Color.blue, 10f);
                    shieldManager.DecreasePoints();                  
                    Destroy(this.gameObject);
                }
                else if (info.collider.gameObject.tag == "Shield")
                {
                    Debug.DrawRay(lastPos, direction, Color.yellow, 10f);
                    hit = true;
                    transform.parent = info.collider.gameObject.transform.parent;
                    Destroy(rb);
                    transform.position = info.point;

                }

            }
        }
        


    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Shield")
        {
            hit = true;
            Destroy(rb);
            this.transform.SetParent(other.gameObject.transform.parent);
            Debug.Log("Exito");

        }
    }
    */


}
