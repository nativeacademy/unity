using UnityEngine;
using System.Collections;

public class SnowManManeger : MonoBehaviour {
	
	//[SerializeField]
	//private GameObject _brokenParticle;
	
	
	private ScoreManeger _scoreManeger;
	private StageManeger _stageManeger;
	
	// Use this for initialization
	void Start () {
		GameObject stageRoot = transform.parent.parent.gameObject;
		_scoreManeger = stageRoot.GetComponentInChildren<ScoreManeger>();
		_stageManeger = stageRoot.GetComponent<StageManeger>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision collisionInfo) {
		//Instantiate(_brokenParticle, transform.position, _brokenParticle.transform.rotation);
		
		// test
		_scoreManeger.AddScore(10);
		_stageManeger.StageEndCheck();
		
		Destroy(gameObject);
	}
}
