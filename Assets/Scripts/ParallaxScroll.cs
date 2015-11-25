using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxScroll : MonoBehaviour {
	public List<Renderer> layers;
	public List<float> layerSpeeds;
	
	Camera cam;
	// Use this for initialization
	void Start () {
	 cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		float cameraPosX = cam.GetComponent<Transform>().position.x;

		for(int i = 0; i < layers.Count; i++){
			float layerOffset = cameraPosX * layerSpeeds[i]; 
			layers[i].material.mainTextureOffset = new Vector2(layerOffset, 0);
		}

	}
}
