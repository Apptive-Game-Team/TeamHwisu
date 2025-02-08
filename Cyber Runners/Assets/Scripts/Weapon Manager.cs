using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{   

    // 슬롯 업데이트
    public WeaponSlot[] weaponSlots= new WeaponSlot[3];
    private List<WeaponData> equippedWeapons = new List<WeaponData>();
    private void UpdateSlots()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (i < equippedWeapons.Count)
            {
                weaponSlots[i].SetWeapon(equippedWeapons[i]);
            }
            else
            {
                // 무기 최대 보유 중일 때 교체 or 유지 안내문구 띄우기 

                // weaponSlots[i].ChangeWeapon();
            }
        }
    }
}
