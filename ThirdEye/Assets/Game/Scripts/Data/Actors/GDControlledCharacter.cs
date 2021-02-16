using UnityEngine;

[CreateAssetMenu( fileName = "New ControlledCharacter", menuName = "Game/Data/Character/Controlled" )]
public class GDControlledCharacter : ScriptableObject {

	void Awake() {
	}
}


[System.Serializable]
public struct GDControlledCharacterStruct {
	public string Name;
	public string Amount;
}