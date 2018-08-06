using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoustingManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;
    public GameObject horse;

    private int n_targets = 5;
    private int targetsDestroyed = 0;
    private int score = 0;
    private bool moving = true;
    private bool riding = true;

    private void Update()
    {
        if (targetsDestroyed == n_targets)
        {
            GameManager.instance.CheckScore(5, score);
        }

        if(horse.transform.position.x > 241f && moving)
        {
            horse.transform.Translate(0,0, 5f * Time.deltaTime);
        }
        else
        {
            moving = false;
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
}
