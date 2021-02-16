using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "New Language", menuName = "Game/Data/Misc/Language" )]
public class GDLocation : ScriptableObject {

	public string ID = "";
	public List<string> Text = new List<string>{ "", "" };

	void Awake() {
	}
}