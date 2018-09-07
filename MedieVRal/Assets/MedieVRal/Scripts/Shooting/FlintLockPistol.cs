namespace VRTK
{
    using UnityEngine;

    public class FlintLockPistol : VRTK_InteractableObject
    {
        [Header("FlintLock Pistol Options", order = 4)]

        public GameObject bullet;

        public AudioClip fire;
        public AudioClip powder;

        private Transform slot;

        private bool load = false;
        private bool gunPowder = false;

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
                SoundManager.instance.PlaySingle(fire);
                Instantiate(bullet, slot.transform.position, slot.transform.rotation);
                gunPowder = false;
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
            if(gunPowder)
            {
                load = true;
            }
            
        }

        public void ChargeGunpowder()
        {
            SoundManager.instance.PlaySingle(powder);
            gunPowder = true;
        }
    }
}