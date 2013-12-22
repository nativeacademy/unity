using UnityEngine;
using System.Collections;

public class AnimController : MonoBehaviour {

	private Animator _anim;

	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartRun() {
		_anim.SetBool ("Run", true);
	}

	public void EndRun() {
		_anim.SetBool ("Run", false);
	}

	public void StartThrow() {
		_anim.SetBool ("Shoot", true);
	}

	public void EndThrow() {
		_anim.SetBool ("Shoot", false);
	}
}
