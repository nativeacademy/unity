using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	//Color mouseOverColor = Color.blue;
	//Color originalColor;
    //bool nowMouseDown = false;
	GameObject firePoint;
	GameObject main;

	// Use this for initialization
	void Start () {
		firePoint = GameObject.Find("FirePoint");
		main = GameObject.Find("Main");
	}
	
	void Update () {
		
	}
	
	void OnMouseEnter(){
		//renderer.material.color = mouseOverColor;
	}
	
	void OnMouseExit(){
		//if (!nowMouseDown) {
			//renderer.material.color = originalColor;
		//}
	}
	
	void OnMouseDown(){
		StartCoroutine("Drag");
		main.gameObject.SendMessage("OnCatch", gameObject);
	}
	
	IEnumerator Drag(){
		Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
		
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(mousePos);
		//nowMouseDown = true;
		
		Debug.Log ("mouse down");
		while (Input.GetMouseButton(0))
		{
			Debug.Log ("now dragging");
			screenSpace = Camera.main.WorldToScreenPoint(transform.position);
			var curScreenMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			
			var limit = 5;
			var worldMousePos = Camera.main.ScreenToWorldPoint(curScreenMouse);
			var distance = worldMousePos - firePoint.transform.position;
			
			Vector3 curPosition;
			if(distance.magnitude >= limit){
				Vector3 temp = firePoint.transform.position + distance.normalized * limit;
				curPosition = temp;
			}else{
				curPosition = worldMousePos + offset;
			}
			
			transform.position = curPosition;
			yield return null;
		}
		Debug.Log ("mouse up");
		
		main.gameObject.SendMessage("OnThrow");
	}
}
