using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wonje_ShopManager : MonoBehaviour
{
    public static Wonje_ShopManager instance;

    public int maxSkillLevel = 25; // 최대 스킬 업그레이드 레벨
    public int costSkill = 100; // 스킬 업그레이드 비용
    public int[] increaseSkillEffect = { 10, 2, 0 }; // 캐릭터별 레벨에 따른 스킬 효과 증가량 
    public int increaseHealth = 10; // 체력 증가량
    public int costHealth = 100; // 체력 업그레이드 비용
    public int increaseDamage = 10; // 데미지 증가량
    public int costDamage = 100; // 데미지 업그레이드 비용
    public int characterNum = 0; // 보여지는 캐릭터의 넘버
    
    int[] ResetPartyNum = new int[2] {0, 1}; // 파티의 캐릭터를 초기화
    
    void Awake()
    {
        instance = this;
    }

    public void ResetParty()
    {
        if (Wonje_DataManager.instance.partyCharacterNum[0] == -1 || Wonje_DataManager.instance.partyCharacterNum[1] == -1) {
            Wonje_DataManager.instance.partyCharacterNum = ResetPartyNum;
        }
    }


}