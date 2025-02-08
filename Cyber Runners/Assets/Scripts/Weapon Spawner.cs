using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSpawner : MonoBehaviour
{
    public static WeaponSpawner instance;

    public List<WeaponData> availableWeapons;
    public GameObject weaponUI;
    public Button[] optionButton;
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

        // 버튼, 이미지, 스프라이트에 각각 띄우기 -> 이거 스크립터블오브젝트로로
        
        /*
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            int index = i;
            optionButton[i].GetComponent<Image>().sprite = weaponSprites[i];
        }
        */

        
    }


    // 선택 시 Weapon Button UI에 하나씩 추가되게게
    void SelectWeapon(int weaponIndex)
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i].sprite == null)
            {
                weaponSlots[i].sprite = weaponSprites[weaponIndex];
                break;
            }
        }
        weaponUI.SetActive(false);
    }
}
