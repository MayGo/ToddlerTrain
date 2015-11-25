using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {

	public float thrust = 10.0f;
	public float maxSpeed = 200f;
	private Vector2 thrustVector;
	private Rigidbody2D train;

	// Use this for initialization
	void Start () {
		thrustVector = new Vector2 (thrust, 0f);
		train = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		Debug.Log("Siin");
		float currentSpeed = train.velocity.magnitude;
		Debug.Log(currentSpeed);
		if(currentSpeed > maxSpeed)
		{
			Debug.Log(train.velocity.normalized);
			train.velocity = train.velocity.normalized * maxSpeed;
		}
		train.AddForce(thrustVector);
	}
}
