using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCube : MonoBehaviour {
	public bool collisionEnabled = false;
	public bool isCorrectCube = false;


	private void OnCollisionEnter(Collision other) {
		if( isCorrectCube ) {
			Debug.Log("correct!"+gameObject.name);
		}
		else {
			Debug.Log("wrong!"+gameObject.name);
		}
	}
}
