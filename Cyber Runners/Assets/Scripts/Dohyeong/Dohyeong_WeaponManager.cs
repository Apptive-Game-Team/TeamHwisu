using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dohyeong_WeaponManager : MonoBehaviour
{
    // 스크립트 역할 : 선택한 무기 인게임 씬 내 적용
    public static Dohyeong_WeaponManager Instance;
    public Dohyeong_WeaponData equippedWeapon;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void EquipWeapon(Dohyeong_WeaponData weapon)
    {
        equippedWeapon = weapon; // 무기 장착
    }
}
