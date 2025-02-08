using System;
using UnityEngine;
using UnityEngine.UI;

public class Wonje_ShopUpgrade: MonoBehaviour
{
    
    
    public enum InfoType {Health, Damage}
    public InfoType type;
    Text[] myText;

    void Awake()
    {
        myText = GetComponentsInChildren<Text>();
    }

    void LateUpdate()
    {
        switch (type) {
            case InfoType.Health:
                myText[0].text = string.Format("health + {0:F0}", Wonje_ShopManager.instance.increaseHealth);
                myText[1].text = string.Format("{0:F0}", Wonje_ShopManager.instance.costHealth);
                break;  
            case InfoType.Damage:
                myText[0].text = string.Format("damage + {0:F0}", Wonje_ShopManager.instance.increaseDamage);
                myText[1].text = string.Format("{0:F0}", Wonje_ShopManager.instance.costDamage);
                break;   
        }
    }

    public void OnClick()
    {
        switch (type) {
            case InfoType.Health:
                if (Wonje_DataManager.instance.curCoin >= Wonje_ShopManager.instance.costHealth) {
                    Wonje_DataManager.instance.curCoin -= Wonje_ShopManager.instance.costHealth;
                    Wonje_DataManager.instance.maxHealth += Wonje_ShopManager.instance.increaseHealth;
                }
                break;
            case InfoType.Damage:
                if (Wonje_DataManager.instance.curCoin >= Wonje_ShopManager.instance.costDamage) {
                    Wonje_DataManager.instance.curCoin -= Wonje_ShopManager.instance.costDamage;
                    Wonje_DataManager.instance.curDamage += Wonje_ShopManager.instance.increaseDamage;
                }
                break;
        }
    }
}