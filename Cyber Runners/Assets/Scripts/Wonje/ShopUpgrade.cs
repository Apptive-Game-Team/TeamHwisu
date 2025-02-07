using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgrade: MonoBehaviour
{
    int costDamage = 100; // 데미지업그레이드 비용
    int increaseDamage = 10; // 데미지증가량
    int costHealth = 100; // 체력업그레이드 비용
    int increaseHealth = 10; // 체력증가량량

    public enum InfoType {Damage, Health}
    public InfoType type;
    Text[] myText;

    void Awake()
    {
        myText = GetComponentsInChildren<Text>();
    }

    void LateUpdate()
    {
        switch (type) {
            case InfoType.Damage:
                myText[0].text = string.Format("damage + {0:F0}", increaseDamage);
                myText[1].text = string.Format("damage + {0:F0}", costDamage);
                break;   
        }
    }

    public void OnClick()
    {
        switch (type) {
            case InfoType.Damage:
                if (ShopManager.instance.curCoin >= costDamage) {
                    ShopManager.instance.curCoin -= costDamage;
                    ShopManager.instance.curDamage += increaseDamage;
                }
                break;
        }
    }
}