using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Wonje_ShopCostText: MonoBehaviour
{
    public enum InfoType {SkillCost, HealthCost, DamageCost}
    public InfoType type;

    private Text myText;
    private RectTransform parentRect;
    private Coroutine activeCheckCoroutine;

    void Awake()
    {
        myText = GetComponent<Text>();
        parentRect = gameObject.transform.parent.GetComponent<RectTransform>();
    }

    void Start()
    {
        switch (type) { 
            case InfoType.SkillCost:
                myText.text = string.Format("{0:F0}", Wonje_ShopManager.instance.costSkill);
                break;    
            case InfoType.HealthCost:
                myText.text = string.Format("{0:F0}", Wonje_ShopManager.instance.costHealth);
                break;        
            case InfoType.DamageCost:
                myText.text = string.Format("{0:F0}", Wonje_ShopManager.instance.costDamage);
                break;     
        }
    }

    void OnEnable()
    {
        switch (type) {
            case InfoType.SkillCost:
                if (activeCheckCoroutine != null) 
                {
                    StopCoroutine(activeCheckCoroutine);
                }

                activeCheckCoroutine = StartCoroutine(ActiveCheck());
            break;
        } 
    }

    IEnumerator ActiveCheck()
    {
        while (gameObject.activeInHierarchy) {      
            int charNum = Wonje_ShopManager.instance.characterNum;
            int upgradeStatus = Wonje_DataManager.instance.characterUpgradeStatus[charNum];
            int maxSkillLevel = Wonje_ShopManager.instance.maxSkillLevel;

            if (upgradeStatus == maxSkillLevel) {
                parentRect.localScale = Vector3.zero;
            }
            else {
                parentRect.localScale = Vector3.one;
            }
    
            yield return new WaitForSeconds(0);  
        }
    }
}