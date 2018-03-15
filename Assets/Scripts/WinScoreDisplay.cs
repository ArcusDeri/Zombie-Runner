using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WinScoreDisplay : MonoBehaviour {

	public Text View;

	private float WinScore;

	// Use this for initialization
	void Start () {
		WinScore = PlayerPrefs.GetFloat ("LastScore");
		WinScore = Mathf.Round (WinScore * 100f) / 100f;

		UpdateHighScores ();
		SetTextMessage ();
	}

	void UpdateHighScores(){
		Highscores.SaveNewScore (WinScore);
	}

	void SetTextMessage(){
		View.text = WinScore.ToString() + " seconds.";
	}
}
