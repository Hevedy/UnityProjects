using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMSave : MonoBehaviour
{

	public string SLProfileName = "";
	public string SLSettingsName = "";
	public string SLGameName = "";

	public string SLCurProfileName = "";
	public string SLCurSettingsName = "";
	public string SLCurGameName = "";

	public int SLProfilesMax = 5;
	public int SLSettingsMax = 5;
	public int SLGameMax = 20;

	public string SLProfileDir ="Profiles/";
	public string SLSettingsDir = "Settings/";
	public string SLGameDir = "Saves/";

	public static GMSave Instance;

	void Awake() {
		string dataPath = Application.persistentDataPath;
		SLProfileDir = dataPath + SLProfileDir;
		SLSettingsDir = dataPath + SLSettingsDir;
		SLGameDir = dataPath + SLGameDir;
		if ( Instance == null ) {
			DontDestroyOnLoad( gameObject );
			Instance = this;
		} else if ( Instance != this ) {
			Destroy( gameObject );
		}
}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void LoadProfile( string _ProfileName ) {

	}

	public void SaveProfile( string _ProfileName ) {

	}

	public void LoadSettings( string _SettingsName ) {

	}

	public void SaveSettings( string _SettingsName ) {

	}

	public void LoadGame( string _SaveName ) {


	}

	public void SaveGame( string _SaveName ) {


	}

}
