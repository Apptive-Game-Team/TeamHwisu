using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonje_ShopCharacter : MonoBehaviour
{
    public RuntimeAnimatorController[] animCon;
    private Animator anim;
    private RectTransform[] rectTransform; // 잠금 이미지의 RectTransform
    private Coroutine lockCheckCoroutine; // 현재 실행 중인 코루틴을 저장할 변수
    private bool characterLock = false; // 캐릭터 잠금 여부

    void Awake()
    {
        anim = GetComponent<Animator>();
        rectTransform = GetComponentsInChildren<RectTransform>(); 
    }

    void Start() 
    {
        if (lockCheckCoroutine == null) {
            lockCheckCoroutine = StartCoroutine(LockCheck());
        }
    }

    void OnEnable()
    {
        if (lockCheckCoroutine != null) {
            StopCoroutine(lockCheckCoroutine);
        }

        lockCheckCoroutine = StartCoroutine(LockCheck()); 
    }

    public void NextCharacter()
    {
        Wonje_ShopManager.instance.characterNum = (Wonje_ShopManager.instance.characterNum + 1) % animCon.Length;
        SetCharacterAnimation();
    }

    public void PreviousCharacter()
    {
        Wonje_ShopManager.instance.characterNum = (Wonje_ShopManager.instance.characterNum - 1 + animCon.Length) % animCon.Length;
        SetCharacterAnimation();
    }

    void SetCharacterAnimation()
    {
        anim.runtimeAnimatorController = animCon[Wonje_ShopManager.instance.characterNum];  
    }

    IEnumerator LockCheck()
    {
        while (true) {
            bool isLocked = (Wonje_DataManager.instance.partyCharacterNum[0] == Wonje_ShopManager.instance.characterNum || 
                             Wonje_DataManager.instance.partyCharacterNum[1] == Wonje_ShopManager.instance.characterNum);

            if (characterLock != isLocked) 
            {
                characterLock = isLocked;
                SetVisibility(characterLock); 
                anim.speed = characterLock ? 0 : 1;
            }

            yield return new WaitForSeconds(0f); 
        }
    }

    void SetVisibility(bool isLocked)
    {
        if (isLocked)
        {
            rectTransform[1].localScale = Vector3.one; 
        }
        else
        {
            rectTransform[1].localScale = Vector3.zero; 
        }
    }
}
