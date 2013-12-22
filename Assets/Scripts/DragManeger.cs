using UnityEngine;
using System.Collections;

public class DragManeger : MonoBehaviour {
	
	[SerializeField]
	private GameObject _fulcrum;
	[SerializeField]
	private GameObject _ball;
	[SerializeField]
	private GameObject _line;
	[SerializeField]
	private GameObject _draggableUI;
	[SerializeField]
	private GameObject _stage;
	
	private CountManeger _countManeger;
	private StageManeger _stageManeger;
	private Vector3 _draggableUIPos;
	private Vector3 _fulcrumPos;
	private LineRenderer _lineRenderer;
	private GameObject _createdBall;
	private bool _isCreated;
	private bool _isMouseDown;
	private bool _isEnd;
	public bool IsRelease {
		get; set;
	}
	
	// Use this for initialization
	void Start () {
		_stageManeger = _stage.GetComponent<StageManeger> ();
		_countManeger = GetComponentInChildren<CountManeger>();
		_lineRenderer = _line.GetComponent<LineRenderer>();
		_fulcrumPos = _fulcrum.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (_createdBall != null) {
			if (IsRelease) {
				_draggableUI.SetActive(false);
				OnThrow();
			}
		} else {
			if (_isCreated) {
				if (_isEnd) {
					if (_stageManeger.IsStageClear) {
						// next stage
						_draggableUI.SetActive(true);
						_draggableUI.transform.localPosition = _fulcrumPos;
						_isCreated = false;
						IsRelease = false;
					} else {
						// game over
					}
 					
					
					
				} else {
					_draggableUI.SetActive(true);
					_draggableUI.transform.localPosition = _fulcrumPos;
					_isCreated = false;
					IsRelease = false;
				}
			} else {
				OnDrag();
			}
		}
	}
	
	private void OnThrow() {
		_lineRenderer.enabled = false;
		_isMouseDown = false;
	}
	
	private void OnDrag() {
		if (_isMouseDown == false) {
			_lineRenderer.enabled = true;
			_isMouseDown = true;
		} else {
			_draggableUIPos = _draggableUI.transform.position;
			_lineRenderer.SetPosition(0, _draggableUIPos);
			_lineRenderer.SetPosition(1, _fulcrumPos);
		}
	}
	
	public GameObject GetFulcrum() {
		return _fulcrum;
	}
	
	public GameObject GetBall() {
		return _createdBall;
	}
	
	public void CreateBall() {
		_isEnd = _countManeger.ReduceCountAndCheck();
		_createdBall = (GameObject)Instantiate(_ball, _fulcrumPos, Quaternion.identity);
		_isCreated = true;
	}
}
