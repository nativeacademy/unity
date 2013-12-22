using UnityEngine;
using System.Collections;

public class ItemManeger : MonoBehaviour {
	
	private ScoreManeger _scoreManeger;
	
	// Use this for initialization
	void Start () {
		GameObject stageRoot = transform.parent.parent.gameObject;
		_scoreManeger = stageRoot.GetComponentInChildren<ScoreManeger>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
			// test
			_scoreManeger.AddScore(100);

			Destroy(gameObject);
	}
}
