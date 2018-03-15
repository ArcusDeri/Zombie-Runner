using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Highscores : MonoBehaviour {

	private static string FilePath = Path.Combine (Application.streamingAssetsPath,"data.JSON");

	// Use this for initialization
	void Start () {
	}

	public static ScoreData LoadScores(){
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
}
