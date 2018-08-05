using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private int throwPoints = 0;
    private int catapultPoints = 0;
    private int shootingPoints = 0;
    private int bowPoints = 0;
    private int joustingPoints = 0;
    private int climbingPoints = 0;
    private int shieldPoints = 0;

    private void Awake()
    {
        if(GameManager.instance == null)
        {
            GameManager.instance = this;

        }
        else if(GameManager.instance !=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void CheckScore(int game, int points)
    {
        switch (game)
        {
            case 1:
                if(points > throwPoints)
                {
                    throwPoints = points;
                    Debug.Log("exito");
                }
                break;

            case 2:
                if (points > catapultPoints)
                {
                    catapultPoints = points;
                    Debug.Log("exito");
                }
                break;

            case 3:
                if (points > shootingPoints)
                {
                    shootingPoints = points;
                    Debug.Log("exito");
                }
                break;

            case 4:
                if (points > bowPoints)
                {
                    bowPoints = points;
                    Debug.Log("exito");
                }
                break;

            case 5:
                if (points > joustingPoints)
                {
                    joustingPoints = points;
                    Debug.Log("exito");
                }
                break;

            case 6:
                if (points > climbingPoints)
                {
                    climbingPoints = points;
                    Debug.Log("exito");
                }
                break;

            case 7:
                if (points > shieldPoints)
                {
                    shieldPoints = points;
                    Debug.Log("exito");
                }
                break;

            default:
                break;
        }
    }
}
