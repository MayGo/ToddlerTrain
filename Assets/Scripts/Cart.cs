using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {

	public GameObject cartExploded;
	private GameManager gameManager;


	// Use this for initialization
	void Start (){
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnMouseDown() {
		Debug.Log ("Clicked Crate ");
		Transform crateTransform = transform.Find ("crate");


		if (crateTransform == null) {// Second click on cart
			removeCart (gameObject);
		} else {
			GameObject crate = crateTransform.gameObject;

			removeCrate (crate);

			createLetter (crate);
		}
	}

	void createLetter(GameObject addToNearObject){
		GameObject letter = new GameObject("letter");
		letter.transform.position = addToNearObject.transform.position;
		letter.transform.rotation = addToNearObject.transform.rotation;

		SpriteRenderer renderer = letter.AddComponent<SpriteRenderer>();
		letter.AddComponent<DestroyOffscreen>();
		Sprite sprite = gameManager.nextLetter ();
		renderer.sprite = sprite;
		renderer.sortingLayerName = "Items";

		letter.AddComponent<Rigidbody2D>();
		letter.AddComponent<PolygonCollider2D>();
	}

	void removeCrate(GameObject crate){
		Instantiate(cartExploded, crate.transform.position, Quaternion.identity);
		Destroy (crate);
	}

	void removeCart(GameObject cart){
		GameObject go = GameObject.Find("train_body");
		CartManager cartsScript = (CartManager) go.GetComponent(typeof(CartManager));
		cartsScript.removeCart(cart);
	}
	
}
