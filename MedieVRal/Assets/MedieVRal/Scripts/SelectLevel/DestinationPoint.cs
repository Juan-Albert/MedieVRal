using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DestinationPoint : MonoBehaviour {

    public int level;
    public int pointsNeeded;

	void Start () {
        if(GameManager.instance.GetPoints(level) < pointsNeeded)
        {
            this.gameObject.GetComponent<VRTK_DestinationPoint>().enableTeleport = false;
        }
	}
	

}
