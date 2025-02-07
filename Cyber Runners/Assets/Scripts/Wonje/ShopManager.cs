using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public int curCoin = 9999; // 현재 코인량
    public int curDamage = 9999; // 현재 플레이어 데미지
    public int maxHealth = 9999; // 현재 플레이어 최대체력

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void ToShop()
    {
        SceneManager.LoadScene("Wonje");
    }

    public void ToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
