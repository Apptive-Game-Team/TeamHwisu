using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wonje_ShopCharacterSkill : MonoBehaviour
{
    public enum InfoType { SkillInfo, curLevelData, nextLevelData }
    public InfoType type;

    private Text myText;

    private string[] skillDescriptions  = // 스킬 설명
    {
        "보호막을 부여합니다",   // 캐릭터 0번
        "장애물 속도이 오는 속도가 늦어집니다",   // 캐릭터 1번
        "", // 캐릭터 2번
    };

    private string[] skillInfo = // 스킬 정보
    {
        "보호막 수치",  // 캐릭터 0번
        "속도 감소",  // 캐릭터 1번
        ""  // 캐릭터 2번
    };

    void Awake()
    {
        myText = GetComponent<Text>();
    }

    void Start()
    {
        UpdateSkillInfo();
    }

    void OnEnable()
    {
        UpdateSkillInfo();
    }

    public void UpdateSkillInfo()
    {
        int characterNum = Wonje_ShopManager.instance.characterNum;
        int maxSkillLevel = Wonje_ShopManager.instance.maxSkillLevel;
        int[] characterUpgradeStatus = Wonje_DataManager.instance.characterUpgradeStatus;
        int[] increaseSkillEffect = Wonje_ShopManager.instance.increaseSkillEffect;

        switch (type)
        {
            case InfoType.SkillInfo:
                myText.text = skillDescriptions[characterNum];
                break;
            case InfoType.curLevelData:
                myText.text = string.Format("{0:F0} + <color=#00FF00>{1:F0}</color>", skillInfo[characterNum], increaseSkillEffect[characterNum] * characterUpgradeStatus[characterNum]);
                break;
            case InfoType.nextLevelData:
                if (characterUpgradeStatus[characterNum] == maxSkillLevel) {
                    myText.text = "<color=#FF0000>최대레벨입니다</color>";
                }
                else {
                    myText.text = string.Format("{0:F0} + <color=#00FF00>{1:F0}</color>", skillInfo[characterNum], increaseSkillEffect[characterNum] * (characterUpgradeStatus[characterNum] + 1));
                }
                break;
        }
    }
}
