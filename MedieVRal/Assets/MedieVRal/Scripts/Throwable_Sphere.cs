using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK
{
    public class Throwable_Sphere : VRTK_InteractableObject
    {

        private float maxDistance;

        private Rigidbody myRB;

        private Vector3 actualPos;
        private Vector3 lastPos;
        private Vector3 direction;


        private RaycastHit info;


        void Start()
        {

            myRB = GetComponent<Rigidbody>();

        }


        void Update()
        {

            lastPos = actualPos;
            actualPos = transform.position;
            direction = (actualPos - lastPos);
            maxDistance = Vector3.Distance(actualPos, lastPos);
            Debug.DrawRay(actualPos, direction, Color.green, 10f);
            if (Physics.Raycast(actualPos, direction, out info, maxDistance))
            {
                Debug.DrawRay(actualPos, direction, Color.red, 10f);
                if (info.collider.gameObject.tag == "Muro_cube")
                {
                    Debug.Log(maxDistance);
                    Debug.DrawRay(actualPos, direction, Color.blue, 10f);
                    transform.parent = info.collider.gameObject.transform.parent;
                    Destroy(myRB);
                }
            }

        }
    }
}

