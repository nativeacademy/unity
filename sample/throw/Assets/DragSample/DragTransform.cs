using UnityEngine;
using System.Collections;

public class DragTransform : MonoBehaviour {
	
	Color mouseOverColor = Color.blue;
	Color originalColor;
    bool nowMouseDown = false;
	GameObject fulcrum;
	GameObject main;

	// Use this for initialization
	void Start () {
		fulcrum = GameObject.Find("Fulcrum");
		var pos = fulcrum.transform.position;
		rigidbody.transform.position = pos;
		
		main = GameObject.Find("Main");
	}
	
	// Update is called once per frame
	void Update () {
		// left click
	}
	
	void OnMouseEnter(){
		//renderer.material.color = mouseOverColor;
	}
	
	void OnMouseExit(){
		if (!nowMouseDown) {
			//renderer.material.color = originalColor;
		}
	}
	
	void OnMouseDown(){
		Debug.Log ("moudsedown", this);
		StartCoroutine("Drag");
		main.gameObject.SendMessage("OnCatch", gameObject);
	}
	
	IEnumerator Drag(){
		Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
		
		// 球の中心位置からカーソル位置の差(offset)を取得
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(mousePos);
		nowMouseDown = true;
		//var zeroPoint = new Vector3(0, 0, 0);
		
		while (Input.GetMouseButton(0))
		{
			screenSpace = Camera.main.WorldToScreenPoint(transform.position);
			var curScreenMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			
			var limit = 5;
			var worldMousePos = Camera.main.ScreenToWorldPoint(curScreenMouse);
			var distance = worldMousePos - fulcrum.transform.position;
			
			Vector3 curPosition;
			if(distance.magnitude >= limit){
				Vector3 temp = fulcrum.transform.position + distance.normalized * limit;
				curPosition = temp;
			}else{
				curPosition = worldMousePos + offset;
			}
			
			transform.position = curPosition;
			yield return null;
		}
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

		Vector3 direction = fulcrum.transform.position - transform.position;
		rigidbody.AddForce(direction * 10, ForceMode.Impulse);
		
		
		main.gameObject.SendMessage("OnThrow");
	}
}
