using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponSlot : MonoBehaviour
{
    // 클릭 시 스킬 발동
    public Image icon;
    private WeaponData weaponData;

    public void SetWeapon(WeaponData weapon)
    {
        weaponData = weapon;
        icon.sprite = weapon.weaponIcon;
        icon.enabled = true;
    }
}
