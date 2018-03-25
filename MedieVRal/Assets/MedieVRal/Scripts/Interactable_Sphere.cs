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

        private Vector3 actualPos;
        private Vector3 lastPos;
        private Vector3 direction;

        private float maxDistance;

        private RaycastHit info;

        protected void Start()
        {
            myRB = GetComponent<Rigidbody>();

        }

        protected override void Update()
        {
            base.Update();
            if (IsGrabbed())
            {
                agarrado = true;
            }

            if(!IsGrabbed() && agarrado)
            {
                agarrado = false;
                StartCoroutine(Recuperarbola());
            }
            
            lastPos = actualPos;
            actualPos = transform.position;
            direction = (actualPos - lastPos);
            maxDistance = Vector3.Distance(actualPos, lastPos);
            Debug.DrawRay(actualPos, direction, Color.green, 10f);
            if(Physics.Raycast(actualPos, direction, out info, maxDistance))
            {
                Debug.DrawRay(actualPos, direction, Color.red, 10f);
                if (info.collider.gameObject.tag == "Muro_cube")
                {
                    Debug.DrawRay(actualPos, direction, Color.blue, 10f);
                    transform.parent = info.collider.gameObject.transform;

                    Destroy(myRB);
                }
            }
            
        }

        /*
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
        */

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