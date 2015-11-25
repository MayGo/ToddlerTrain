using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject targetObject;

	private float offset;
	
	// Use this for initialization
	void Start () {

		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		float targetWidth = 3F;
		offset = height * 0.65F - targetWidth;
	
	}
	
	// Update is called once per frame
	void Update () {
		float targetObjectX = targetObject.transform.position.x;
		
		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX - offset;
		//Debug.Log (newCameraPosition);
		transform.position = newCameraPosition;    	
	}
}
