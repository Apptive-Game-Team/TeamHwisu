using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public WeaponData weapon;
    public Player player;
    public Image imgIcon;
    public Image imgCool;

    void Start()
    {
        imgIcon.sprite = weapon.icon;

        imgCool.fillAmount = 0;
    }

    public void OnClicked(int weaponNum)
    {
        // 쿨타임 때 버튼 클릭 시 무효화
        if (imgCool.fillAmount > 0)
            return;

        // 플레이어 애니메이션 추가 player.ActivateSkill(skill);

        StartCoroutine(CheckedCool());
    }


    IEnumerator CheckedCool()
    {
        imgCool.fillAmount = 1;
        float curTime = 0f;

        while (curTime < weapon.cool)
        {
            curTime += Time.deltaTime;
            imgCool.fillAmount = Mathf.Clamp01(1 - curTime / weapon.cool);
            yield return null;
        }
        imgCool.fillAmount = 0;
    }
}
