using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FrogLifeController : MonoBehaviour {

    public List<SpriteRenderer> lives;
    int numLives;
    HomeManager homeManager;
    Score score;
	// Use this for initialization
	void Start () {
        numLives = 3;
        homeManager = GameObject.FindObjectOfType<HomeManager>().GetComponent<HomeManager>();
        score = GameObject.FindObjectOfType<Score>().GetComponent<Score>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void loseLives()
    {
        numLives--;
        if(numLives > 0)
        {
            lives[numLives - 1].enabled = false;
        }
        else
        {
            reset();
        }
    }

    void reset()
    {
        homeManager.resetAllHomes();
        score.resetAndChangeHigh();
        numLives = 3;
        for(int i = 0; i < lives.Count; i++)
        {
            lives[i].enabled = true;
        }
    }
}
