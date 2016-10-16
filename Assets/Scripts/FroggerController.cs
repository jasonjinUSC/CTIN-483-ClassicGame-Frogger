using UnityEngine;
using System.Collections;

public class FroggerController : MonoBehaviour {

    public float moveDistance;
	Vector3 moveDirection;
    Vector3 oldPosition;

    Animator animator;
    bool jumping;

    //Collision
    bool onMoving;
    bool onEnemy;
    GameObject movingParent;
	// Use this for initialization
	void Start () {
		moveDirection = Vector3.right;
        animator = GetComponent<Animator>();
        jumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Moving " + onMoving + "    Enemy " + onEnemy);
        if (jumping)
        {
            float moveFraction = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if(moveFraction >= 1)
            {
                moveFraction = 1;
            }
            transform.position = oldPosition + moveDistance * moveFraction * moveDirection;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("FrogJump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                animator.SetBool("Jumping", false);
                jumping = false;
                if(onMoving)
                {
                    transform.SetParent(movingParent.transform);
                }
            }
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("FrogIdle"))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    oldPosition = transform.position;
                    moveDirection = Vector3.up;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                    transform.SetParent(null);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    oldPosition = transform.position;
                    moveDirection = Vector3.down;
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                    transform.SetParent(null);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    oldPosition = transform.position;
                    moveDirection = Vector3.left;
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    oldPosition = transform.position;
                    moveDirection = Vector3.right;
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                }

            }
        }
	
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        KillOnTouch killTouchScript = collider.GetComponent<KillOnTouch>();
        MovingPlatform movingPlatformScript = collider.GetComponent<MovingPlatform>();
        if(killTouchScript != null)
        {
            onEnemy = true;
        }
        if(movingPlatformScript != null)
        {
            onMoving = true;
            movingParent = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        KillOnTouch killTouchScript = collider.GetComponent<KillOnTouch>();
        MovingPlatform movingPlatformScript = collider.GetComponent<MovingPlatform>();
        if (killTouchScript != null)
        {
            onEnemy = false;
        }
        if (movingPlatformScript != null)
        {
            onMoving = false;
        }
    }
}
