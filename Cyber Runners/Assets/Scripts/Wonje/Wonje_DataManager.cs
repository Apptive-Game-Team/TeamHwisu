using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Wonje_DataManager : MonoBehaviour
{
    public static Wonje_DataManager instance;

    public int curCoin = 9999; // 현재 코인량
    public int maxHealth = 0000; // 현재 플레이어 최대체력
    public int curDamage = 0000; // 현재 플레이어 데미지
    public int backgroundNum = 3; // 배경 이미지

    public int[] partyCharacterNum = new int[2] {0, 1}; // 파티로 데려갈 캐릭터의 넘버, 기본으로 캐릭터 0번과 1번이 선택되어있다
    public int[] characterUpgradeStatus = new int[3]; // 캐릭터별 강화 수치
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
