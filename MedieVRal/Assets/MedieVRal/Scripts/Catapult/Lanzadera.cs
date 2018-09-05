using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanzadera : MonoBehaviour {


    public GameObject manivela;
    public GameObject ammo;

    private bool activated = false;

    private float speed = 400f;
    private float force = 1f;

    private GameObject rock;

    private Vector3 ammoPosition;
    private Quaternion ammoRotation;




	// Update is called once per frame
	void FixedUpdate () {
		if(activated)
        {
            this.transform.Rotate(0, 0, speed * Time.deltaTime);
            
            if (this.transform.rotation.eulerAngles.z < 235 && this.transform.rotation.eulerAngles.z >= 0)
            {
                this.transform.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, 0);
                activated = false;
                manivela.transform.eulerAngles = new Vector3(0, 115, 0);
                //roca = this.gameObject.transform.Find("rock");

                if (rock != null)
                {
                    ammoPosition = rock.transform.position;
                    Destroy(rock.gameObject);
                    GameObject ammunition = Instantiate(ammo, ammoPosition, this.transform.rotation) as GameObject;
                    ammunition.GetComponent<AmmoBehaviour>().SetForce(force);
                    //ammo.transform.parent = this.transform.parent;
                    //ammo.transform.Translate(ammoPosition);

                }
            }
            
        }
	}

    public void Activate()
    {
        Debug.Log(this.gameObject.transform.eulerAngles.z);
        force = (360f - this.gameObject.transform.eulerAngles.z)/125f;
        Debug.Log(force);
        activated = true;
        
    }

    public void SetRock(GameObject newRock)
    {
        rock = newRock;
    }
}
