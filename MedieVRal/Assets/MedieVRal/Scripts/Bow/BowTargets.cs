using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowTargets : MonoBehaviour {

    [Tooltip("Velocidad con la que se translada el objeto.")]
    public float speed_Translation = 5f;
    [Tooltip("Velocidad con la que rota el objeto.")]
    public float speed_Rotation = 5f;
    [Tooltip("Distancia que se mueve el objeto.")]
    public float move_Translation = 7f;
    [Tooltip("Tipo de movimiento que va a realizar la diana.")]
    public Movement movement;
    [Tooltip("Punto de Rotación de la diana.")]
    public Transform pivot;
    public BowManager bowManager;

    //Posición inicial de la diana.
    private Vector3 initial_pos;

    //Variable booleana que utilizamos para asignar la dirección de la diana.
    private bool direction = true;
    //Variable booleana que utilizamos para saber si se ha alcanzado la diana con el objeto lanzable.
    private bool hitted = false;
    //Variable booleana para puntuar cuando se ha alcanzado con el objeto lanzable.
    private bool puntuar = true;





    void Start()
    {
        StartCoroutine(AutoDestruccion());
        initial_pos = pivot.position;
        //Debug.Log ("new Rotation:" + target_rotationZ);


    }


    void Update()
    {
        switch (movement)
        {
            case Movement.none:

                

                break;

            case Movement.x:


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
                    }

                }



                break;

            case Movement.y:

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
                    }

                }

                break;

            case Movement.z:

                if (!hitted)
                {
                    if (pivot.position.z < initial_pos.z + move_Translation && direction)
                    {
                        pivot.Translate(0, 0, speed_Translation * Time.deltaTime);


                    }
                    else
                    {
                        direction = false;
                    }

                    if (pivot.position.z > initial_pos.z - move_Translation && !direction)
                    {
                        pivot.Translate(0, 0, -speed_Translation * Time.deltaTime);

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
            Debug.Log("Hitted");
            bowManager.IncreasePoints();
            puntuar = false;
        }


    }


    IEnumerator AutoDestruccion()
    {
        yield return new WaitForSeconds(30);
        Debug.Log("Destuida");
        bowManager.Target_Destroyed();
        Destroy(pivot.gameObject);

    }
}
