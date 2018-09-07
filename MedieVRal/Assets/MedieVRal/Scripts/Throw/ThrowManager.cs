﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;
    [Tooltip("Tiempo que tarda en aparecer el objeto.")]
    public float spawn_time = 5f;
    [Tooltip("Objetivos disponibles.")]
    public List<GameObject> objectives;
    public AudioClip endLevel;

    private int n_targets;
    private int targetsDestroyed = 0;
    private int score = 0;

    private bool scored = false;

    private void Start()
    {
        n_targets = objectives.Count;
        StartCoroutine(SpawnObjectives());
    }

    private void Update()
    {
        if(targetsDestroyed == n_targets && !scored)
        {
            SoundManager.instance.PlaySingle(endLevel);
            GameManager.instance.CheckScore(1, score);
            scored = true;
        }
    }

    private GameObject RandomPosition()
    {
        int randomIndex = Random.Range(0, objectives.Count);
        GameObject randomObjective = objectives[randomIndex];
        objectives.RemoveAt(randomIndex);
        return randomObjective;
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

    IEnumerator SpawnObjectives()
    {

        for (int i = 0; i < n_targets; i++)
        {
            yield return new WaitForSeconds(spawn_time);
            GameObject randomObjective = RandomPosition();
            randomObjective.SetActive(true);

        }
        
    }
}
