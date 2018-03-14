using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WinScoreDisplay : MonoBehaviour {

	public Text View;

	// Use this for initialization
	void Start () {
		var winScore = PlayerPrefs.GetFloat ("LastScore");
		View.text = winScore.ToString() + " seconds.";

		string filePath = Path.Combine (Application.streamingAssetsPath,"data.JSON");

		var scoreData = new ScoreData ();
		scoreData.Scores.Add (winScore);
		var highscores = JsonUtility.ToJson (scoreData,true);
		File.WriteAllText (filePath, highscores);
		Debug.Log (highscores.ToString());
	}
}
