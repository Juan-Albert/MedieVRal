using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;
    public Transform[] arrowSpawns;
    public GameObject arrow;
    public GameObject particle;

    private int n_targets = 5;
    private int targetsDestroyed = 0;
    private int score = 0;

    

    private void Start()
    {
        StartCoroutine(SpawnArrows());
        
    }

    private void Update()
    {
        if (targetsDestroyed == n_targets)
        {
            GameManager.instance.CheckScore(5, score);
        }

    }

    public void IncreasePoints()
    {

        scoreUI.text = (int.Parse(scoreUI.text) + 1).ToString();
        score++;
    }

    public void Target_Destroyed()
    {
        targetsDestroyed++;
    }

    IEnumerator SpawnArrows()
    {
        foreach (Transform spawn in arrowSpawns)
        {
            GameObject warning = Instantiate(particle, spawn.transform.position, spawn.transform.rotation) as GameObject;
            yield return new WaitForSeconds(20);         
            Destroy(warning);
            Instantiate(arrow, spawn.transform.position, spawn.transform.rotation);
            
        }
        
    }
}
