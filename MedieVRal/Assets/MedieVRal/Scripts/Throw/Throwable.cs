using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script Throwable.cs
 * Autor: Juan Alberto Martínez López
 * Fecha: 5/3/2018
 * Descripción: Script aplicado a objetos que pueden ser agarrados y lanzados por el usuario
 *              para dar a los objetivos. Hereda de la clase 'VRTK_InteractableObject' para
 *              poder saber cuando tenemos el objeto agarrado y cuando lo lanzamos.
*/
namespace VRTK
{
    public class Throwable : VRTK_InteractableObject
    {
        //Distancia entre una posición y la anterior para detectar colision.
        private float maxDistance;
        
        //Componentes RigitBody y BoxCollider del objeto lanzable.
        private Rigidbody myRB;
        private BoxCollider myBC;

        //Componentes para calcular la colisión: la posición actual, la posición anterior y la dirección.  
        private Vector3 actualPos;
        private Vector3 lastPos;
        private Vector3 direction;

        //Objeto objetivo alcanzado por el objeto lanzable.
        private Objectives target;

        //Objeto que almacena la información de la colisión
        private RaycastHit info;

        //Variable booleana que utilizamos para saber si hemos agarrado el objeto.
        private bool agarrado = false;

        //Variable booleana que utilizamos si se ha lanzado el objeto.
        private bool lanzado = false;


        protected void Start()
        {
            //Se obtiene las componentes RigitBody y BoxCollider del objeto lanzable.
            myRB = GetComponent<Rigidbody>();
            myBC = GetComponent<BoxCollider>();

        }


        protected override void Update()
        {
            base.Update();
            //Se comprueba si se ha agarrado el objeto.
            if (IsGrabbed())
            {
                agarrado = true;
            }

            //Se comprueba si el objeto se ha lanzado
            if (!IsGrabbed() && agarrado)
            {
                agarrado = false;
                myBC.enabled = false;
                lanzado = true;
            }

            if (lanzado)
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
                        target = info.collider.gameObject.GetComponent<Objectives>();
                        target.Hitted();
                    }

                }
                else if (Physics.Raycast(actualPos, direction, out info, maxDistance))
                {
                    //Si se ha alcanzado un objeto que no es una diana.
                    if (info.collider.gameObject.tag != "Diana")
                    {
                        myBC.enabled = true;
                    }
                }
            }

        }
    }
}

