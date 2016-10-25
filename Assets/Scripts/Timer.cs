using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public Sprite[] sprites; // 50.13 second per frame (fake version)
	//32 seconds (original) 
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	
	}
	
	// Update is called once per frame
	void Update () {

		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;
		spriteRenderer.sprite = sprites[ index ];
	
	}
}
