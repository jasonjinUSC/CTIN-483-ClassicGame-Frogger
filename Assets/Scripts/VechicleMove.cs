using UnityEngine;
using System.Collections;

public class VechicleMove : MonoBehaviour {

	 
	float delta = 0.5f;  // Amount to move left and right from the start point
	float speed = 1f; 
	private Vector3 startPos;

	void Start () {
		startPos = transform.position;
	}

	void Update () {
		Vector3 v = startPos;
		v.x += delta * Mathf.Sin (Time.time * speed);
		transform.position = v;
	}
}
