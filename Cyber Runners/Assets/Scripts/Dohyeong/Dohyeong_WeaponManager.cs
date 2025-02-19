using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dohyeong_WeaponManager : MonoBehaviour
{
    // 스크립트 역할 : 무기 장착 관련 게임 로직 관리
    public static Dohyeong_WeaponManager Instance;
    // 현재 장착된 무기
    public Dohyeong_WeaponData equippedWeapon; 

    // 현재 보유 중인 무기 리스트
    private List<Dohyeong_WeaponData> ownedWeapons = new List<Dohyeong_WeaponData>(); 
    public Transform weaponHolder;
    private GameObject currentWeaponObject;
    private Dohyeong_ShopData shopData;

    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        shopData = Dohyeong_ShopData.Instance;
    }


    // 구매 가능한지 판단
    public bool CanBuyWeapon(Dohyeong_WeaponData weapon)
    {
        return !ownedWeapons.Contains(weapon) && shopData.dia >= weapon.weaponPrice;
        // 1 반환 시 구매 가능
    }

    // 무기 구매 시
    public bool BuyWeapon(Dohyeong_WeaponData weapon)
    {   
        if(CanBuyWeapon(weapon) && shopData.SpendDia(weapon.weaponPrice))
        {
            ownedWeapons.Add(weapon); // 보유 무기 리스트에 추가
            EquipWeapon(weapon); // 무기 자동 장착
            return true;
        }
        return false;
    }

    public bool IsWeaponOwned(Dohyeong_WeaponData weapon) => ownedWeapons.Contains(weapon);
    // 무기 장착
    public void EquipWeapon(Dohyeong_WeaponData weapon)
    {
        if (!ownedWeapons.Contains(weapon))
            return;
        else
        {
            equippedWeapon = weapon;
            if (currentWeaponObject != null)
            {
                Destroy(currentWeaponObject);
                currentWeaponObject = Instantiate(weapon.weaponPrefab, weaponHolder);
            }
        }
    }
}