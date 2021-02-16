using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class GMGame : MonoBehaviour
{
    public static GMGame Instance;

    public List<GDItem> Items = new List<GDItem>();
    public List<GDPlayerCharacter> PlayerCharacters = new List<GDPlayerCharacter>();

	/*
	case EGameDataJson.eItems:
	fileName = "GameItems";
	case EGameDataJson.eProps:
	fileName = "GameProps";
	case EGameDataJson.eCharPlayer:
	fileName = "GameCharactersPlayer";
	case EGameDataJson.eCharAllied:
	fileName = "GameCharactersAllied";
	case EGameDataJson.eCharWorld:
	fileName = "GameCharactersWorld";
	case EGameDataJson.eWorlds:
	fileName = "GameWorlds";
	*/

	public bool LoadStatus;

	private GMGame() {
		Debug.Log( "Exec called" );
		Debug.Log( System.Environment.Version );
	}


    // Future worlds

    void Awake() {
		Debug.Log( "Game Awake" );
		if ( Instance == null ) {
			DontDestroyOnLoad( gameObject );
			Instance = this;
		} else if ( Instance != this ) {
			Destroy( gameObject );
		}
		(Items, LoadStatus) = GDItemUtils.JsonToClass();
		//ReadCoreJSON( ECoreJSONFiles.eItems );
	}




    // Start is called before the first frame update
    void Start()
    {
		Debug.Log( "Game Start" );
		// Grab that Client ID from earlier
		//var discord = new Discord.Discord( CLIENT_ID, (UInt64)Discord.CreateFlags.Default );
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        
    }


    public void SetupItems() {

    }
}
