using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/WeaponData")]
public class Dohyeong_WeaponData : ScriptableObject
{
    [Header("# 상점 표시 데이터")]
    public string weaponName;
    public int weaponPrice;
    public Sprite weaponIcon;
    public float weaponDamage;
    public float weaponCool;
    public AnimationClip weaponAnim; // 상점 상 애니메이션
    [TextArea(2, 3)]
    public string weaponDesc; // 상점 상 무기 설명
    
    [Header("# 추후 결정")]

    public float weaponSpeed;
    public GameObject weaponPrefab;
    
    

}
