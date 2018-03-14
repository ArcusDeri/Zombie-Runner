using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Highscores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string filePath = Path.Combine (Application.streamingAssetsPath,"data.JSON");
		var dataInJSON = File.ReadAllText (filePath);
		var highscores = JsonUtility.FromJson<ScoreData> (dataInJSON);
		Debug.Log (highscores.Scores[0]);
		Debug.Log (highscores.Scores[1]);
	}

}
