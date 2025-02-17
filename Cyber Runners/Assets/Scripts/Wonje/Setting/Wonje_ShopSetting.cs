using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonje_ShopSetting : MonoBehaviour
{
    public RuntimeAnimatorController[] animCon;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>(); 
    }

    void Start()
    {
        switch (Wonje_DataManager.instance.backgroundNum) {
            case 0:
                SetMorning();
                break;
            case 1:
                SetLunch();
                break;
            case 2:
                SetEvening();
                break;
            case 3:
                SetNight();
                break;            
        }
    }

    public void SetMorning()
    {
        Wonje_DataManager.instance.backgroundNum = 0;
        transform.localScale = new Vector3(3.7f, 3.7f, 1f);
        SetBackground();
    }

    public void SetLunch()
    {
        Wonje_DataManager.instance.backgroundNum = 1;
        transform.localScale = new Vector3(3.7f, 3.7f, 1f);
        SetBackground();
    }

    public void SetEvening()
    {
        Wonje_DataManager.instance.backgroundNum = 2;
        transform.localScale = new Vector3(3.7f, 3.7f, 1f);
        SetBackground();
    }

    public void SetNight()
    {
        Wonje_DataManager.instance.backgroundNum = 3;
        transform.localScale = new Vector3(3.7f, 1.8f, 1f);
        SetBackground();
    }

    void SetBackground()
    {
        anim.runtimeAnimatorController = animCon[Wonje_DataManager.instance.backgroundNum];
    }
}
