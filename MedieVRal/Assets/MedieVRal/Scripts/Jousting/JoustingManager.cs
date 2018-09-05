using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoustingManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;
    public GameObject horse;

    private int score = 0;
    private bool moving = true;

    private void Update()
    {

        if(horse.transform.position.x > 241f && moving)
        {
            horse.transform.Translate(0,0, 5f * Time.deltaTime);
        }
        else
        {
            moving = false;
            GameManager.instance.CheckScore(4, score);
        }
    }

    public void IncreasePoints()
    {

        scoreUI.text = (int.Parse(scoreUI.text) + 1).ToString();
        score++;
    }

    
}
