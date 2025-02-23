using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dohyeong_ShopSlot : MonoBehaviour
{
    // 스크립트 역할
    // 1. Weapon Slot 상 UI 업데이트
    public Animator weaponAnim;
    public Image weaponIcon;
    public Text weaponName;
    public Text weaponPrice;
    public Text weaponDamage;
    public Text weaponCool;
    

    private Dohyeong_WeaponData weaponData; // 무기 데이터
    private Dohyeong_WeaponInfo weaponInfo; // Info 창 UI 업데이트트

    void Start()
    {
        weaponAnim = GetComponent<Animator>();    
    }


    public void Setup(Dohyeong_WeaponData data, Dohyeong_WeaponInfo info)
    {
        // 페이지 당 슬롯 4개 UI 업데이트

        // 1. 무기 아이콘 2. 무기 이름 3. 무기 가격
        // 4. 무기 데미지 5. 무기 쿨타임

        weaponData = data;
        weaponInfo = info;

        weaponIcon.sprite= weaponData.weaponIcon;
        weaponName.text = weaponData.weaponName;
        weaponPrice.text = weaponData.weaponPrice.ToString();
        weaponDamage.text = $"데미지: {weaponData.weaponDamage}"; 
        weaponCool.text = $"쿨타임: {weaponData.weaponCool}초"; 
        weaponAnim.SetTrigger(weaponData.animationTrigger);

        // 클릭 시 Info UI 업데이트 버튼 이벤트트 -> 인스펙터로
    }

    public void SelectWeapon()
    {
        if (weaponInfo != null)
        {
            weaponInfo.UpdateInfo(weaponData);
        }
    }

}
