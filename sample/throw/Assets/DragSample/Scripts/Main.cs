using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	GameObject firePoint;
	GameObject line;
	public GameObject ballPrefab;
	GameObject ball;
	GameObject mainCamera;
	LineRenderer lineRenderer;
	bool isThrowing;
	bool isStopChecking;
	float stopTime;
	float stopDetectTime = 5f;


	void Start () {
		firePoint = GameObject.Find("FirePoint");
		line = GameObject.Find("Line");
		mainCamera = GameObject.Find("MainCamera");
		lineRenderer = line.GetComponent<LineRenderer>();
		
		createBall();
		//StartCoroutine("camreaChaseBall");
	}
	
	GameObject createBall(){
		ball = Instantiate(ballPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;
		ball.rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
		return ball;	
	}
	
	IEnumerator createBallDelay(){
		yield return new WaitForSeconds(0.5f);
		//createBall();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isThrowing){
			return;
		}
			
		if(ball.transform.rigidbody.velocity.magnitude < 1){
			isStopChecking = true;	
			if(!isStopChecking){
				stopTime = Time.time;
			}
		}else{
			isStopChecking = false;
		}
		
		if(isStopChecking && (Time.time - stopTime) > stopDetectTime){
			isStopChecking = false;
			restart();
		}
	}
	
	void restart() {
		isThrowing = false;
		StopCoroutine("camreaChaseBall");
		//Debug.LogWarning("stop");
		
		var cameraPos = mainCamera.transform.position;
		mainCamera.transform.position = new Vector3(0, cameraPos.y, cameraPos.z);
		createBall();
	}
	
	IEnumerator camreaChaseBall() {
		var x = mainCamera.transform.position.x;
		while(true){
			//Debug.LogWarning("chase ball");
			
			var ballPos = ball.transform.position;
			var cameraPos = mainCamera.transform.position;
			
			x += (ballPos.x - cameraPos.x) * 0.08f;
			mainCamera.transform.position = new Vector3(x, cameraPos.y, cameraPos.z);
			yield return null;
		}
	}
	
	void OnThrow(){
		ball.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
		Vector3 direction = firePoint.transform.position - ball.transform.position;
		ball.rigidbody.AddForce(direction * 10, ForceMode.Impulse);
		
		
		lineRenderer.enabled = false;
		StopCoroutine("DrawLine");
		
		//StartCoroutine("createBallDelay");
		StartCoroutine("camreaChaseBall");
		isThrowing = true;
		Debug.LogWarning("throw");
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
			
			var fulcrumPos = firePoint.transform.position;
			lineRenderer.SetPosition(1, fulcrumPos);
			yield return null;
		}
	}
}
