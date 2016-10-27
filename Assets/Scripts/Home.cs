using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

    bool frogHome;
    Animator animator;
    public GameObject FrogObject;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("Reset");
        frogHome = false;
        gameObject.layer = 0;
    }

    void restartFrog()
    {
        if (!frogHome)
        {
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
