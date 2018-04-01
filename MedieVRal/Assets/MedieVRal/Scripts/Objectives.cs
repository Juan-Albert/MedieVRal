using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Movement {x, y, z, square, none}

public class Objectives : MonoBehaviour {

	public float speed_Translation = 5f;
	public float speed_Rotation = 5f;
	public float move_Translation = 7f;
	public float spawn_time = 2f;
	public Movement movement;
    public Text score;

    private Vector3 initial_pos;

	private bool direction = true;
	private bool hitted = false;
	private bool spawned = false;
    private bool puntuar = true;
    private BoxCollider myCollider;
    private MeshRenderer myMesh;


    public Transform pivot;

	void Start () {
        initial_pos = pivot.position;
        myMesh = GetComponent<MeshRenderer>();
        myMesh.enabled = false;
        myCollider = GetComponent<BoxCollider>();
        myCollider.enabled = false;
		StartCoroutine(Spawn());
        //Debug.Log ("new Rotation:" + target_rotationZ);


    }


	void Update () {
		switch (movement) 
		{
            case Movement.none:
                if(spawned)
                {

                    if (hitted)
                    {
                        pivot.Rotate(0, 0, -speed_Rotation * Time.deltaTime);

                        if (pivot.rotation.eulerAngles.z <= 270 && pivot.rotation.eulerAngles.z >= 10)
                        {
                            pivot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 270);
                            StartCoroutine(EliminarDiana());
                        }
                    }

                }
                
                break;

            case Movement.x:

                if (spawned)
                {
                    if (!hitted)
                    {
                        if (pivot.position.x < initial_pos.x + move_Translation && direction)
                        {
                            pivot.Translate(speed_Translation * Time.deltaTime, 0, 0);


                        }
                        else
                        {
                            direction = false;
                        }

                        if (pivot.position.x > initial_pos.x - move_Translation && !direction)
                        {
                            pivot.Translate(-speed_Translation * Time.deltaTime, 0, 0);

                        }
                        else
                        {
                            direction = true;
                        }
                    }
                    else
                    {

                        pivot.Rotate(0, 0, -speed_Rotation * Time.deltaTime);

                        if (pivot.rotation.eulerAngles.z <= 270 && pivot.rotation.eulerAngles.z >= 10)
                        {
                            pivot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 270);
                            StartCoroutine(EliminarDiana());
                        }

                    }

                }

                break;

            case Movement.y:

                if (spawned)
                {
                    if (!hitted)
                    {
                        if (pivot.position.y < initial_pos.y + move_Translation && direction)
                        {
                            pivot.Translate(0, speed_Translation * Time.deltaTime, 0);


                        }
                        else
                        {
                            direction = false;
                        }

                        if (pivot.position.y > initial_pos.y - move_Translation && !direction)
                        {
                            pivot.Translate(0, -speed_Translation * Time.deltaTime, 0);

                        }
                        else
                        {
                            direction = true;
                        }
                    }
                    else
                    {

                        pivot.Rotate(0, 0, -speed_Rotation * Time.deltaTime);

                        if (pivot.rotation.eulerAngles.z <= 270 && pivot.rotation.eulerAngles.z >= 10)
                        {
                            pivot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 270);
                            StartCoroutine(EliminarDiana());
                        }

                    }

                }

                break;

		    case Movement.z:

			    if (spawned) {
				    if (!hitted) 
				    {
					    if (pivot.position.z < initial_pos.z + move_Translation && direction) 
					    {
						    pivot.Translate (0, 0, speed_Translation * Time.deltaTime);


					    } 
					    else 
					    {
						    direction = false;
					    }

					    if (pivot.position.z > initial_pos.z - move_Translation && !direction) 
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

    public void Hitted()
    {
        hitted = true;
        if (puntuar)
        {
            score.text = (int.Parse(score.text) + 1).ToString();
            puntuar = false;
        }


    }

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(spawn_time);
        myMesh.enabled = true;
        myCollider.enabled = true;
        spawned = true;

	}

	IEnumerator EliminarDiana()
	{
        yield return new WaitForSeconds(5);
		Destroy (pivot.gameObject);
		Destroy(this.gameObject);

	}
}
