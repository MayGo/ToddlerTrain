using UnityEngine;
using System.Collections;

public class CrateExplosion : MonoBehaviour {

	
	void Start() {
		Rigidbody2D rb= GetComponent<Rigidbody2D>();
		Vector2 force = new Vector2 (-2, 5);
		rb.velocity = force;
		//rb.AddForce(force, ForceMode2D.Impulse);
		rb.angularVelocity = 97;

	}

}
