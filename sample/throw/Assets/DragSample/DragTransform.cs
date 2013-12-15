using UnityEngine;
using System.Collections;

public class DragTransform : MonoBehaviour {
	
	Color mouseOverColor = Color.blue;
	Color originalColor;
    bool nowMouseDown = false;
	GameObject fulcrum;

	// Use this for initialization
	void Start () {
		// オリジナルの色を保存
//		originalColor = renderer.sharedMaterial.color;
		fulcrum = GameObject.Find("Fulcrum");
		var pos = fulcrum.transform.position;
		rigidbody.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		// left click
		
	}
	
	void OnMouseEnter(){
		// マウスカーソルが乗った時に色を変更
		//renderer.material.color = mouseOverColor;
	}
	
	void OnMouseExit(){
		if (!nowMouseDown) {
			// マウスカーソルが外れた時にオリジナルの色に戻す
			//renderer.material.color = originalColor;
		}
	}
	
	void OnMouseDown(){
		StartCoroutine("Drag");
	}
	
	IEnumerator Drag(){
		Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
		
		// 球の中心位置からカーソル位置の差(offset)を取得
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(mousePos);
		nowMouseDown = true;
		//var zeroPoint = new Vector3(0, 0, 0);
		
		// マウスの左ボタンが押されてる間はカーソル位置に球の位置を追随させる
		while (Input.GetMouseButton(0))
		{
			// 現在のマウスカーソルの位置+offsetの位置で更新する。これによりカーソル位置に球が追随する
			var curScreenMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
	
			//var limit = 100;
			//Vector3 distance = curScreenMouse - Camera.main.WorldToScreenPoint(fulcrum.transform.position);
			Vector3 curPosition;
			//if(distance.magnitude >= limit){
			//	Vector3 temp = fulcrum.transform.position + distance.normalized * limit;
			//	curPosition = temp;
			//}else{
				curPosition = Camera.main.ScreenToWorldPoint(curScreenMouse) + offset;
			//}
			
			
			transform.position = curPosition;
			
			yield return null;
		}
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

		Vector3 direction = fulcrum.transform.position - transform.position;
		rigidbody.AddForce(direction * 10, ForceMode.Impulse);
		
		var main = GameObject.Find("Main");
		main.gameObject.SendMessage("OnThrow");
		
	}
}
