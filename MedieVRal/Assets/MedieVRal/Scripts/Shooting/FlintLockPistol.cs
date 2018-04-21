namespace VRTK
{
    using UnityEngine;

    public class FlintLockPistol : VRTK_InteractableObject
    {
        [Header("FlintLock Pistol Options", order = 4)]

        public GameObject bullet;

        private Transform slot;

        private bool load = false;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            FireBullet();
        }

        protected void Start()
        {
            slot = transform.Find("AmmoSlot");
        }

        private void FireBullet()
        {
            if(load)
            {
                Instantiate(bullet, slot.transform.position, slot.transform.rotation);
                load = false;
            }
            /*
            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
            */
        }

        public void IsLoaded()
        {
            load = true;
        }
    }
}