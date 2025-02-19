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

    public Button equipButton;
    public Button buyButton;

    private Dohyeong_WeaponData currentWeapon = null;
    private Dohyeong_WeaponManager weaponManager;
    private Dohyeong_ShopData shopData;
    
    void Start()
    {
        weaponManager = Dohyeong_WeaponManager.Instance;
        shopData = Dohyeong_ShopData.Instance;

        // 처음 시작 상태: 초기화
        ClearInfo();
    }

    public void UpdateInfo(Dohyeong_WeaponData data)
    {
        if (data == null) return;

        currentWeapon = data;

        weaponIcon.sprite = data.weaponIcon;
        weaponName.text = data.weaponName;
        weaponDesc.text = data.weaponDesc;
        weaponPrice.text = $"{data.weaponPrice}";  
        weaponDamage.text = $"데미지: {data.weaponDamage}";  
        weaponCool.text = $"쿨타임: {data.weaponCool:F2}초";  

        // 무기가 보유 중인지 체크
        // isOwned = weaponManager.IsWeaponOwned(currentWeapon);
        UpdateButtons();
    }

    void UpdateButtons()
    {
        bool isOwned = weaponManager.IsWeaponOwned(currentWeapon);
        buyButton.gameObject.SetActive(!isOwned);
        equipButton.gameObject.SetActive(isOwned);
    }

    public void ClearInfo()
    {

        currentWeapon = null;

        weaponIcon.sprite = null;
        weaponName.text = "";
        weaponDesc.text = "";
        weaponPrice.text = "";
        weaponDamage.text = "";
        weaponCool.text = "";
    }
    
    // buy, equipped 버튼 업데이트 어케할건지..생각
    public void BuyWeapon()
    {
        if (currentWeapon == null) return;

        if (weaponManager.BuyWeapon(currentWeapon))
        {
            Debug.Log($"{currentWeapon.weaponName} 무기 구매 및 장착 완료");
        }
        else
        {
            Debug.Log("구매 실패: 재화 부족 또는 이미 보유 중");
        }
        UpdateButtons();
    }
    public void EquipWeapon()
    {
        if (currentWeapon == null) return;
        weaponManager.EquipWeapon(currentWeapon);
        Debug.Log($"{currentWeapon.weaponName} 무기 장착 완료");
        UpdateButtons();
    }



}
