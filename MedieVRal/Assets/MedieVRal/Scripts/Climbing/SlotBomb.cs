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
        private bool colocado = false;
        private GameObject bomb;

        public GameObject mesh;
        public GameObject particle;

        public ClimbingManager climbingManager;


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
                        bomb = other.gameObject;
                        agarrado = false;
                        bomb.transform.parent = this.gameObject.transform.parent;
                        Destroy(bomb.GetComponent<Rigidbody>());
                        bomb.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                        bomb.GetComponent<VRTK_InteractableObject>().enabled = false;
                        bomb.GetComponent<Bomb>().enabled = true;
                        climbingManager.IncreasePoints();
                        mesh.SetActive(false);
                        soltado = true;
                        colocado = true;
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
                colocado = false;
            }

        }

        public bool IsPlaced()
        {
            return colocado;
        }

        public void Detonate()
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            Destroy(bomb);
        }
    }
}