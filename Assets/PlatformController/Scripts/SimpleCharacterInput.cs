using UnityEngine;
using System.Collections;

public class SimpleCharacterInput : RaycastCharacterInput
{

	void Update ()
	{
		jumpButtonHeld = false;
		jumpButtonDown = false;
		x = 0;
		y = 0;
		
		
		if (Input.GetKey("right") ) {
			x = 1f;
		} else if (Input.GetKey("left") ) {
			x = -1f;
		}
		
		
		// Shift to run
		if (Input.GetKey(KeyCode.LeftShift)) {
			x *= 4;
		}
		
		if (Input.GetKey("up") ) {
			y = 3;
		} else if (Input.GetKey("down") ) {
			y = -1;
		}
		
		if (Input.GetKey(KeyCode.Space) ) {
			jumpButtonHeld = true;
			if (Input.GetKeyDown(KeyCode.Space)) {
				jumpButtonDown = true;		
			} else {
				jumpButtonDown = false;		
			}
		} else {
			jumpButtonDown = false;
		}
	}
	
}

