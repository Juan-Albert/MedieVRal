using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK
{
    public class Throwable : VRTK_InteractableObject
    {

        private float maxDistance;

        private Rigidbody myRB;
        private BoxCollider myBC;

        private Vector3 actualPos;
        private Vector3 lastPos;
        private Vector3 direction;

        private Objectives target;

        private RaycastHit info;

        private bool agarrado = false;


        void Start()
        {

            myRB = GetComponent<Rigidbody>();
            myBC = GetComponent<BoxCollider>();

        }


        protected override void Update()
        {
            base.Update();

            if (IsGrabbed())
            {
                agarrado = true;
            }

            if (!IsGrabbed() && agarrado)
            {
                agarrado = false;
                myBC.enabled = false;
            }

            lastPos = actualPos;
            actualPos = transform.position;
            direction = (actualPos - lastPos);
            maxDistance = Vector3.Distance(actualPos, lastPos);
            Debug.DrawRay(lastPos, direction, Color.green, 10f);
            if (Physics.Raycast(lastPos, direction, out info, maxDistance))
            {
                Debug.DrawRay(lastPos, direction, Color.red, 10f);
                if (info.collider.gameObject.tag == "Diana")
                {
                    Debug.DrawRay(lastPos, direction, Color.blue, 10f);
                    transform.parent = info.collider.gameObject.transform.parent;
                    Destroy(myRB);
                    transform.position = info.point;
                    target = info.collider.gameObject.GetComponent<Objectives>();
                    target.Hitted();
                }

            }
            else if(Physics.Raycast(actualPos, direction, out info, maxDistance))
            {
                if (info.collider.gameObject.tag != "Diana")
                {
                    myBC.enabled = true;
                }
            }

        }
    }
}

