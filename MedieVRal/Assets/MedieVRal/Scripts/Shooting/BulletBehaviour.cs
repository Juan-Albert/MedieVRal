using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehaviour : MonoBehaviour
{
    //Distancia entre una posición y la anterior para detectar colision.
    private float maxDistance;

    //Componentes RigitBody y BoxCollider del objeto lanzable.
    private Rigidbody myRB;
    private SphereCollider mySC;

    //Componentes para calcular la colisión: la posición actual, la posición anterior y la dirección.  
    private Vector3 actualPos;
    private Vector3 lastPos;
    private Vector3 direction;

    //Objeto que almacena la información de la colisión
    private RaycastHit info;


    void Start()
    {
        this.transform.Rotate(0, 0, -30);
        myRB = GetComponent<Rigidbody>();
        myRB.AddForce(-transform.right * 2000f);
        mySC = GetComponent<SphereCollider>();
        mySC.enabled = false;
    }


    void Update()
    {
        lastPos = actualPos;
        actualPos = transform.position;
        direction = (actualPos - lastPos);
        maxDistance = Vector3.Distance(actualPos, lastPos);
        //Debug.DrawRay(lastPos, direction, Color.green, 10f);
        //Se usa la herramienta Raycast para generar rayos que calculen la colisión con los objetivos dada una distancia máxima.
        if (Physics.Raycast(lastPos, direction, out info, maxDistance))
        {
            //Debug.DrawRay(lastPos, direction, Color.red, 10f);
            //Se comprueba si se ha colisionado con una diana.
            if (info.collider.gameObject.tag == "Diana")
            {
                //Debug.DrawRay(lastPos, direction, Color.blue, 10f);
                //Para que el objeto lanzable se quede 'clavado' en el objetivo lo asignamos como su hijo y le quitamos el
                //componente RigitBody para que no tenga gravedad y caiga al suelo.
                transform.parent = info.collider.gameObject.transform.parent;
                Destroy(myRB);
                transform.position = info.point;
                //Por último se obtiene el objetivo y se lanza el método de que ha sido alcanzado.
                info.collider.gameObject.GetComponent<Objectives>().Hitted();
            }

        }
        else if (Physics.Raycast(actualPos, direction, out info, maxDistance))
        {
            //Si se ha alcanzado un objeto que no es una diana.
            if (info.collider.gameObject.tag != "Diana")
            {
                mySC.enabled = true;
            }
        }
    }

}
