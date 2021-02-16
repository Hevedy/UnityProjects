using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.ComponentModel;

public enum EGameDataJson { eItems, eProps, eCharPlayer, eCharAllied, eCharWorld, eWorlds, eRooms };
public enum EGameVersion { eAlpha, eBeta, eReleaseCandidate, eRelease };
public enum EGameType { eDemo, eEarlyAccess, eDefaultEdition, eSupporterEdition };

public static class GGP
{
    static GGP() {
        gameSubtitles = false;
        gameShowFPS = false;
        gameModding = false;
        gameDebug = false;
        gameDemo = false;
        gameComplete = false;
        gameCompleteExtra = false;
        gamePreview = false;
        gameAlpha = false;
        gameBeta = false;
        gameEarlyAccess = false;

        infoGameName = "ThirdEye";
        infoGameVersion = "0.0.0";
        infoCompanyName = "Hevedy";

		dirResources = "Assets/Game/Resources/";
		dirData = "Assets/Game/Data/";
		dirGame = "Assets/Game/";
		dirMods = "Mods/";
		//dirPkgData = Application.dataPath;
		//dirPkgGame = Application.dataPath;
		//dirPkgMods = Application.persistentDataPath + "Mods/";
		//dirPkgUser = Application.persistentDataPath;


		platformNoDRM = true;
        platformGameThis = false;
        platformSteamWorks = false;
        platformItch = false;
        platformGameJolt = false;
        platformGooglePlay = false;
        systemMods = false;
        systemModding = false;
        systemGameThis = false;
        systemDiscord = false;
        systemTwitch = false;
        systemModIO = false;
    }

    private static bool gameSubtitles, gameShowFPS, gameModding, gameDebug, gameDemo, gameComplete, gameCompleteExtra, gamePreview, gameAlpha, gameBeta, gameEarlyAccess;

    public static bool GameSubtitles
    {
        get { return gameSubtitles; }
        set { gameSubtitles = value; }
    }

    public static bool GameShowFPS
    {
        get { return gameShowFPS; }
        set { gameShowFPS = value; }
    }

    public static bool GameModding
    {
        get { return gameModding; }
        set { gameModding = value; }
    }

    public static bool GameDebug
    {
        get { return gameDebug; }
        set { gameDebug = value; }
    }

    public static bool GameDemo
    {
        get { return gameDemo; }
        set { gameDemo = value; }
    }

    public static bool GameComplete
    {
        get { return gameComplete; }
        set { gameComplete = value; }
    }

    public static bool GameCompleteExtra
    {
        get { return gameCompleteExtra; }
        set { gameCompleteExtra = value; }
    }

    public static bool GamePreview
    {
        get { return gamePreview; }
        set { gamePreview = value; }
    }

    public static bool GameAlpha
    {
        get { return gameAlpha; }
        set { gameAlpha = value; }
    }

    public static bool GameBeta
    {
        get { return gameBeta; }
        set { gameBeta = value; }
    }

    public static bool GameEarlyAccess
    {
        get { return gameEarlyAccess; }
        set { gameEarlyAccess = value; }
    }


    private static string infoGameName, infoGameVersion, infoCompanyName;

    public static string InfoGameName
    {
        get { return infoGameName; }
        set { infoGameName = value; }
    }

    public static string InfoGameVersion
    {
        get { return infoGameVersion; }
        set { infoGameVersion = value; }
    }

    public static string InfoCompanyName
    {
        get { return infoCompanyName; }
        set { infoCompanyName = value; }
    }


	private static string dirResources, dirData, dirGame, dirMods, dirPkgData, dirPkgGame, dirPkgMods, dirPkgUser;

	public static string DirResources
	{
		get { return dirResources; }
		set { dirResources = value; }
	}

	public static string DirData
	{
		get { return dirData; }
		set { dirData = value; }
	}

	public static string DirGame
	{
		get { return dirGame; }
		set { dirGame = value; }
	}

	public static string DirMods
	{
		get { return dirMods; }
		set { dirMods = value; }
	}

	public static string DirPkgData
	{
		get { return dirPkgData; }
		set { dirPkgData = value; }
	}

	public static string DirPkgGame
	{
		get { return dirPkgGame; }
		set { dirPkgGame = value; }
	}

	public static string DirPkgMods
	{
		get { return dirPkgMods; }
		set { dirPkgMods = value; }
	}

	public static string DirPkgUser
	{
		get { return dirPkgUser; }
		set { dirPkgUser = value; }
	}

	private static bool platformNoDRM, platformGameThis, platformSteamWorks, platformItch, platformGameJolt, platformGooglePlay,
                        systemMods, systemModding, systemGameThis, systemDiscord, systemTwitch, systemModIO;

    public static bool PlatformNoDRM
    {
        get { return platformNoDRM; }
        set { platformNoDRM = value; }
    }

    public static bool PlatformGameThis
    {
        get { return platformGameThis; }
        set { platformGameThis = value; }
    }

    public static bool PlatformSteamWorks
    {
        get { return platformSteamWorks; }
        set { platformSteamWorks = value; }
    }

    public static bool PlatformItch
    {
        get { return platformItch; }
        set { platformItch = value; }
    }

    public static bool PlatformGameJolt
    {
        get { return platformGameJolt; }
        set { platformGameJolt = value; }
    }

    public static bool PlatformGooglePlay
    {
        get { return platformGooglePlay; }
        set { platformGooglePlay = value; }
    }

    public static bool SystemMods
    {
        get { return systemMods; }
        set { systemMods = value; }
    }

    public static bool SystemModding
    {
        get { return systemModding; }
        set { systemModding = value; }
    }

    public static bool SystemGameThis
    {
        get { return systemGameThis; }
        set { systemGameThis = value; }
    }

    public static bool SystemDiscord
    {
        get { return systemDiscord; }
        set { systemDiscord = value; }
    }

    public static bool SystemTwitch
    {
        get { return systemTwitch; }
        set { systemTwitch = value; }
    }

    public static bool SystemModIO
    {
        get { return systemModIO; }
        set { systemModIO = value; }
    }
}


[System.Serializable]
public class GGPInfoGameJson {

	[JsonProperty( Required = Required.Always )]
	public string Name { get; set; }
	[JsonProperty( Required = Required.Always )]
	public int VersionMajor { get; set; }
	[JsonProperty( Required = Required.Always )]
	public int VersionMinor { get; set; }
	[JsonProperty( Required = Required.Always )]
	public int VersionPatch { get; set; }

	[JsonProperty( Required = Required.Always )]
	public string CompanyName { get; set; }
}