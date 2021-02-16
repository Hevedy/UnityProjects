using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.ComponentModel;

[CreateAssetMenu( fileName = "New Action", menuName = "Game/Data/Player/Action" )]
public class GDAction : ScriptableObject {


	public string NameID = "";
	public string Name = "";
	public string Description = "";

	public Sprite IconMenu = null;

	public bool AnyTool = false;
	public List<string> RequiredItemIDs = new List<string>();
	public List<GDItem> RequiredItems = new List<GDItem>();
	public bool AnyCharacter = false;
	public List<string> RequiredCharacterIDs = new List<string>();
	public List<GDPlayerCharacter> RequiredCharacters = new List<GDPlayerCharacter>();

	// Start is called before the first frame update
	void Awake() {
	}
}


[System.Serializable]
public class GDActionJson {

	[JsonProperty( Required = Required.Always )]
	public string NameID { get; set; }
	[JsonProperty( Required = Required.Always )]
	public string Name { get; set; }
	[DefaultValue( "" )]
	[JsonProperty( Required = Required.Default )]
	public string Description { get; set; }

	[DefaultValue( "DefaultIcon" )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public string Icon { get; set; }

	[DefaultValue( 1 )]
	[JsonProperty( "InvStackMax", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public int InventoryStackMax { get; set; }
	[DefaultValue( 0.5f )]
	[JsonProperty( "InvWeight", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public float InventoryWeight { get; set; }

	[DefaultValue( 1 )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public int MarketValue { get; set; }
	[DefaultValue( 0 )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public int MarketValueMod { get; set; }

	[DefaultValue( 1 )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public int UsesAmount { get; set; }
	[DefaultValue( 0 )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public int UsesAmountMod { get; set; }

	[DefaultValue( 1.0f )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public float UseTime { get; set; }
	[DefaultValue( 0.0f )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public float UseTimeMod { get; set; }

	[DefaultValue( "All" )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public List<string> RequiredItems { get; set; }
	[DefaultValue( "All" )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public List<string> RequiredCharacters { get; set; }
}