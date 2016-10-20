using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    float leftBorder = -1.26f;
    float rightBorder = 1.26f;
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        if(transform.position.x > rightBorder)
        {
            transform.Translate(Vector3.left * 2.52f, Space.World);
        }
        if (transform.position.x < leftBorder)
        {
            transform.Translate(Vector3.right * 2.52f, Space.World);
        }
    }

    public void setSpeed(float s)
    {
        speed = s;
    }
}