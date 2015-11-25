using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameManager : MonoBehaviour {

	private Sprite[] letters ;
	private int currentItemIndex;
	private GameObject endScreen;
	private float lastItemOpenedAt;

	[HideInInspector]
	public static GameState currentGameState = GameState.Playing;

	// Use this for initialization
	void Start () {
		Debug.Log ("Starting game");
		Time.timeScale = 1;

		currentGameState = GameState.Playing;
		letters = Resources.LoadAll<Sprite> ("letters");
		currentItemIndex = 0;
		endScreen = GameObject.Find("End");
		endScreen.SetActive(false);
	}

	public Sprite nextLetter(){
		lastItemOpenedAt = Time.time;
		if (isLastIndex()) {
			Debug.Log ("Out of letters");
			return null;
		}
		Sprite sprite = letters[currentItemIndex];
		currentItemIndex++;
		return sprite;

	}

	bool isLastIndex(){
		return (currentItemIndex == letters.Length - 1);
	}
	
	public void restartLevel(){
		Application.LoadLevel("ABCTrain");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (currentGameState);
		switch (currentGameState){
	
			case GameState.Playing:
				if (isLastIndex()) {
					currentGameState = GameState.OutOfItems;
				}

				break;
			case GameState.OutOfItems:
				if(Time.time - lastItemOpenedAt > 5f){
					currentGameState = GameState.End;
				}
				break;

			case GameState.End:
				endScreen.SetActive(true);
				Time.timeScale = 0;

				break;
			default:
				break;
		}
	}
}
