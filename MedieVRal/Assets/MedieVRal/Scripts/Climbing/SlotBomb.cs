namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SlotBomb : MonoBehaviour
    {

        private VRTK_InteractableObject interactableBomb;
        private bool agarrado;
        private bool soltado = false;

        public GameObject mesh;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Bomb")
            {
                interactableBomb = other.GetComponent<VRTK_InteractableObject>();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!soltado)
            {
                if (other.gameObject.tag == "Bomb")
                {

                    if (interactableBomb.IsGrabbed())
                    {
                        agarrado = true;
                    }

                    if (!interactableBomb.IsGrabbed() && agarrado)
                    {
                        agarrado = false;
                        other.gameObject.transform.parent = this.gameObject.transform.parent;
                        Destroy(other.gameObject.GetComponent<Rigidbody>());
                        other.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                        mesh.SetActive(false);
                        soltado = true;
                    }
                }
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Bomb")
            {
                mesh.SetActive(true);
                agarrado = false;
                soltado = false;
            }

        }
    }
}