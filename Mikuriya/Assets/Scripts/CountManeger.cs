using UnityEngine;
using System.Collections;

public class CountManeger : MonoBehaviour {
	
	private int _count;
	private int _countMax;
	
	// Use this for initialization
	void Start () {
		// test
		_countMax = 3;
		_count = _countMax;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool ReduceCountAndCheck() {
		_count--;
		guiText.text = "Ball : " + _count + " / " + _countMax;
		if (_count == 0) {
			return true;
		} 
		return false;
	}
	
	public void InitCount() {
		_count = _countMax;
		guiText.text = "Ball : " + _count + " / " + _countMax;
	}
}
