using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;
    [Tooltip("Tiempo que tarda en aparecer el objeto.")]
    public float spawn_time = 7f;
    [Tooltip("Objetivos disponibles.")]
    public List<GameObject> targets;
    public AudioClip endLevel;

    private int n_targets;
    private int targetsDestroyed = 0;
    private int score = 0;

    private bool scored = false;

    private void Start()
    {
        n_targets = targets.Count;
        StartCoroutine(SpawnObjectives());
    }

    private void Update()
    {
        if (targetsDestroyed == n_targets && !scored)
        {
            SoundManager.instance.PlaySingle(endLevel);
            GameManager.instance.CheckScore(3, score);
            scored = true;
        }
    }

    private GameObject RandomPosition()
    {
        int randomIndex = Random.Range(0, targets.Count);
        GameObject randomObjective = targets[randomIndex];
        targets.RemoveAt(randomIndex);
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
