using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonje_ShopCharacter : MonoBehaviour
{
    public RuntimeAnimatorController[] animCon;

    int characterNum = 0;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

        anim.runtimeAnimatorController = animCon[characterNum];
    }

    public void NextCharacter()
    {
        characterNum = (characterNum + 1) % animCon.Length;

        anim.runtimeAnimatorController = animCon[characterNum];
    }

    public void PrevoiusCharacter()
    {
        characterNum = (characterNum - 1 + animCon.Length) % animCon.Length;

        anim.runtimeAnimatorController = animCon[characterNum];
    }
}
