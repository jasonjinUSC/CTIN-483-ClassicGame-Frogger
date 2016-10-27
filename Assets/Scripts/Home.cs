using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

    bool frogHome;
    Animator animator;
    public GameObject FrogObject;
    Score score;
    Timer time;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        score = GameObject.FindObjectOfType<Score>().GetComponent<Score>();
        time = GameObject.FindObjectOfType<Timer>().GetComponent<Timer>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(transform.childCount > 0)
        {
            restartFrog();
        }
	}

    public bool isFrogHome()
    {
        return frogHome;
    }

    public void resetHome()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("HomeFrog"))
        {
            animator.SetTrigger("Reset");

        }
        frogHome = false;
        gameObject.layer = 0;
    }

    void restartFrog()
    {
        if (!frogHome)
        {
            score.addScore(time.getTimeLeft() * 10);
            time.resetTime();
            animator.SetTrigger("GetFrog");
            frogHome = true;
            gameObject.layer = 8;
            Destroy(transform.GetChild(0).gameObject);
            Instantiate(FrogObject, new Vector3(0.07f, -1.05f, 0f), Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        /*
        if(collider.GetComponent<FroggerController>() != null)
        {
            if (!frogHome)
            {
                animator.SetTrigger("GetFrog");
                frogHome = true;
                gameObject.layer = 8;
                Destroy(collider.gameObject);
                Instantiate(FrogObject, new Vector3(0.07f, -1.05f, 0f), Quaternion.identity);
            }
        }
        */
    }
}
