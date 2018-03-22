using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour {

	public float speed = 5f;
	public float speed_Rotation = 5f;
	private float target_rotationZ;

	private bool direction = true;
	private bool rotation = true;
	private bool hitted = false;

	public Transform cube_Pivot;
	// Use this for initialization
	void Start () {
		target_rotationZ = transform.rotation.eulerAngles.z - 90;
		Debug.Log ("new Rotation:" + target_rotationZ);
	}

	// Update is called once per frame
	void Update () {

		if (!hitted)
		{
			transform.Rotate (0, 0, -speed_Rotation * Time.deltaTime);

			if (transform.rotation.eulerAngles.z <= 270 && transform.rotation.eulerAngles.z >= 10) 
			{
				hitted = true;
				//transform.rotation.eulerAngles.Set(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,270);
			}
				


		}
		/*
		if (!hitted) {
			if (transform.position.z < 7f && direction) {
				transform.Translate (0, 0, speed * Time.deltaTime);


			} else {
				direction = false;
			}

			if (transform.position.z > -7f && !direction) {
				transform.Translate (0, 0, -speed * Time.deltaTime);
			
			} else {
				direction = true;
			}
		} 
		else
		{
			float newZ = Mathf.LerpAngle (transform.rotation.eulerAngles.z, target_rotationZ, Time.deltaTime * speed_Rotation);
			Debug.Log ("Z: " + transform.rotation.eulerAngles.z + " newZ: " + newZ);

			if (transform.rotation.eulerAngles.z == newZ) {

				gameObject.SetActive(false);

			} else {
				transform.eulerAngles = new Vector3 (0, 0, newZ);
			}
		}
		*/
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Throwable")
		{
			

		}
	}
}
