using UnityEngine;

[CreateAssetMenu( fileName = "New AICharacter", menuName = "Game/Data/Character/AI" )]
public class GDAICharacter : ScriptableObject {

	void Awake() {
	}

}


[System.Serializable]
public struct GDAICharacterStruct {
	public string Name;
	public string Amount;
}