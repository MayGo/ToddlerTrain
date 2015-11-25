using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadAbcTrainLevel(){
		Application.LoadLevel("ABCTrain");
	}

	public void loadMenu(){
		Application.LoadLevel("Menu");
	}
	
	public void quitGame(){
		Application.Quit();
	}
}
