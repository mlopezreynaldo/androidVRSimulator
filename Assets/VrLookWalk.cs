using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrLookWalk : MonoBehaviour {

	public Transform vrCamera;
	public float toggleAngle = 30f;
	public float speed = 3.0f;
	public bool moveFordward;

	private CharacterController cc;

	// Use this for initialization
	void Start () {

		cc = GetComponent<CharacterController> ();


	}
	
	// Update is called once per frame
	void Update () {

		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f) {

			moveFordward = true;


		} else {

			moveFordward = false;

		}

		if (moveFordward == true) {

			Vector3 fordward = vrCamera.TransformDirection (Vector3.forward);
			cc.SimpleMove (fordward * speed);

		}

	}
}
