using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class Dohyeong_WeaponInfo : MonoBehaviour
{
    // 스크립트 역할: Weapon Info UI 및 안내창 업데이트
    
    public Image weaponIcon;  
    public Text weaponName;   
    public Text weaponDesc;   
    public Text weaponPrice;  
    public Text weaponDamage; 
    public Text weaponCool;
    
    void Start()
    {
        // 처음 시작 상태: 초기화
        ClearInfo();
    }

    public void UpdateInfo(Dohyeong_WeaponData data)
    {
        if (data == null) return;

        weaponIcon.sprite = data.weaponIcon;
        weaponName.text = data.weaponName;
        weaponDesc.text = data.weaponDesc;
        weaponPrice.text = $"{data.weaponPrice}";  
        weaponDamage.text = $"데미지: {data.weaponDamage}";  
        weaponCool.text = $"쿨타임: {data.weaponCool:F2}초";  

    }
    public void ClearInfo()
    {
        weaponIcon.sprite = null;
        weaponName.text = "";
        weaponDesc.text = "";
        weaponPrice.text = "";
        weaponDamage.text = "";
        weaponCool.text = "";
    }
    
}
