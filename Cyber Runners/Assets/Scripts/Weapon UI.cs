using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public static WeaponUI instance;

    // public List<WeaponData> availableWeapons;
    public GameObject weaponUI;
    public Button[] optionButton; // 선택 가능 무기 버튼
    public Image[] weaponSlots; 
    public Sprite[] weaponSprites;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        weaponUI.SetActive(false);
    }

    public void ShowWeaponUI()
    {
        weaponUI.SetActive(true);
    
    }

    // 선택 시 Weapon Button UI에 하나씩 추가되게게
    void SelectWeapon(WeaponData weapon)
    {
        // WeaponManager.UpdateSlots(weapon);
        HideWeaponUI();
    }
    public void HideWeaponUI()
    {
        weaponUI.SetActive(false);
    }        
}
