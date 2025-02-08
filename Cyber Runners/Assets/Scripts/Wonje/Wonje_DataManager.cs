using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonje_DataManager : MonoBehaviour
{
    public static Wonje_DataManager instance;

    public int curCoin = 9999; // 현재 코인량
    public int curDamage = 9999; // 현재 플레이어 데미지
    public int maxHealth = 9999; // 현재 플레이어 최대체력

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
