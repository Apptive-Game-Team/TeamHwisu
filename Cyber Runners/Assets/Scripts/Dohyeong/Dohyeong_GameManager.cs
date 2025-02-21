using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dohyeong_GameManager : MonoBehaviour
{
    public static Dohyeong_GameManager Instance;
    public Dohyeong_WeaponData equippedWeapon;
    public List<Dohyeong_WeaponData> allWeapons;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else   
            Destroy(gameObject);
    }

    void Start()
    {
        LoadEquippedWeapon();
    }

    private void LoadEquippedWeapon()
    {
        string weaponName = PlayerPrefs.GetString("EquippedWeapon", "DefaultWeapon"); // 기본 무기 설정

        foreach (Dohyeong_WeaponData weapon in allWeapons)
        {
            if (weapon.weaponName == weaponName)
            {
                EquipWeapon(weapon);
                return;
            }
        }
    }

    public void EquipWeapon(Dohyeong_WeaponData weapon)
    {
        equippedWeapon = weapon;
    
    }
}
