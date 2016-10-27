using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		{
			var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

			transform.Rotate(0, x, 0);
			transform.Translate(0, 0, z);
		}
}
}





   // private void Update ()
  //  {
    //    transform.Translate(Vector3.forward * Input.GetAxis("RightJoystickY") * 3 * Time.deltaTime);
      //  transform.Translate(Vector3.right * Input.GetAxis("RightJoystickX") * 3 * Time.deltaTime);

        //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * 3 * Time.deltaTime);
     //   transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * 3 * Time.deltaTime);

   // }



