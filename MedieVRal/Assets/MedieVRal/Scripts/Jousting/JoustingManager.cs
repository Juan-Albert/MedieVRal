using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoustingManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;
    public GameObject horse;
    public AudioClip gallop;
    public AudioClip endLevel;

    private int score = 0;
    private bool moving = true;

    private bool scored = false;

    private void Start()
    {
        SoundManager.instance.PlaySingle(gallop);
    }

    private void Update()
    {

        if(horse.transform.position.x > 241f && moving)
        {
            horse.transform.Translate(0,0, 7.5f * Time.deltaTime);
        }
        else
        {
            moving = false;
        }

        if(!moving && !scored)
        {
            SoundManager.instance.PlaySingle(endLevel);
            GameManager.instance.CheckScore(4, score);
            scored = true;
        }
    }

    public void IncreasePoints()
    {

        scoreUI.text = (int.Parse(scoreUI.text) + 1).ToString();
        score++;
    }

    
}
