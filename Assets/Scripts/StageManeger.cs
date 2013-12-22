using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class StageManeger : MonoBehaviour {
	[SerializeField]
	private GameObject _count;
	[SerializeField]
	private GameObject _avatar;

	private AnimController _animController;
	private bool _isStageClear;
	public bool IsStageClear {
		get {return _isStageClear; }
	}
	private GameObject _stage;
	private CountManeger _countManeger;

	// Use this for initialization
	void Start () {
		_animController = _avatar.GetComponent<AnimController> ();
		_countManeger = _count.GetComponent<CountManeger> ();
		CreateStage ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StageEndCheck() {
		if (GetComponentsInChildren<SnowManManeger>().Length == 1) {
			_isStageClear = true;
			_animController.StartRun ();
			HOTween.To(_stage.transform, 3, new TweenParms()
				.Prop("localPosition", new Vector3(-50f, _stage.transform.localPosition.y, 0))
				.Ease(EaseType.EaseInOutQuad)
				.OnComplete(() => {
					Destroy(_stage);
					CreateStage();
				})
			);
			Debug.Log("##### END");
		} else {
			_isStageClear = false;
			Debug.Log("##### not END");
		}
	}

	private void CreateStage() {
		_countManeger.InitCount ();
		_stage = (GameObject)Instantiate (Resources.Load("Prefabs/Stage/TestStage1"), new Vector3(30f, 3.5f, 0f), Quaternion.identity);
		_stage.transform.parent = transform;
		HOTween.To(_stage.transform, 3, new TweenParms()
			.Prop("localPosition", new Vector3(0f, _stage.transform.localPosition.y, 0))
			.Ease(EaseType.EaseInOutQuad)
			.OnComplete(() => {
				_animController.EndRun();
			})
		);

	}
}
