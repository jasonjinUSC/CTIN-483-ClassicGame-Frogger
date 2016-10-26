using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
  

    private void Update ()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("RightJoystickY") * 3 * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("RightJoystickX") * 3 * Time.deltaTime);

        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * 3 * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * 3 * Time.deltaTime);

    }

}


