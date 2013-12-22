using UnityEngine;
using System.Collections;

public class BallManeger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision collisionInfo) {
		Debug.Log(collisionInfo.gameObject.name);
		string objectName = collisionInfo.gameObject.name;
		if (objectName.Equals("SnowMan") || objectName.Equals("Cube") || objectName.Equals("Out")) {
			Destroy(gameObject);
		}
	}
}
