﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ClimbingManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;
    [Tooltip("Textura de explosión.")]
    public GameObject explosion;
    [Tooltip("Posición de las bombas.")]
    public GameObject[] bombSlots;
    public AudioClip endLevel;

    private int n_targets;
    private int placed = 0;
    private int score = 0;

    private bool timeUp = false;

    private void Start()
    {
        n_targets = bombSlots.Length;
        StartCoroutine(GameTime());
    }



    public int BombPlaced()
    {
        int placed = 0;
        foreach (GameObject slot in bombSlots)
        {
            if (slot.GetComponent<SlotBomb>().IsPlaced())
            {
                placed++;
            }
        }
        return placed;
    }

    public void IncreasePoints()
    {
        scoreUI.text = (int.Parse(scoreUI.text) + 1).ToString();
        score++;
        placed++;
    }


    IEnumerator GameTime()
    {
        yield return new WaitForSeconds(240);
        SoundManager.instance.PlaySingle(endLevel);
        GameManager.instance.CheckScore(6, score);
        yield return new WaitForSeconds(3);
        if (placed == n_targets)
        {
            foreach (GameObject slot in bombSlots)
            {
                slot.GetComponent<SlotBomb>().Detonate();
            }
            Destroy(bombSlots[0].transform.parent.parent.gameObject);
        }
        else
        {
            foreach (GameObject slot in bombSlots)
            {
                if (slot.GetComponent<SlotBomb>().IsPlaced())
                {
                    slot.GetComponent<SlotBomb>().Detonate();
                    Instantiate(explosion, slot.transform.position, slot.transform.rotation);
                }
            }
        }
        

    }
}
