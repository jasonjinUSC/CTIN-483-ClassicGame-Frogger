using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FroggerController : MonoBehaviour {

    public float moveDistance;
	Vector3 moveDirection;
    Vector3 oldPosition;

    Animator animator;
    bool jumping;

    public GameObject FrogObject;

    //Collision
    List<GameObject> movingList;
    bool onMoving;
    bool onEnemy;
    bool onWater;
	AudioSource audio;
    bool frogDead;
	// Use this for initialization
	void Start () {
		moveDirection = Vector3.right;
        animator = GetComponent<Animator>();


        movingList = new List<GameObject>();
        onEnemy = false;
        onMoving = false;
        jumping = false;
        frogDead = false;

		audio = GetComponent<AudioSource>();
			
	}


		
	
	// Update is called once per frame
	void Update () {
        if(!frogDead)
        {
            Debug.Log("Moving " + onMoving + "    Enemy " + onEnemy);
        }
        if(frogDead)
        {
            if ((animator.GetCurrentAnimatorStateInfo(0).IsName("WaterDeath") || animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyDeath")) 
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Instantiate(FrogObject, new Vector3(0.4f, -1.04f, 0f), Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else if(onEnemy || (!onMoving && onWater))
        {
            KillFrog();
        }
        else if (jumping)
        {
            float moveFraction = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if(moveFraction >= 1)
            {
                moveFraction = 1;
            }
            transform.localPosition = oldPosition + moveDistance * moveFraction * moveDirection;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("FrogJump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                animator.SetBool("Jumping", false);
                jumping = false;
                if(onMoving)
                {
                    transform.SetParent(movingList[movingList.Count-1].transform);
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
					audio.Play();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    oldPosition = transform.position;
                    moveDirection = Vector3.down;
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    animator.SetBool("Jumping", true);
                    jumping = true;
                    transform.SetParent(null);
					audio.Play();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    oldPosition = transform.localPosition;
                    moveDirection = Vector3.left;
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    animator.SetBool("Jumping", true);
                    jumping = true;
					audio.Play();
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    oldPosition = transform.localPosition;
                    moveDirection = Vector3.right;
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                    animator.SetBool("Jumping", true);
                    jumping = true;
					audio.Play();
                }

            }
        }
	
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        KillOnTouch killTouchScript = collider.GetComponent<KillOnTouch>();
        MovingPlatform movingPlatformScript = collider.GetComponent<MovingPlatform>();
        WaterBehaviour water = collider.GetComponent<WaterBehaviour>();
        if (killTouchScript != null)
        {
            onEnemy = true;
        }
        if (water != null)
        {
            onWater = true;
        }
        if (movingPlatformScript != null)
        {
            onMoving = true;
            if(!movingList.Contains(collider.gameObject))
            {
                movingList.Add(collider.gameObject);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        KillOnTouch killTouchScript = collider.GetComponent<KillOnTouch>();
        MovingPlatform movingPlatformScript = collider.GetComponent<MovingPlatform>();
        WaterBehaviour water = collider.GetComponent<WaterBehaviour>();
        if (killTouchScript != null)
        {
            onEnemy = false;
        }
        if(water != null)
        {
            onWater = false;
        }
        if (movingPlatformScript != null)
        {
            movingList.Remove(collider.gameObject);
            if(movingList.Count == 0)
            {
                onMoving = false;
            }
        }
    }
    void KillFrog()
    {
        frogDead = true;
        animator.SetBool("Enemy", true);
        transform.SetParent(null);
    }
}
