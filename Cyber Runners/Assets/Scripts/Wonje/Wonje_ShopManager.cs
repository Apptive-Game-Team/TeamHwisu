using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wonje_ShopManager : MonoBehaviour
{
    public static Wonje_ShopManager instance;

    public int costHealth = 100; // 체력업그레이드 비용
    public int increaseHealth = 10; // 체력증가량
    public int costDamage = 100; // 데미지업그레이드 비용
    public int increaseDamage = 10; // 데미지증가량
    public int characterNum = 0; // 보여지는 캐릭터의 넘버

    int[] ResetParty = new int[2] {0, 1};
    
    void Awake()
    {
        instance = this;
    }

    public void Reset()
    {
        Wonje_DataManager.instance.partyCharacterNum = ResetParty;
    }

    public void ToGame()
    {
        if (Wonje_DataManager.instance.partyCharacterNum[0] == -1 || Wonje_DataManager.instance.partyCharacterNum[1] == -1) {
            Reset();
        }
        
        SceneManager.LoadScene("Wonje_Main");
    }


}