using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dohyeong_ShopManager : MonoBehaviour
{
    // 슬롯 프리팹으로 관리
    public GameObject slotPrefab;
    public Transform slotContainer;
    public Button prevButton;
    public Button nextButton;

    [SerializeField]
    private List<Dohyeong_WeaponData> allWeapons;
    private int itemsPerPage = 4; // 한 페이지 당 4 슬롯롯

    private int curPage = 0;
    private int totalPages => Mathf.CeilToInt((float)allWeapons.Count / itemsPerPage);

    void Start()
    {

        if (allWeapons == null)
            allWeapons = new List<Dohyeong_WeaponData>();

        Debug.Log("아이템 갯수: " + allWeapons.Count);  // 아이템 갯수를 확인
    
    
        // 모든 아이템 리스트 로드
        // 초기화 후 배열로 인덱스 부여
    
    
        UpdatePage();

    }

    void UpdatePage()
    {
        // 로드 전 초기화화
        ClearSlots();
        
        int startIndex = curPage * itemsPerPage;
        int endIndex = Mathf.Min(startIndex + itemsPerPage, allWeapons.Count);


        // 페이지 내 업데이트 (0~4)
        for (int i = startIndex; i < itemsPerPage; i++)
        {
            int weaponIndex = startIndex + i;

            GameObject slot = Instantiate(slotPrefab, slotContainer.transform);

            Dohyeong_ShopSlot shopSlot = slot.GetComponent<Dohyeong_ShopSlot>();
            shopSlot.SetSlot(allWeapons[weaponIndex], this);
        }

    }

    void ClearSlots()
    {
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject); // 자식 오브젝트로 있는 슬롯 삭제로 초기화화
        }
    }
    
    
    public void PrevPage()
    {
        if (curPage > 0)
        {
            curPage--;
            UpdatePage();
        }
    }

    public void NextPage()
    {
        if (curPage < totalPages - 1)
        {
            curPage++;
            UpdatePage();
        }
    }
    
    public void PurchaseItem(Dohyeong_WeaponData weapon)
    {
        int playerGold = 1000; // test

        if (playerGold >= weapon.price)
        {
            Debug.Log(weapon.weaponName + "구매 완료");
            playerGold -= weapon.price;
        }
        else {
            Debug.Log("재화가 부족합니다");
        }
    }

}
