using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Wonje_ShopHud : MonoBehaviour
{
    public enum InfoType {curCoin, curDamage}
    public InfoType type;

    Text myText;

    void Awake()
    {
        myText = GetComponent<Text>();
    }

    void LateUpdate()
    {
        switch (type) {
            case InfoType.curCoin:
                myText.text = string.Format("{0:F0}", Wonje_DataManager.instance.curCoin);
                break;
            case InfoType.curDamage:
                myText.text = string.Format("{0:F0}", Wonje_DataManager.instance.curDamage);
                break;    
        }
    }

    
}
