using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonje_ShopParty : MonoBehaviour
{
    public RuntimeAnimatorController[] animCon;

    Animator anim;

    public int partyNum; // 파티 순서

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        anim.runtimeAnimatorController = animCon[Wonje_DataManager.instance.partyCharacterNum[partyNum]];
    }
    
    public void ChooseParty()
    {
        if (Wonje_ShopManager.instance.characterNum != Wonje_DataManager.instance.partyCharacterNum[(partyNum + 1) % 2]) {
            Wonje_DataManager.instance.partyCharacterNum[partyNum] = Wonje_ShopManager.instance.characterNum;
            anim.runtimeAnimatorController = animCon[Wonje_DataManager.instance.partyCharacterNum[partyNum]];
        }
    }

    public void DeleteParty()
    {
        Wonje_DataManager.instance.partyCharacterNum[partyNum] = -1; 
    }
}
