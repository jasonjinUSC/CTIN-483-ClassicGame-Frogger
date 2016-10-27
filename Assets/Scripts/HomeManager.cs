using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeManager : MonoBehaviour {

    public List<Home> frogHomes;
    Score score;
	// Use this for initialization
	void Start () {
        score = GameObject.FindObjectOfType<Score>().GetComponent<Score>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(checkAllHome())
        {
            score.addScore(1000);
            resetAllHomes();
        }
	}
    public void resetAllHomes()
    {
        for (int i = 0; i < frogHomes.Count; i++)
        {
            frogHomes[i].resetHome();
        }
    }
    bool checkAllHome()
    {
        for(int i = 0; i < frogHomes.Count; i++)
        {
            if(!frogHomes[i].isFrogHome())
            {
                return false;
            }
        }
        return true;
    }
}
