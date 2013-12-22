using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class StageManeger : MonoBehaviour {
	
	private bool _isStageEnd;
	private GameObject _stage;

	// Use this for initialization
	void Start () {
		CreateStage ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StageEndCheck() {
		if (GetComponentsInChildren<SnowManManeger>().Length == 1) {
			_isStageEnd = true;
			HOTween.To(_stage.transform, 3, new TweenParms()
				.Prop("Position", new Vector3(0, 6, 0))
				.Ease(EaseType.EaseInOutQuad)
			);
			Debug.Log("##### END");
		} else {
			_isStageEnd = false;
			Debug.Log("##### not END");
		}
	}

	private void CreateStage() {
		_stage = (GameObject)Instantiate (Resources.Load("Prefabs/Stage/TestStage1"), new Vector3(15f, 3.5f, 0f), Quaternion.identity);
		_stage.transform.parent = transform;
	}
}
