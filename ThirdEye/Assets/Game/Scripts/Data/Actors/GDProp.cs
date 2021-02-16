using System.Collections.Generic;
using UnityEngine;

public enum EPropUseIndexs {  };
public enum EPropStates { eDefault, eUnlocked, eLocked, eBlocked, eDisabled, eEnabled, eBroken }; //Enabled & Disabled by power supply
public enum EPropGateStatus { eClosed, eHalfOpen, eOpen };
public enum EPropLocations { North, South, East, West, Middle }; //Arriba, Abajo, Derecha, Izquierda
// Puede bloquearse el gate y noc errar o abrir ?
// Puertas, ventanas y trozos de pared son gates
// Mirar de meter todo en el manager principal y simular todo desde codigo sin actores y a la mierda con todo

[CreateAssetMenu( fileName = "New Prop", menuName = "Game/Data/Object/Prop" )]
public class GDProp : ScriptableObject {

	//north, south, east, and west

	public string NameID = "";
	public List<string> NameList = new List<string>(); //Choose random per item
	public string Name = "";
	public List<string> DescriptionList = new List<string>(); // Choose random per item
	public string Description = "";

	public EPropLocations Location = EPropLocations.Middle;
	public GWRoom Room = null;
	public GWRoom GateRoom = null;

	public EPropStates PropState = EPropStates.eDefault;

	public bool IsPlaced = false;
	public GCharacter Owner = null;

	public AudioClip AudioRandom = null;

	public bool IsUsable = false;
	public bool IsOnUse = false;
	public GCharacter User = null;
	public AudioClip AudioOnUseStart = null;
	public AudioClip AudioOnUse = null;
	public AudioClip AudioOnUseEnd = null;
	public int UsesAmount = -1; // Infinite
	public int UsesAmountMod = 0;
	public float UseTime = 1.0f;
	public float UseTimeMod = 0.0f;


	// Defined in Level
	public int UseIndexActive = 0; // Index of use active based on type can have different action
	public string LogicID = "";
	public ELogicColors LogicColor = ELogicColors.eNone;
	// Defined in Level


	public bool IsGate = false;
	public EPropGateStatus GateStatus = EPropGateStatus.eClosed;
	public bool IsGateHalfOpen = false;

	public bool IsBreakable = false;
	public bool IsBroken = false;
	public AudioClip AudioOnHit = null;
	public AudioClip AudioOnBreak = null;
	public int Health = 100;

	public bool IsStorage = false;
	public int StorageSlots = 100;
	public float StorageWeight = 10.0f;

	void Awake() {
	}
}

[System.Serializable]
public struct GDPropStruct {
	public string Name;
	public string Amount;
}