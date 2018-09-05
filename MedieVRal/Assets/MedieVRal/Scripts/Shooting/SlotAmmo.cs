namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SlotAmmo : MonoBehaviour
    {
        public FlintLockPistol pistol;

        private VRTK_InteractableObject interactableAmmo;
        private bool agarrado;
        private bool soltado = false;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ammo")
            {
                interactableAmmo = other.GetComponent<VRTK_InteractableObject>();
                soltado = false;
            }
            else if(other.gameObject.tag == "GunPowder")
            {
                pistol.ChargeGunpowder();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!soltado)
            {
                if (other.gameObject.tag == "Ammo")
                {

                    if (interactableAmmo.IsGrabbed())
                    {
                        agarrado = true;
                    }

                    if (!interactableAmmo.IsGrabbed() && agarrado)
                    {
                        agarrado = false;
                        Destroy(other.gameObject);
                        soltado = true;
                        pistol.IsLoaded();
                    }
                }
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Ammo")
            {
                agarrado = false;
                soltado = false;
            }

        }
    }
}
