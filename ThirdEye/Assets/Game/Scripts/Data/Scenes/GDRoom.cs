using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.ComponentModel;

public enum ERoomSizes { Tiny, Small, Medium, Big, Huge, Open, Outdoor };
public enum ERoomTypes {
	Default, Room, Hall, Corridor, Kitchen, Bathroom, Bedroom, Livingroom, Diningroom, Study, Kids,
	Outdoor, Street, Garden, SwimmingPool, Greenhouse, Garage, Parking, Workshop, Office,
	Store, Grocery, Supermarket, Cinema, Restaurant, Factory, Ship, Container
};

[CreateAssetMenu( fileName = "New Room", menuName = "Game/Data/Scenes/Room" )]
public class GDRoom : ScriptableObject {


	void Awake() {
	}
}


[System.Serializable]
public class GDRoomJson {

	[JsonProperty( Required = Required.Always )]
	public string NameID { get; set; }
	[JsonProperty( Required = Required.Always )]
	public string Name { get; set; }
	[DefaultValue( "" )]
	[JsonProperty( Required = Required.Default )]
	public string Description { get; set; }

	[DefaultValue( 1 )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public int Size { get; set; }
	[DefaultValue( 10 )]
	[JsonProperty( Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Populate )]
	public float Space { get; set; }

	[JsonProperty( Required = Required.AllowNull )]
	public List<GDAICharacterStruct> AICharacters { get; set; }
	[JsonProperty( Required = Required.AllowNull )]
	public List<GDPropStruct> Props { get; set; }
	[JsonProperty( Required = Required.AllowNull )]
	public List<string> Items { get; set; }

}