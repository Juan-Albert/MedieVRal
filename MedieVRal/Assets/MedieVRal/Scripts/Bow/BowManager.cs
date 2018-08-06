using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;

    private int n_targets = 5;
    private int targetsDestroyed = 0;
    private int score = 0;

    private void Update()
    {
        if (targetsDestroyed == n_targets)
        {
            //GameManager.instance.CheckScore(5, score);
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
