using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wonje_ShopParty : MonoBehaviour
{
    public RuntimeAnimatorController[] animCon;
    Animator anim;
    Button button;

    public int partyNum; // 파티 순서

    void Awake()
    {
        anim = GetComponent<Animator>();
        button = GetComponentInChildren<Button>();
    }

    void Start()
    {
        anim.runtimeAnimatorController = animCon[Wonje_DataManager.instance.partyCharacterNum[partyNum]];
    }
    
    public void ChooseParty()
    {
        Wonje_DataManager.instance.partyCharacterNum[partyNum] = Wonje_ShopManager.instance.characterNum;
        anim.runtimeAnimatorController = animCon[Wonje_DataManager.instance.partyCharacterNum[partyNum]];
        
        if (Wonje_ShopManager.instance.characterNum == Wonje_DataManager.instance.partyCharacterNum[(partyNum + 1) % 2]) {
            button.onClick.Invoke();
        }
    }

    public void DeleteParty()
    {
        Wonje_DataManager.instance.partyCharacterNum[partyNum] = -1; 
    }
}
