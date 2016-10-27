using UnityEngine;
using System.Collections;

public class Turtle : MonoBehaviour {
    public bool sinking;
    public bool isFastSink;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        if(sinking)
        {
            if(isFastSink)
            {

                animator.SetBool("FastSink", true);
            }
            else
            {
                animator.SetBool("SlowSink", true);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if ((animator.GetCurrentAnimatorStateInfo(0).IsName("TurtleSinkSlow") || animator.GetCurrentAnimatorStateInfo(0).IsName("TurtleSinkFast")) && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.6f)
        {
            gameObject.layer = 8;
        }
        else
        {
            gameObject.layer = 0;
        }

    }
}
