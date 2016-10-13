using UnityEngine;
using System.Collections;

public class FroggerController : MonoBehaviour {

	public float moveSpeed;
	private Vector3 moveDirection;
	public float turnSpeed;

    Animator animator;
    bool jumping;
	// Use this for initialization
	void Start () {
		moveDirection = Vector3.right;
        animator = GetComponent<Animator>();
        jumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (jumping)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("FrogJump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                Debug.Log("End " + Time.time);
                animator.SetBool("Jumping", false);
                jumping = false;
            }
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("FrogIdle"))
            { 
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("Start " + Time.time);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                }

            }
        }
	
	}
}
