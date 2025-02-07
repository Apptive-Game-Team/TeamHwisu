using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHud : MonoBehaviour
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
                myText.text = string.Format("{0:F0}", ShopManager.instance.curCoin);
                break;
            case InfoType.curDamage:
                myText.text = string.Format("{0:F0}", ShopManager.instance.curDamage);
                break;    
        }
    }
}
