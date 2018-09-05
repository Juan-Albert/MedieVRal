using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatapultManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;

    private int ammo = 8;
    private int ammoUsed = 0;
    private int score = 0;


    private void Update()
    {
        if (ammoUsed == ammo)
        {
            GameManager.instance.CheckScore(2, score);
        }
    }

    public void IncreasePoints(int newScore)
    {
        score += newScore;
        scoreUI.text = (score).ToString();
        Debug.Log("Se ha usado ammo");
    }

    public void UseAmmo()
    {
        ammoUsed++;
    }




}
