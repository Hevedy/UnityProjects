using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.ComponentModel;

//Collectable, Consumable, Material, Tool, Valuable, Weapon..

[CreateAssetMenu( fileName = "New Item", menuName = "Game/Data/Object/Item" )]
public class GDUserModules : ScriptableObject {

	public string NameID = "";
	public List<string> NameList = new List<string>(); //Choose random per item
	public string Name = "";
	public List<string> DescriptionList = new List<string>(); // Choose random per item
	public string Description = "";

	public Sprite IconMenu = null;
    public Sprite IconWorld = null;
	public AudioClip AudioUseStart = null;
	public AudioClip AudioUse = null;
	public AudioClip AudioUseEnd = null;
	public AudioClip AudioOnPickup = null;
	public AudioClip AudioOnDrop = null;

	public int InventoryStackMax = 1;
    public float InventoryWeight = 0.5f;

    public int MarketValue = 1;
    public int MarketValueMod = 0;

	public EEntityRarity Rarity = EEntityRarity.eCommon;

	// Amount of uses
	public int UsesAmount = -1;
    // Random value added
    public int UsesAmountMod = 0;

    // Time need 
    public float UseTime = 1.0f;
    // Random value added
    public float UseTimeMod = 0.0f;

	public List<string> ActionIDs = new List<string>();
	public List<GDAction> Actions = new List<GDAction>(); //On Runtime

	// Directly from json creation
	public ELogicTypes LogicType = ELogicTypes.eNone;
    public EEntityClass LogicClass = EEntityClass.eDefault;
    // Level defined
    public string LogicID = "";
    public ELogicColors LogicColor = ELogicColors.eNone;
    public bool LogicMission = false;

	void Awake() {
	}

}

[System.Serializable]
public class GDUserModulesJson {

	[JsonProperty( Required = Required.Always )]
	public string NameID { get; set; }
	[JsonProperty( Required = Required.Always )]
	public string Name { get; set; }
	[DefaultValue( "" )]
	[JsonProperty( Required = Required.Default )]
	public string Description { get; set; }

	[DefaultValue( "DefaultIcon" )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public string IconMenu { get; set; }
	[DefaultValue( "DefaultIcon" )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public string IconWorld { get; set; }

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

	[DefaultValue( "None" )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public string LogicType { get; set; }
	[DefaultValue( "Default" )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public string LogicClass { get; set; }
}

public static class GDUserModulesUtils {
    public static string File = "GameItems";

	public static (List<GDItem>, bool) JsonToClass() {
        List<GDItemJson> fileList = new List<GDItemJson>();
		bool fileStatus = false;
		(fileList, fileStatus) = GUtils.ReadJSONFileList<GDItemJson>( GGP.DirData + File + ".json" );
		List<GDItem> classList = new List<GDItem>();
		if ( !fileStatus ) { GUtils.PrintC( File + ".json parse failed.", EPrintType.eError ); return (classList, false); }

		if ( fileList.Count > 0 ) {
			foreach ( GDItemJson item in fileList ) {
				if ( !GUtils.ValidateString( item.NameID, item.Name ) ) {
					GUtils.PrintC( "Invalid string", EPrintType.eError );  return (classList, false);
				}
				if ( !GUtils.ValidateString( item.LogicType, item.LogicClass ) ) {
					//GUtils.PrintC( "Invalid string LogicType & LogicClass.", EPrintType.eWarning );
				}

				GDItem classItem = ScriptableObject.CreateInstance<GDItem>();
				classItem.NameID = item.NameID;
				classItem.Name = item.Name;
				classItem.Description = item.Description;
				classItem.InventoryStackMax = item.InventoryStackMax;
				classItem.InventoryWeight = item.InventoryWeight;
				classItem.MarketValue = item.MarketValue;
				classItem.MarketValueMod = item.MarketValueMod;
				classItem.UsesAmount = item.UsesAmount;
				classItem.UsesAmountMod = item.UsesAmountMod;
				classItem.UseTime = item.UseTime;
				classItem.UseTimeMod = item.UseTimeMod;

				( classItem.LogicType, fileStatus ) = GUtils.ParseEnum( item.LogicType, classItem.LogicType );
				( classItem.LogicClass, fileStatus) = GUtils.ParseEnum( item.LogicClass, classItem.LogicClass );
				classList.Add( classItem );

				classItem = null;
			}
		} else {
			GUtils.PrintC( File + ".json is empty.", EPrintType.eError );
			return (classList, false);
		}
		GUtils.PrintC( File + ".json correctly loaded.", EPrintType.eInfo );
		return (classList, true);
    }

	/// Text to enum
	/*
    public static (ELogicColors, bool) GetLogicColors( string _Text ) {
        bool result = Enum.TryParse( _Text, out ELogicColors myEnum );
        return (myEnum, result);
    }

    public static (ELogicTypes, bool) GetLogicTypes( string _Text ) {
        bool result = Enum.TryParse( _Text, out ELogicTypes myEnum );
        return (myEnum, result);
    }

    public static (EEntityClass, bool) GetEntityClass( string _Text ) {
        bool result = Enum.TryParse( _Text, out EEntityClass myEnum );
        return (myEnum, result);
    }

    public static (EEntityTypes, bool) GetEntityTypes( string _Text ) {
        bool result = Enum.TryParse( _Text, out EEntityTypes myEnum );
        return (myEnum, result);
    }
	*/
}