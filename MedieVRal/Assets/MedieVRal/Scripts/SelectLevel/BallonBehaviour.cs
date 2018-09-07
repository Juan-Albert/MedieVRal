using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BallonBehaviour : MonoBehaviour {


	void Start () {
		if(GameManager.instance.GetPoints(7) > 5)
        {
            this.gameObject.GetComponent<BalloonSpawner>().autoSpawn = true;
        }
	}
	

}
