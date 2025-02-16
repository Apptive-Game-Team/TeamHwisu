using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Wonje_ShopCostText: MonoBehaviour
{
    public enum InfoType {SkillCost, HealthCost, DamageCost}
    public InfoType type;
    Text myText;

    void Awake()
    {
        myText = GetComponent<Text>();
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

    

    
}