using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dohyeong_ShopSlot : MonoBehaviour
{
    // 스크립트 역할
    // 1. 구매 버튼 활성화 -> ShopManager.Purchase() 작동
    // 2. 슬롯에 아이템 데이터 나열
    public Image iconImage;
    public Text weaponNameText;
    public Text priceText;
    public Button buyButton;

    private Dohyeong_WeaponData currentWeapon; // WeaponData : 스크립터블 오브젝트로 담은 Weapon 아이템 정보들
    private Dohyeong_ShopManager shopManager;
    
    public void SetSlot(Dohyeong_WeaponData weapon, Dohyeong_ShopManager manager)
    {
        currentWeapon = weapon;
        shopManager = manager;


        // UI 업데이트
        // 1. 무기 아이콘 2. 무기 이름 3. 무기 가격
        iconImage.sprite = weapon.icon;
        weaponNameText.text = weapon.weaponName;
        priceText.text = weapon.price.ToString();

    }

    void BuyItem()
    {
        if (shopManager != null) // || Shop 매니저에 연결된 재화가 돈보다 많고 )
        {
            shopManager.PurchaseItem(currentWeapon);
        }

    }
}
