using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    float timeLimit = 32f;
    float time;

	// Use this for initialization
	void Start () {
        resetTime();
	
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        transform.localScale = new Vector3((timeLimit - time)/timeLimit, 1, 1);

        if(time > timeLimit)
        {
            GameObject.FindObjectOfType<FroggerController>().GetComponent<FroggerController>().KillFrog();
            resetTime();
        }
	
	}
    public int getTimeLeft()
    {
        return (int) timeLimit - (int)time;
    }

    public void resetTime()
    {
        time = 0;
    }
}
