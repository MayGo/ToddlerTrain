using UnityEngine;
using System.Collections;

public class DestroyOffscreen : MonoBehaviour {

	void OnBecameInvisible()
	{
		Debug.Log ("Destoring itself");
		DestroyObject(gameObject);
	}
}
