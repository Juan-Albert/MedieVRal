using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ClimbingManager : MonoBehaviour {

    [Tooltip("Objeto donde se va a almacenar la puntuación del jugador.")]
    public Text scoreUI;
    [Tooltip("Posición de las bombas.")]
    public GameObject[] bombSlots;

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
        yield return new WaitForSeconds(30);
        
        GameManager.instance.CheckScore(6, score);
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
                }
            }
        }
        

    }
}
