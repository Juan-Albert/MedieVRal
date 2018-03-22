using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{


    public class Interactable_Sphere : VRTK_InteractableObject
    {

        public Transform respawnLocation;
        private Rigidbody myRB;
        private bool agarrado = false;
        private bool colisiona = false;

        // Use this for initialization
        void Start()
        {
            myRB = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if(IsGrabbed())
            {
                agarrado = true;
            }

            if(!IsGrabbed() && agarrado)
            {
                agarrado = false;
                StartCoroutine(Recuperarbola());
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Muro_cube")
            {
                colisiona = true;
                collision.gameObject.SetActive(false);
                //Destroy(collision.gameObject);

                transform.position = respawnLocation.position;
                myRB.velocity = Vector3.zero;
                myRB.angularVelocity = Vector3.zero;

            }
        }

        IEnumerator Recuperarbola()
        {
            
            yield return new WaitForSeconds(5);
            if(!colisiona)
            {
                transform.position = respawnLocation.position;
                myRB.velocity = Vector3.zero;
                myRB.angularVelocity = Vector3.zero;
            }
            else
            {
                colisiona = false;
            }
            
        }
    }
}