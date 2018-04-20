/*
 * Script Spawner.cs
 * Autor: Juan Alberto Martínez López
 * Fecha: 13/3/2018
 * Descripción: Script aplicado a objetos que pueden generar Prefabs de otros objetos.
*/

namespace VRTK
{
    using UnityEngine;

    public class Spawner : MonoBehaviour
    {
        [Tooltip("Objeto que va a generar el spawn.")]
        public GameObject prefab;
        [Tooltip("Delay con el que genera el objeto.")]
        public float spawnDelay = 1f;

        //Tiempo de delay antes poder generar el objeto
        private float spawnDelayTimer = 0f;

        private void Start()
        {
            spawnDelayTimer = 0f;
        }
        //Cuando se pulse el botón grip.
        private void OnTriggerStay(Collider collider)
        {
            //Se obtiene el controlador que ha interactuado con el spawner.
            VRTK_InteractGrab grabbingController = (collider.gameObject.GetComponent<VRTK_InteractGrab>() ? collider.gameObject.GetComponent<VRTK_InteractGrab>() : collider.gameObject.GetComponentInParent<VRTK_InteractGrab>());
            //Comprobamos si ese controlador puede agarrar un objeto y que haya pasado el tiempo de spawn.
            if (CanGrab(grabbingController) &&  Time.time >= spawnDelayTimer)
            {
                //Se instancia el nuevo objeto y se fuerza el agarrado con el controlador.
                GameObject newPrefab = Instantiate(prefab);
                newPrefab.name = "Clone";
                grabbingController.GetComponent<VRTK_InteractTouch>().ForceTouch(newPrefab);
                grabbingController.AttemptGrab();
                spawnDelayTimer = Time.time + spawnDelay;
            }
        }
        //Devuelve si el controlador puede agarrar.
        private bool CanGrab(VRTK_InteractGrab grabbingController)
        {
            return (grabbingController && grabbingController.GetGrabbedObject() == null && grabbingController.IsGrabButtonPressed());
        }
        
    }
}