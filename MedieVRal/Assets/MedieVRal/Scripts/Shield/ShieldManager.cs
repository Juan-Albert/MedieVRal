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
    public AudioClip arrowHorn;
    public AudioClip endLevel;

    private int score = 10;

    private bool end = false;


    private void Start()
    {
        StartCoroutine(SpawnArrows());
        StartCoroutine(GameTime());
        
    }

    Transform GetRandomInArray(Transform[] array)
    {
        return array[Random.Range(0, array.Length)];
    }

    public void DecreasePoints()
    {
        if (score > 0)
        {
            score--;
            scoreUI.text = (score).ToString();
        }
        
        
    }


    IEnumerator SpawnArrows()
    {
        while(!end)
        {
            SoundManager.instance.PlaySingle(arrowHorn);
            Transform spawn = GetRandomInArray(arrowSpawns);
            GameObject warning = Instantiate(particle, spawn.transform.position, spawn.transform.rotation) as GameObject;
            yield return new WaitForSeconds(5);         
            Destroy(warning);
            Instantiate(arrow, spawn.transform.position, spawn.transform.rotation);
            
        }
        
    }

    IEnumerator GameTime()
    {
        yield return new WaitForSeconds(80);
        end = true;
        SoundManager.instance.PlaySingle(endLevel);
        GameManager.instance.CheckScore(7, score);
    }
}
