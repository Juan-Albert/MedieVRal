using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour {

    public Text throwing;
    public Text catapult;
    public Text shooting;
    public Text jousting;
    public Text bow;
    public Text climbing;
    public Text shield;


    private void Start()
    {
        
        throwing.text = GameManager.instance.GetPoints(1).ToString();
        catapult.text = GameManager.instance.GetPoints(2).ToString();
        shooting.text = GameManager.instance.GetPoints(3).ToString();
        jousting.text = GameManager.instance.GetPoints(4).ToString();
        bow.text = GameManager.instance.GetPoints(5).ToString();
        climbing.text = GameManager.instance.GetPoints(6).ToString();
        shield.text = GameManager.instance.GetPoints(7).ToString();
    }

    public void LoadSelectLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
