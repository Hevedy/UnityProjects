using UnityEngine;

public enum ECharacterJobs { None, Student, Carpenter };

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
