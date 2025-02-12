using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Wonje_ShopUpgrade: MonoBehaviour
{
    public enum InfoType {Skill, Health, Damage}
    public InfoType type;
    public Sprite[] upgradeBarSprite;
    Text[] myText;
    Image[] upgradeStatus;

    void Awake()
    {
        myText = GetComponentsInChildren<Text>();
        upgradeStatus = GetComponentsInChildren<Image>();
    }

    void Start()
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
            case InfoType.Skill:
                StartCoroutine(UpdateUpgradeBar());
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

    public void CharacterUpgrade()
    {
        Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum]++;
    }

    public void UpgradeReset()
    {
        Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum] = 0;
    }


    IEnumerator UpdateUpgradeBar()
    {
        while (true)
        {
            int upgradeLevel = Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum];
            
            for (int i = 1; i < upgradeStatus.Length; i++)
            {
                upgradeStatus[i].sprite = upgradeBarSprite[0]; 
            }

            for (int i = 1; i < upgradeLevel + 1 && i < upgradeStatus.Length; i++)
            {
                upgradeStatus[i].sprite = upgradeBarSprite[1]; 
            }

            yield return new WaitForSeconds(0); 
        }
    }
}