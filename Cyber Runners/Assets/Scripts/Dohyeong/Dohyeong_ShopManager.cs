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
    public Dohyeong_WeaponInfo weaponInfo;

    [SerializeField]
    private List<Dohyeong_WeaponData> allWeapons;
    private int itemsPerPage = 4; // 한 페이지 당 4 슬롯

    private int curPage = 0;
    private int totalPages => Mathf.CeilToInt((float)allWeapons.Count / itemsPerPage);

    void Start()
    {
        UpdatePage();
    }

    void UpdatePage()
    {
        // 로드 전 초기화
        ClearSlots();

        prevButton.interactable = curPage > 0;
        nextButton.interactable = curPage < totalPages -1;
        
        int startIndex = curPage * itemsPerPage;
        int endIndex = Mathf.Min(startIndex + itemsPerPage, allWeapons.Count);


        // 페이지 내 업데이트
        for (int i = startIndex; i < endIndex; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotContainer.transform);

            Dohyeong_ShopSlot shopSlot = slot.GetComponent<Dohyeong_ShopSlot>();
            
            // 스크립터블 오브젝트에서 데이터 가져오기
            if (allWeapons[i] != null)
            {
                shopSlot.Setup(allWeapons[i], weaponInfo);  // 스크립터블 오브젝트를 전달하여 UI 업데이트
            }
            else
            {
                Debug.LogError($" allWeapons[{i}]가 null입니다!");
            }
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
    

}
