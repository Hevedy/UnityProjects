using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public enum EPrintType { eInfo, eWarning, eError };

public static class GUtils
{

	public static void PrintC( string Text, EPrintType _Type = EPrintType.eInfo ) {
		string msg = "";
		switch ( _Type ) {
			case EPrintType.eInfo:
				msg = "<color=blue>Info</color> - ";
				break;
			case EPrintType.eWarning:
				msg = "<color=yellow>Warning</color> - ";
				break;
			case EPrintType.eError:
				msg = "<color=red>Error</color> - ";
				break;
		}
		Debug.Log( msg + Text );
	}

	public static bool StrIsNullOrInvalid( string _String ) {
		if ( string.IsNullOrEmpty( _String ) || _String == " " || _String == "  " || _String == "   " || _String == "    " ) {
			return true;
		} else {
			return false;
		}
	}

	public static (T, bool) ParseEnum<T>( string _Value, T _DefaultValue, string _Suffix = "", string _Prefix = "e" ) where T : struct, IConvertible {
		string value = _Prefix + _Value + _Suffix;
		if ( !typeof( T ).IsEnum ) throw new ArgumentException("Error - " + value + " T must be an enumerated type.");
		if ( StrIsNullOrInvalid( value ) ) return (_DefaultValue, false);

		foreach ( T item in Enum.GetValues( typeof( T ) ) ) {
			if ( item.ToString().ToLower().Equals( value.Trim().ToLower() ) ) return (item, true);
		}
		return (_DefaultValue, false);
	}

	public static bool CheckFile( string _URL ) {
		if ( !System.IO.File.Exists( _URL ) ) {
			PrintC( "CheckFile() Missing File.", EPrintType.eError );
			return false;
		} else {
			return true;
		}
	}

	public static (string, bool) ReadTextFile( string _URL ) {
		if ( !CheckFile( _URL ) ) {
			return ("Missing", false);
		}
		string text = System.IO.File.ReadAllText(_URL);
		if ( StrIsNullOrInvalid( text ) ) {
			PrintC( "ReadTextFile() Empty File.", EPrintType.eWarning );
			return ("Empty", true);
		}
		return (text, true);
		//TextAsset targetFile = Resources.Load<TextAsset>( filePath ); // Can be turned to string but whatever
		//return targetFile.text;
	}

	public static bool TryParseJson<T>( this string _String, out T _Result ) {
		bool status = true;
		JsonSerializerSettings settings = new JsonSerializerSettings
		{
			Error = ( sender, args ) => { status = false; args.ErrorContext.Handled = true; },
			MissingMemberHandling = MissingMemberHandling.Error
		};
		_Result = JsonConvert.DeserializeObject<T>( _String, settings );
		return status;
	}

	public static (T, bool) ReadJSONFile<T>( string _URL ) where T : class, new() {
		if ( !typeof( T ).IsClass ) throw new ArgumentException("Error - " + _URL + " must have a valid class.");
		T localClass = new T();
		string fileText = "";
		bool status = false;
		(fileText, status) = ReadTextFile(_URL);
		if ( !status ) { PrintC( "ReadJSONFileList() Missing File.", EPrintType.eError ); return (localClass, false); }

		bool isValidObject = fileText.TryParseJson<T>( out localClass );
		if ( isValidObject ) {
			return (localClass, true);
		} else {
			return (localClass, false);
		}
	}

	public static (List<T>, bool) ReadJSONFileList<T>( string _URL ) where T : class, new() {
		if ( !typeof( T ).IsClass ) throw new ArgumentException( "Error - " + _URL + " must have a valid class." );
		List <T> localClass = new List<T>();
		string fileText = "";
		bool status = false;
		(fileText, status) = ReadTextFile( _URL );
		if ( !status ) { PrintC( "ReadJSONFileList() Missing File.", EPrintType.eError );  return (localClass, false); }

		//var result = default( T );
		bool isValidObject = fileText.TryParseJson<List<T>>( out localClass );
		if ( isValidObject ) {
			return (localClass, true);
		} else {
			return (localClass, false);
		}
		//try {
		//	localClass = JsonConvert.DeserializeObject<T>( fileText );
		//} catch ( System.Exception exception_ ) {
		//return (localClass, true);
	}

	public static bool ValidateInt( int _Min, int _Max, params int[] _IntList ) {
		foreach ( int num in _IntList ) {
			if ( num >= _Min && num <= _Max ) { } else { return false; }
		}
		return true;
	}

	public static bool ValidateFloat( float _Min, float _Max, params float[] _IntList ) {
		foreach ( float num in _IntList ) {
			if ( num >= _Min && num <= _Max ) { } else { return false; }
		}
		return true;
	}

	public static bool ValidateString( params string[] _StringList ) {
		foreach ( string str in _StringList ) {
			if ( StrIsNullOrInvalid( str ) ) {
				return false;
			}
		}
		return true;
	}

	public static (Sprite, bool) LoadImage( string _FileURL, bool _OneChannel = false, bool _Mod = false ) {
		// Control of BlackAndWhite only images
		if ( ValidateString( _FileURL ) ) { PrintC( "LoadImage() Invalid URL.", EPrintType.eError ); return (null, false); }
		Sprite data = null;
		Texture2D preData = null;
		string fileURL = null;
		if ( _Mod ) {
			fileURL = GGP.DirPkgMods + _FileURL;
		} else {
			fileURL = GGP.DirData + _FileURL;
		}
		if ( !CheckFile( fileURL ) ) {
			return (null, false);
		}
		if ( _Mod ) {
			preData = ES3.LoadImage( fileURL );
			data = Sprite.Create( preData, new Rect( 0.0f, 0.0f, Mathf.Min( preData.width, 4096 ), Mathf.Min( preData.height, 4096 ) ), new Vector2( 0.5f, 0.5f ), 100.0f );
			preData = null;
		} else {
			data = Resources.Load<Sprite>( fileURL );
		}
		if ( data == null ) {
			PrintC( "LoadImage() Invalid File.", EPrintType.eError );
			return (null, false);
		} else {
			return (data, true);
		}
	}

	public static (TextAsset, bool) LoadText( string _FileURL, bool _Mod = false ) {
		if ( ValidateString( _FileURL ) ) { PrintC( "LoadText() Invalid URL.", EPrintType.eError ); return (null, false); }
		TextAsset data = null;
		string fileURL = null;
		if ( _Mod ) {
			fileURL = GGP.DirPkgMods + _FileURL;
		} else {
			fileURL = GGP.DirData + _FileURL;
		}
		if ( !CheckFile( fileURL ) ) {
			return (null, false);
		}
		if ( _Mod ) {
			data = Resources.Load<TextAsset>( fileURL );
		} else {
			data = Resources.Load<TextAsset>( fileURL );
		}
		if ( data == null ) {
			PrintC( "LoadText() Invalid File.", EPrintType.eError );
			return (null, false);
		} else {
			return (data, true);
		}
	}

	public static (string, bool) LoadString( string _FileURL, bool _Mod = false ) {
		if ( ValidateString( _FileURL ) ) { PrintC( "LoadString() Invalid URL.", EPrintType.eError ); return (null, false); }
		string data = null;
		string fileURL = null;
		bool status = false;
		if ( _Mod ) {
			fileURL = GGP.DirPkgMods + _FileURL;
		} else {
			fileURL = GGP.DirData + _FileURL;
		}
		if ( !CheckFile( fileURL ) ) {
			return (null, false);
		}
		if ( _Mod ) {
			(data, status) = ReadTextFile( fileURL );
		} else {
			(data, status) = ReadTextFile( fileURL );
		}
		if ( !status ) {
			PrintC( "LoadString() Invalid File.", EPrintType.eError );
			return (null, false);
		} else {
			return (data, true);
		}
	}

	public static EEntityRarity GetRarityByItemType( EEntityTypes _Type ) {
		EEntityRarity rarity = EEntityRarity.eCommon;
		double[] rarityWeights = new double[7];
		rarityWeights[0] = 0.9f;
		rarityWeights[1] = 0.8f;
		rarityWeights[2] = 0.6f;
		rarityWeights[3] = 0.4f;
		rarityWeights[4] = 0.2f;
		rarityWeights[5] = 0.1f;
		rarityWeights[6] = 0.05f;
		switch ( _Type ) {
			case EEntityTypes.eDefault:
				rarityWeights[0] = 0.9f;
				rarityWeights[1] = 0.8f;
				rarityWeights[2] = 0.6f;
				rarityWeights[3] = 0.4f;
				rarityWeights[4] = 0.2f;
				rarityWeights[5] = 0.1f;
				rarityWeights[6] = 0.05f;
				break;
			case EEntityTypes.eAppliances:
				break;
			case EEntityTypes.eComfort:
				break;
			case EEntityTypes.eConsumable:
				break;
			case EEntityTypes.eDecoration:
				break;
			case EEntityTypes.eElectronic:
				break;
			case EEntityTypes.eElectricity:
				break;
			case EEntityTypes.eFood:
				break;
			case EEntityTypes.eGate:
				break;
			case EEntityTypes.eInstallation:
				break;
			case EEntityTypes.eInstrument:
				break;
			case EEntityTypes.eIndustrialEquipment:
				break;
			case EEntityTypes.eTool:
				break;
			case EEntityTypes.eToy:
				break;
			case EEntityTypes.eMachine:
				break;
			case EEntityTypes.ePlant:
				break;
			case EEntityTypes.ePlumbing:
				break;
			case EEntityTypes.ePlayground:
				break;
			case EEntityTypes.eStorage:
				break;
			case EEntityTypes.eValueable:
				break;
			case EEntityTypes.eVehicle:
				break;
			case EEntityTypes.eWearable:
				break;
			case EEntityTypes.eWeapon:
				rarityWeights[0] = 0.9f;
				rarityWeights[1] = 0.8f;
				rarityWeights[2] = 0.6f;
				rarityWeights[3] = 0.4f;
				rarityWeights[4] = 0.2f;
				rarityWeights[5] = 0.1f;
				rarityWeights[6] = 0.05f;
				break;
		}
		rarityWeights[0] = rarityWeights[0] * UnityEngine.Random.Range( 0.0f, 1.0f );
		rarityWeights[1] = rarityWeights[1] * UnityEngine.Random.Range( 0.0f, 1.0f );
		rarityWeights[2] = rarityWeights[2] * UnityEngine.Random.Range( 0.0f, 1.0f );
		rarityWeights[3] = rarityWeights[3] * UnityEngine.Random.Range( 0.0f, 1.0f );
		rarityWeights[4] = rarityWeights[4] * UnityEngine.Random.Range( 0.0f, 1.0f );
		rarityWeights[5] = rarityWeights[5] * UnityEngine.Random.Range( 0.0f, 1.0f );
		rarityWeights[6] = rarityWeights[6] * UnityEngine.Random.Range( 0.0f, 1.0f );

		double maxValue = rarityWeights.Max();
		int index = rarityWeights.ToList().IndexOf( maxValue );

		switch(index) {
			case 0:
				rarity = EEntityRarity.ePoor;
				break;
			case 1:
				rarity = EEntityRarity.eCommon;
				break;
			case 2:
				rarity = EEntityRarity.eUncommon;
				break;
			case 3:
				rarity = EEntityRarity.eRare;
				break;
			case 4:
				rarity = EEntityRarity.eVeryRare;
				break;
			case 5:
				rarity = EEntityRarity.eLegendary;
				break;
			case 6:
				rarity = EEntityRarity.eUnique;
				break;
		}
		return rarity;
	}
}

[System.Serializable]
public struct EntityRef {
	public int EntityIndex;
	public string EntityNameID;
	public string LogicID;
	public ELogicColors LogicColor;
	public bool LogicMission;

}