using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wonje_ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Wonje_ShopManager instance;

    public int costHealth = 100; // 체력업그레이드 비용
    public int increaseHealth = 10; // 체력증가량량
    public int costDamage = 100; // 데미지업그레이드 비용
    public int increaseDamage = 10; // 데미지증가량

    void Awake()
    {
        instance = this;
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Wonje_Main");
    }


}
