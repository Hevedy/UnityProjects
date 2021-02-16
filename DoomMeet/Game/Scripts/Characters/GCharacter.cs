using UnityEngine;

public enum ECharacterJobs { None, Student, Carpenter };


/*
 * 
	FAHProfileStruct()
		: PlayerName( "Default" )
		, NickName( "Default" )
		, Bio( "" )
		, Status( 0 ) // 0 Offline, 1 AFK, 2 Playing other, 3 Playeing in your match
		, Played( 0 ) // 0 No played, 1 played before, 2 played one match continua, 3 played 2 match continua...
		, AvatarID( 0 )
		, BannerID( 0 )
		, AHMood( 5 ) // 0 to 10 changes, rage or reply players affects
		, AHAgility( 1.0 )
		, AHCharisma( 1.0 )
		, AHIntelligence( 1.0 )
		, AHPerception( 1.0 )
		, AHPersonality( 1.0 )
		, AHSkill( 1.0 )
		, AHSkillChance( 0.01 ) // Chances of change skills over time.
		, AHSkillValue( 0.01 ) // Skill value over time.
		, Level( 0 )
		, Money( 0 )
		, MoneySpent( 0 )
		, Points( 0 )
		, XP( 0 ) 
		, TimePlayed( 0 )
		, DistanceTraveled( 0 )
		, TopSpeed( 0 )
		, TopMultiplier( 0.0 )
		, PlayerWorldTransform( FTransform( FRotator( 0.0, 0.0, 0.0 ), FVector( 0.0, 0.0, 0.0 ), FVector( 1.0, 1.0, 1.0 ) ) ) {}
	 
	 */

public class GCharacter : MonoBehaviour
{
    public string Name;
    public string Desc;
    public ECharacterJobs LastJob;

    public float InventorySlots = 0.0f;
    public float InventorySlotsMax = 10.0f;
    public float InventoryWeight = 0.0f;
    public float InventoryWeightMax = 10.0f;
    public float Energy = 0.0f;
    public float EnergyMax = 1.0f;

    public int CostHire = 1000;
    public int CostHireMod = 0;
    public int CostMontly = 100;
    public int CostMontlyMod = 0;


    public int Agility = 0;
    public int Strength = 0;
    public int Endurance = 0;
    public int Intelligence = 0;
    public int Perception = 0;
    public int Speed = 0;
    public int MovementSpeed = 0;
    public int Luck = 0;
    public int Melee = 0;
    public int Sneak = 0;
    public int Speech = 0;
    public int Pickpocket = 0;
    public int Hacker = 0;
    public int LockPicking = 0;
    public int Explosives = 0;
    public int Guns = 0;
    public int Tools = 0;
    public int Driving = 0;








    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void CheckRoomProps() {

	}

	void CheckRoomItems() {

	}

	void CheckPropItems() {

	}

	void UseItem() {

	}

	void UseProp() {

	}
}
