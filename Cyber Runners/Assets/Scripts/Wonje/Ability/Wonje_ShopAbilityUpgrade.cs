using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wonje_ShopAbilityUpgrade : MonoBehaviour
{
    public enum InfoType {Health, Damage}
    public InfoType type;

    Text myText;

    void Awake()
    {
        myText = GetComponent<Text>();
    }

    void Start()
    {
        switch (type) { 
            case InfoType.Health:
                myText.text = string.Format("health + {0:F0}", Wonje_ShopManager.instance.increaseHealth);
                break;  
            case InfoType.Damage:
                myText.text = string.Format("Damage + {0:F0}", Wonje_ShopManager.instance.increaseDamage);
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
