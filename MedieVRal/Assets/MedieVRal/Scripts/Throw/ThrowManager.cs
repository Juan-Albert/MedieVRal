using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowManager : MonoBehaviour {

    private int n_targets = 5;
    private int targetsDestroyed = 0;
    private int score = 0;

    private void Update()
    {
        if(targetsDestroyed == n_targets)
        {
            GameManager.instance.CheckScore(1, score);
        }
    }

    public void IncreasePoints()
    {
        score++;
    }

    public void Target_Destroyed()
    {
        targetsDestroyed++;
    }
}
