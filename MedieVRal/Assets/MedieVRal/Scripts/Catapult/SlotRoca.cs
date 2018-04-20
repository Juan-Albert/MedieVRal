namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SlotRoca : MonoBehaviour
    {

        private VRTK_InteractableObject interactableRock;
        private bool agarrado;
        private bool soltado = false; 

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Roca")
            {
               interactableRock  = other.GetComponent<VRTK_InteractableObject>();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(!soltado)
            {
                if (other.gameObject.tag == "Roca")
                {

                    if (interactableRock.IsGrabbed())
                    {
                        agarrado = true;
                    }

                    if (!interactableRock.IsGrabbed() && agarrado)
                    {
                        agarrado = false;
                        other.gameObject.transform.parent = this.gameObject.transform.parent;
                        Destroy(other.gameObject.GetComponent<Rigidbody>());
                        other.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                        soltado = true;
                    }
                }
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Roca")
            {
                agarrado = false;
                soltado = false;
            }
                
        }
    }
}

