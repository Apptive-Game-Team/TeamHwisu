using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dohyeong_ShopData : MonoBehaviour
{   
    // 스크립트 역할 : 재화 관리
    public static Dohyeong_ShopData Instance;
    public int dia = 1000; // test 초기 재화


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public bool SpendDia(int amount)
    {
        if (dia >= amount)
        {
            dia -= amount;
            return true;
        }
        return false;
    }

    public void AddDia(int amount)
    {
        // 다이아 추가 가능한 로직..
        dia += amount;
    }
}
