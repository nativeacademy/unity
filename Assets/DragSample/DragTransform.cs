using UnityEngine;
using System.Collections;

public class DragTransform : MonoBehaviour {
	[SerializeField]
	private GameObject _fulcrum;
	[SerializeField]
	private GameObject _dragSystem;
	
	private Color _mouseOverColor = Color.blue;
	private Color _originalColor;
    private bool _isMouseDown = false;
	private DragManeger _dragManeger;

	// Use this for initialization
	void Start () {
		_originalColor = renderer.sharedMaterial.color;
		_dragManeger = _dragSystem.GetComponent<DragManeger>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter(){
		renderer.material.color = _mouseOverColor;
	}
	
	void OnMouseExit(){
		if (!_isMouseDown) {
			renderer.material.color = _originalColor;
		}
	}
	
	void OnMouseDown(){
		StartCoroutine("Drag");
	}
	
	IEnumerator Drag(){
		Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
		
		
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(mousePos);
		_isMouseDown = true;		
		
		while (Input.GetMouseButton(0))
		{
			
			Vector3 curScreenMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenMouse) + offset;
			
			transform.position = curPosition;
			
			yield return null;
		}

		Vector3 direction = _fulcrum.transform.position - transform.position;
		
		_dragManeger.CreateBall();
		_dragManeger.GetBall().rigidbody.AddForce(direction * 10, ForceMode.Impulse);
		
		//_dragManeger.OnThrow();
		_dragManeger.IsRelease = true;
	}
}
