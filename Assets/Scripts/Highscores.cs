using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class Highscores : MonoBehaviour {

	private static string FilePath;

	// Use this for initialization
	void Start () {
		FilePath = Path.Combine (Application.streamingAssetsPath,"data.JSON");
		UpdateScoreList ();
	}

	public static ScoreData LoadScores(){
		FilePath = Path.Combine (Application.streamingAssetsPath,"data.JSON");
		var jsonHighscores = File.ReadAllText (FilePath);
		var scoreData = JsonUtility.FromJson<ScoreData> (jsonHighscores);
		if (scoreData == null)
			scoreData = new ScoreData ();
		return scoreData;
	}

	public static void SaveNewScore(float score){
		var highScores = LoadScores ();
		highScores.Scores.Add (score);
		var roundScores = FormatScoreData(highScores);
		roundScores = TrimScoreList (roundScores);

		var highScoresJson = JsonUtility.ToJson (roundScores);
		FilePath = Path.Combine (Application.streamingAssetsPath,"data.JSON");
		File.WriteAllText (FilePath, highScoresJson);
	}

	private static ScoreData FormatScoreData(ScoreData scores){
		int i = 0;
		while (i < scores.Scores.Count) {
			scores.Scores[i] = Mathf.Round (scores.Scores[i] * 100f) / 100f;
			i++;
		}
		scores.Scores.Sort ();
		return scores;
	}

	private static ScoreData TrimScoreList(ScoreData data){
		if (data.Scores.Count > 9) {
			data.Scores = data.Scores.GetRange (0, 10);
		}
		return data;
	}

	private void UpdateScoreList(){
		var scoreList = GameObject.Find ("ScoreList");
		var positions = scoreList.GetComponentsInChildren<Text> ();
		var scores = FormatScoreData(LoadScores ());
		for (int i = 0; i < scores.Scores.Count; i++) {
			positions [i].text = (i + 1).ToString() + "." + " " + scores.Scores[i].ToString() + " s.";
		}
	}
}
