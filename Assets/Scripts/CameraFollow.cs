using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	public float cameraHeight = 2;
	public float cameraAngle = 45;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = target.transform.position;
		Vector3 cameraPos = new Vector3(targetPos.x, cameraHeight, targetPos.z);
		Vector3 targetAng = target.transform.eulerAngles;
		Vector3 cameraAng = new Vector3(cameraAngle, targetAng.y, 0);

		transform.position = Vector3.Lerp(transform.position, cameraPos, Time.deltaTime);
		transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, cameraAng, Time.deltaTime);
	}
}
