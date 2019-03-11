using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AttentionEventArrow : MonoBehaviour {

	private bool hidden;
	private float hAngle;
	private float vAngle;

	public GameObject videoSphere;	
	public GameObject eyeLocation;

	// Use this for initialization
	void Start () {
		hidden = true;
	}
	
	// Update is called once per frame
	void Update () {
		var r = GetComponent<MeshRenderer> ();
		r.enabled = !hidden;

		var forward = new Vector3(0,0,1f);
		var up = new Vector3(0,1f,0f);

		var vectorToEyePosition = eyeLocation.transform.position;

		var horAngleBetweenArrowAndEyes = Vector2.SignedAngle (new Vector2 (transform.position.x,transform.position.z), new Vector2 (vectorToEyePosition.x,vectorToEyePosition.z));
		transform.RotateAround (new Vector3(0f,0f,0f), up, horAngleBetweenArrowAndEyes * -1f);



		/*
		var rotH = Quaternion.AngleAxis(hAngle,Vector3.up);
		var vectorToAttentionPoint = rotH * Vector3.forward;

		Debug.DrawRay (new Vector3(0f,0f,0f),vectorToAttentionPoint);


		//var horAngleBeteenEyesAndTargetPoint = Vector2.SignedAngle (new Vector2 (vectorToAttentionPoint.x,vectorToAttentionPoint.z), new Vector2 (vectorToEyePosition.x,vectorToEyePosition.z));

		Debug.Log (horAngleBetweenArrowAndEyes);

		// set arrow centre based on eye gaze
		//var angleFromEyeToMarker = Vector3.SignedAngle(vectorToAttentionPoint, eyeLocation.transform.position,up);
		// set direction based on direction to target
		var currentPosDegrees = Vector3.SignedAngle(forward, eyeLocation.transform.position,up);
		Debug.Log (currentPosDegrees);

		if (currentPosDegrees > hAngle) {
			//transform.Rotate (new Vector3 (180, 0, 0));
		}*/
	}

	public void PointTowards(float hAng, float vAng) {
		hidden = false;
		hAngle = hAng;
		vAngle = vAng;
	}

	public void Clear(){
		hidden = true;
	}

}
