using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	GameObject fulcrum;
	GameObject line;
	LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		fulcrum = GameObject.Find("Fulcrum");
		line = GameObject.Find("Line");
		lineRenderer = line.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnThrow(){
		lineRenderer.enabled = false;
		StopCoroutine("DrawLine");
	}
	
	void OnCatch(GameObject dragedObj){
		lineRenderer.enabled = true;
		StartCoroutine("DrawLine", dragedObj);
	}
	
	IEnumerator DrawLine(GameObject dragedObj){
		while(true){
			lineRenderer = line.GetComponent<LineRenderer>();
			var dragedPos = dragedObj.transform.position;
			lineRenderer.SetPosition(0, dragedPos);
			
			var fulcrumPos = fulcrum.transform.position;
			lineRenderer.SetPosition(1, fulcrumPos);
			yield return null;
		}
	}
}
