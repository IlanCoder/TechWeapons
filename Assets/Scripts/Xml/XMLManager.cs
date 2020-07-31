using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml; //Basic XML attributes
using System.Xml.Serialization; //Acces xmlserializer
using System.IO; //File management

public class XMLManager : MonoBehaviour {

    public static XMLManager ins;
    void Awake() { ins = this; }

    public MeleeWeaponsDB meleeWeaponDB;
    public RangedWeaponsDB rangedWeaponDB;
    public MeleeEffectDB meleeEffectDB;
    public RangedEffectDB rangedEffectDB;
    public ChipDB chipDB;

    void Start() {
        //SaveAll();
        LoadAll();
    }

    public void SaveAll() {
        SaveWeapons();
        SaveEffects();
        SaveChips();
    }

    public void SaveWeapons() {
        SaveMeleeWeapons();
        SaveRangedWeapons();
    }

    public void SaveEffects() {
        SaveMeleeEffects();
        SaveRangedEffects();
    }

    public void SaveMeleeWeapons() {
        //open a new xml file
        XmlSerializer serializer = new XmlSerializer(typeof(MeleeWeaponsDB)); //Type of Xml
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/melee_weapons.xml", FileMode.OpenOrCreate); //Location and method
        serializer.Serialize(stream, meleeWeaponDB); //Saves MeleeWeaponDB on stream
        stream.Close();
    }

    public void SaveRangedWeapons() {
        XmlSerializer serializer = new XmlSerializer(typeof(RangedWeaponsDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/ranged_weapons.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, rangedWeaponDB);
        stream.Close();
    }

    public void SaveMeleeEffects() {
        XmlSerializer serializer = new XmlSerializer(typeof(MeleeEffectDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/melee_effects.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, meleeEffectDB);
        stream.Close();
    }

    public void SaveRangedEffects() {
        XmlSerializer serializer = new XmlSerializer(typeof(RangedEffectDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/ranged_effects.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, rangedEffectDB);
        stream.Close();
    }

    public void SaveChips() {
        XmlSerializer serializer = new XmlSerializer(typeof(ChipDB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/chips.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, chipDB);
        stream.Close();
    }

    public void LoadAll() {
        LoadWeapons();
        LoadEffects();
        LoadChips();
    }

    public void LoadWeapons() {
        LoadMeleeWeapons();
        LoadRangedWeapons();
    }

    public void LoadEffects() {
        LoadMeleeEffects();
        LoadRangedEffects();
    }

    public void LoadMeleeWeapons() {
        XmlSerializer serializer = new XmlSerializer(typeof(MeleeWeaponsDB));
        FileStream stream = File.Open(Application.dataPath + "/StreamingAssets/XML/melee_weapons.xml", FileMode.Open);
        meleeWeaponDB = serializer.Deserialize(stream) as MeleeWeaponsDB; //Loads stream onto MeleeWeaponDB
        stream.Close();
    }

    public void LoadRangedWeapons() {
        XmlSerializer serializer = new XmlSerializer(typeof(RangedWeaponsDB));
        FileStream stream = File.Open(Application.dataPath + "/StreamingAssets/XML/ranged_weapons.xml", FileMode.Open); 
        rangedWeaponDB = serializer.Deserialize(stream) as RangedWeaponsDB;
        stream.Close();
    }

    public void LoadMeleeEffects() {
        XmlSerializer serializer = new XmlSerializer(typeof(MeleeEffectDB));
        FileStream stream = File.Open(Application.dataPath + "/StreamingAssets/XML/melee_effects.xml", FileMode.Open);
        meleeEffectDB = serializer.Deserialize(stream) as MeleeEffectDB;
        stream.Close();
    }

    public void LoadRangedEffects() {
        XmlSerializer serializer = new XmlSerializer(typeof(RangedEffectDB));
        FileStream stream = File.Open(Application.dataPath + "/StreamingAssets/XML/ranged_effects.xml", FileMode.Open);
        rangedEffectDB = serializer.Deserialize(stream) as RangedEffectDB;
        stream.Close();
    }

    public void LoadChips() {
        XmlSerializer serializer = new XmlSerializer(typeof(ChipDB));
        FileStream stream = File.Open(Application.dataPath + "/StreamingAssets/XML/chips.xml", FileMode.Open);
        chipDB = serializer.Deserialize(stream) as ChipDB;
        stream.Close();
    }
}

public class XMLMeleeWeapon {
    [XmlElement("Weapon_Name")]
    public string weaponName;
    [XmlElement("Attack_Speed")]
    public int attackSpeed;
    [XmlElement("Damage")]
    public float damage;
    [XmlElement("Effect_Charge")]
    public int effectCharge;
    [XmlElement("Effect_Name")]
    public string effectName;
    [XmlElement("Level")]
    public int level;
    [XmlElement("Att.Spd._Upgrade")]
    public int attSpdUpgrade;
    [XmlElement("Damage_Upgrade")]
    public float damageUpgrade;
}

public class XMLRangedWeapon {
    [XmlElement("Weapon_Name")]
    public string weaponName;
    [XmlElement("Attack_Speed")]
    public int attackSpeed;
    [XmlElement("Range")]
    public float range;
    [XmlElement("Damage")]
    public int damage;
    [XmlElement("Reload_Speed")]
    public float reloadSpeed;
    [XmlElement("Ammo")]
    public int ammo;
    [XmlElement("Effect_Damage")]
    public float effectDamage;
    [XmlElement("Effect_Efficiency")]
    public int effectEfficiency;
    [XmlElement("Effect_Name")]
    public string effectName;
    [XmlElement("Level")]
    public int level;
}

[System.Serializable] //Visible in ispector
public class XMLSword : XMLMeleeWeapon {  
}

[System.Serializable]
public class XMLAxe : XMLMeleeWeapon {
}

[System.Serializable]
public class XMLPistol : XMLRangedWeapon {
    [XmlElement("Range_Upgrade")]
    public float rangeUpgrade;
    [XmlElement("Reload_Upgrade")]
    public float reloadUpgrade;
}

[System.Serializable]
public class XMLRifle : XMLRangedWeapon {
    [XmlElement("E.E._Upgrade")]
    public float EEUpgrade;
    [XmlElement("Damage_Upgrade")]
    public int damageUpgrade;
}

[System.Serializable]
public class XMLShotgun : XMLRangedWeapon {
    [XmlElement("E.D._Upgrade")]
    public float effDmgUpgrade;
    [XmlElement("Damage_Upgrade")]
    public int damageUpgrade;
}

[System.Serializable]
public class XMLMinigun : XMLRangedWeapon {
    [XmlElement("Reload_Upgrade")]
    public float reloadUpgrade;
    [XmlElement("Ammo_Upgrade")]
    public int ammoUpgrade;
}

[System.Serializable]
public class MeleeWeaponsDB {
    [XmlArray("Swords")]
    public List<XMLSword> swordList = new List<XMLSword>();
    [XmlArray("Axes")]
    public List<XMLAxe> axeList = new List<XMLAxe>();
}

[System.Serializable]
public class RangedWeaponsDB {
    [XmlArray("Pistols")]
    public List<XMLPistol> pistolList = new List<XMLPistol>();
    [XmlArray("Rifles")]
    public List<XMLRifle> rifleList = new List<XMLRifle>();
    [XmlArray("Shotguns")]
    public List<XMLShotgun> shotgunList = new List<XMLShotgun>();
    [XmlArray("Miniguns")]
    public List<XMLMinigun> minigunList = new List<XMLMinigun>();
}

[System.Serializable]
public class XMLMeleeEffect {
    [XmlElement("Effect_Name")]
    public string effectName;
    [XmlElement("Damage")]
    public int damage;
    [XmlElement("Area")]
    public int area;
}

[System.Serializable]
public class XMLRangedEffect {
    [XmlElement("Effect_Name")]
    public string effectName;
    [XmlElement("Damage")]
    public int damage;
    [XmlElement("Debuffed_Stat")]
    public string debuffedStat;
    [XmlElement("Strength")]
    public int strength;
    [XmlElement("Duration")]
    public float duration;
}

[System.Serializable]
public class MeleeEffectDB {
    [XmlArray("Melee_Effects")]
    public List<XMLMeleeEffect> meleeEffList = new List<XMLMeleeEffect>();
}

[System.Serializable]
public class RangedEffectDB {
    [XmlArray("Ranged_Effects")]
    public List<XMLRangedEffect> rangedEffList = new List<XMLRangedEffect>();
}

[System.Serializable]
public class XMLChip {
    [XmlElement("Chip_Name")]
    public string chipName;
    [XmlElement("Buffed_Stat")]
    public string buffedStat;
    [XmlElement("Amount")]
    public int amount;
}

[System.Serializable]
public class ChipDB {
    [XmlArray("Chips")]
    public List<XMLChip> chipList = new List<XMLChip>();
}
