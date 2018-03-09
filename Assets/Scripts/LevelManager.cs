using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void OnClickStart(){
		Debug.Log ("Load Game scene.");
		SceneManager.LoadScene ("Game");
	}

	public void OnClickMainMenu(){
		Debug.Log ("Load Start scene.");
		SceneManager.LoadScene("Start");
	}

	public void OnClickHighScores(){
		Debug.Log ("Load Highscores scene.");
		SceneManager.LoadScene ("Highscores");
	}

	public void OnClickExit(){
		Debug.Log ("Exiting the game.");
		Application.Quit();
	}
}
