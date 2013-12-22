using UnityEngine;
using System.Collections;

public class ScoreManeger : MonoBehaviour {
	
	private int _score;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddScore(int val) {
		_score += val;
		guiText.text = "Score : " + _score;
	}
	
	public void InitScore() {
		_score = 0;
		guiText.text = "Score : " + _score;
	}
}
