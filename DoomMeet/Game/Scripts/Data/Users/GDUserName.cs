using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "New Name", menuName = "Game/Data/Utils/Name" )]
public class GDUserName : ScriptableObject {

	public string Nickname = "";
	public string Name = "";
	public string Surname = "";


	void Awake() {
	}
}