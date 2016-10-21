using UnityEngine;
using System.Collections;

public class Turtle : MonoBehaviour {
    public bool isFastSink;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("FastSink", isFastSink);
	}
	
	// Update is called once per frame
	void Update () {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("TurtleSinkSlow") && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.6f)
        {
            gameObject.layer = 8;
        }
        else
        {
            gameObject.layer = 0; ;
        }

    }
}
