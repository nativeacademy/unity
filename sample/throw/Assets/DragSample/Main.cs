using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	GameObject fulcrum;
	GameObject ball;
	GameObject line;
	LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		fulcrum = GameObject.Find("Fulcrum");
		ball = GameObject.Find("Ball");
		line = GameObject.Find("Line");
		lineRenderer = line.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		lineRenderer = line.GetComponent<LineRenderer>();
		var ballPos = ball.transform.position;
		lineRenderer.SetPosition(0, ballPos);
		
		var fulcrumPos = fulcrum.transform.position;
		lineRenderer.SetPosition(1, fulcrumPos);
	}
	
	void OnThrow(){
		lineRenderer.enabled = false;
	}
}
