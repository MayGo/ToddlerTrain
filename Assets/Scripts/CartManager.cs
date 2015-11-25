using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CartManager : MonoBehaviour {

	public GameObject cartPrefab;

	public GameObject lastConnectedObj;

	private GameObject trainBody;
	private List<GameObject> cartsToRemove = new List<GameObject>();

	private int i = 0;

	// Use this for initialization
	void Start () {
		trainBody = lastConnectedObj;
		addCarts ();

	}

	void addCarts(){
		i = 0;
		lastConnectedObj = trainBody;
		addCart ();
		addCart ();
		addCart ();
		addCart ();
	}

	void addCart(){
		float cartWidth = 2.62F;
		Vector3 diff = new Vector3 (-cartWidth, 0F, 0);
		
		GameObject cart = (GameObject)Instantiate(cartPrefab, lastConnectedObj.transform.position + diff, Quaternion.identity);
		GameObject cartBody = cart.transform.Find ("cart_base_with_crate").gameObject;
		cartsToRemove.Add(cartBody);
		HingeJoint2D hingeJoint = cartBody.GetComponent<HingeJoint2D>(); 
		Vector2 hingeAnchor = hingeJoint.connectedAnchor;
		if (i == 0) {//Train connects differently
			hingeAnchor.y = -0.5F;
			hingeAnchor.x = -1.4F;
			hingeJoint.connectedAnchor = hingeAnchor;
			//sDebug.Log (".........");
		}
		i++;
		Rigidbody2D trainBody = lastConnectedObj.GetComponent<Rigidbody2D>();
		hingeJoint.connectedBody = trainBody; 
		lastConnectedObj = cartBody;
		//Debug.Log (trainBody);
		///Debug.Log (hingeJoint);
	}
	public void removeCart(GameObject cart){
		i--;
		Debug.Log ("removing cart");
		//Destroy (cart, 5);



		destroyCart (cart);
		HingeJoint2D hingeJoint = cart.GetComponent<HingeJoint2D>();
	
		if(hingeJoint.connectedBody.name == "train_body") {
			Debug.Log ("Creating new carts");
			removeAllCarts();
			//addCarts ();
			//Invoke("removeAllCarts", 2);
			Invoke("addCarts", 4);
		}
	}

	void removeAllCarts(){

		foreach (GameObject cart in cartsToRemove) {
			destroyCart (cart);
		}
		cartsToRemove.Clear ();
	}

	 void destroyCart(GameObject cart){
		Rigidbody2D rb = cart.GetComponent<Rigidbody2D>();
		Destroy(rb.GetComponent<HingeJoint2D>());
		Destroy(rb.GetComponent<Cart>());
		Vector2 force = new Vector2 (-10, 20);
		rb.velocity = force;
		//rb.AddForce(force, ForceMode2D.Impulse);
		rb.angularVelocity = 97;
		
		WheelJoint2D[] wheelJoints = rb.GetComponents<WheelJoint2D>();
		foreach (WheelJoint2D joint in wheelJoints) {
			Destroy(joint, 0.1F);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
