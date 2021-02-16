using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour {

	public int			AudioMasterVolume, AudioEffectsVolume, AudioMusicVolume, AudioUIVolume;

	public bool			GameSubtitles, GameShowFPS, GameModding, GameDebug, GameDemo, GameComplete, GameCompleteExtra, GamePreview, GameAlpha, GameBeta, GameEarlyAccess;
	public int			GameLanguage;
	public bool			PlatformNoDRM, PlatformGameThis, PlatformSteamWorks, PlatformItch, PlatformGameJolt, PlatformGooglePlay,
						SystemMods, SystemModding, SystemGameThis, SystemDiscord, SystemTwitch, SystemModIO;
	public string		SocialProfileName, SocialGameThisName,
						SocialDiscordName, SocialDiscordChannel, SocialTwitchName, SocialTwitchChannel,
						SocialSteamName, SocialItchName, SocialGameJoltName, SocialGoogleName;

	GameInstance() {
		AudioMasterVolume = 100;
		AudioEffectsVolume = 100;
		AudioMusicVolume = 100;
		AudioUIVolume = 100;

		GameLanguage = 0; //English

		GameSubtitles = false;
		GameShowFPS = false;
		GameModding = false;
		GameDebug = false;
		GameDemo = false;
		GameComplete = false;
		GameCompleteExtra = false;
		GamePreview = false;
		GameAlpha = false;
		GameBeta = false;
		GameEarlyAccess = false;

		PlatformNoDRM = true;
		PlatformGameThis = false;
		PlatformSteamWorks = false;
		PlatformItch = false;
		PlatformGameJolt = false;
		PlatformGooglePlay = false;
		SystemMods = false;
		SystemModding = false;
		SystemGameThis = false;
		SystemDiscord = false;
		SystemTwitch = false;
		SystemModIO = false;

		SocialProfileName = "";
		SocialGameThisName = "";
		SocialDiscordName = "";
		SocialDiscordChannel = "";
		SocialTwitchName = "";
		SocialTwitchChannel = "";
		SocialSteamName = "";
		SocialItchName = "";
		SocialGameJoltName = "";
		SocialGoogleName = "";
	}

	public static GameInstance Instance;

	void Awake() {
		if ( Instance == null ) {
			DontDestroyOnLoad( gameObject );
			Instance = this;
		} else if ( Instance != this ) {
			Destroy( gameObject );
		}
	}

	// Start is called before the first frame update
	void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnDestroy() {

    }


}
