using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour {
		
	public GUIStyle titleStyle;
	public GUIStyle playStyle;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
	void OnGUI(){
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.FlexibleSpace();
            drawLayout();
            GUILayout.FlexibleSpace();
        GUILayout.EndArea();
    }
    
    void drawLayout(){
        GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("", titleStyle);
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Button("", playStyle);
                GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
}
