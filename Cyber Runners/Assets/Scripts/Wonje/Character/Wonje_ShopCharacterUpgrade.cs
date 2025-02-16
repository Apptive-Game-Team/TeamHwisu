using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wonje_ShopCharacterUpgrade : MonoBehaviour
{
    public Sprite[] upgradeBarSprite;

    private Image[] upgradeStatus;

    void Awake()
    {
        upgradeStatus = GetComponentsInChildren<Image>();
    }

    void Start()
    {
        UpdateUpgradeBar();
    }

    void OnEnable()
    {
        UpdateUpgradeBar();
    }

    public void CharacterUpgrade()
    {
        if (Wonje_DataManager.instance.curCoin >= Wonje_ShopManager.instance.costSkill && Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum] != Wonje_ShopManager.instance.maxSkillLevel) {
            Wonje_DataManager.instance.curCoin -= Wonje_ShopManager.instance.costSkill;
            Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum]++;
            UpdateUpgradeBar(); 
        } 
        else if (Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum] == Wonje_ShopManager.instance.maxSkillLevel) {

        }   
    }

    public void ResetUpgrade()
    {
        Wonje_DataManager.instance.curCoin += Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum] * Wonje_ShopManager.instance.costSkill;
        Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum] = 0;
        UpdateUpgradeBar(); 
    }

    public void UpdateUpgradeBar()
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
    }
}