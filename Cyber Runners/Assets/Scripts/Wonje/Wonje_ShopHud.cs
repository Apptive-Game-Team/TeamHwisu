using UnityEngine;
using UnityEngine.UI;

public class Wonje_ShopHud : MonoBehaviour
{
    public enum InfoType { curCoin, maxHealth, curDamage }
    public InfoType type;

    private Text myText;
    private int lastValue; 

    void Awake()
    {
        myText = GetComponent<Text>();
        UpdateText(); 
    }

    void Update()
    {
        if (ValueChanged()) 
        {
            UpdateText();
        }
    }

    bool ValueChanged()
    {
        switch (type)
        {
            case InfoType.curCoin:
                return lastValue != Wonje_DataManager.instance.curCoin;
            case InfoType.maxHealth:
                return lastValue != Wonje_DataManager.instance.maxHealth;
            case InfoType.curDamage:
                return lastValue != Wonje_DataManager.instance.curDamage;
        }
        return false;
    }

    void UpdateText()
    {
        switch (type)
        {
            case InfoType.curCoin:
                lastValue = Wonje_DataManager.instance.curCoin;
                myText.text = string.Format("{0:F0}", lastValue);
                break;
            case InfoType.maxHealth:
                lastValue = Wonje_DataManager.instance.maxHealth;
                myText.text = string.Format("{0:F0}", lastValue);
                break;
            case InfoType.curDamage:
                lastValue = Wonje_DataManager.instance.curDamage;
                myText.text = string.Format("{0:F0}", lastValue);
                break;
        }
    }
}
