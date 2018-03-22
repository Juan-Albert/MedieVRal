using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Movement {x, y, z}

public class Objectives : MonoBehaviour {

	public float speed_Translation = 5f;
	public float speed_Rotation = 5f;
	public float move_Translation = 7f;
	public float spawn_time = 2f;
	public Movement movement;

	private float initial_pos;

	private bool direction = true;
	private bool hitted = false;
	private bool spawned = false;

	public Transform pivot;
	// Use this for initialization
	void Start () {
		initial_pos = pivot.position.z;
		GetComponent<MeshRenderer> ().enabled = false;
		StartCoroutine(Spawn());
		//Debug.Log ("new Rotation:" + target_rotationZ);
	}

	// Update is called once per frame
	void Update () {
		switch (movement) 
		{
		case Movement.z:

			if (spawned) {
				if (!hitted) 
				{
					if (pivot.position.z < initial_pos + move_Translation && direction) 
					{
						pivot.Translate (0, 0, speed_Translation * Time.deltaTime);


					} 
					else 
					{
						direction = false;
					}

					if (pivot.position.z > initial_pos - move_Translation && !direction) 
					{
						pivot.Translate (0, 0, -speed_Translation * Time.deltaTime);

					} 
					else 
					{
						direction = true;
					}
				} 
				else 
				{

					pivot.Rotate (0, 0, -speed_Rotation * Time.deltaTime);

					if (pivot.rotation.eulerAngles.z <= 270 && pivot.rotation.eulerAngles.z >= 10) 
					{
						pivot.eulerAngles = new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 270);
						StartCoroutine (EliminarDiana ());
					}

				}

			}
			break;
			
		}


	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Throwable")
		{
			
			hitted = true;
		}
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(spawn_time);
		GetComponent<MeshRenderer> ().enabled = true;
		spawned = true;

	}

	IEnumerator EliminarDiana()
	{

		yield return new WaitForSeconds(5);
		Destroy (pivot.gameObject);
		Destroy(this.gameObject);

	}
}
