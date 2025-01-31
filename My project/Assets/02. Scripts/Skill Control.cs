using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
public class SkillUI : MonoBehaviour
{
    public GameObject[] hideSkillButtons;
    public GameObject[] textPros;
    public TextMeshProUGUI[] hideSkillTimeTexts; // 쿨타임 시간 표시
    public Image[] hideSkillImages;
    private bool[] isHideSkills = {false, false, false};
    private float[] coolTimes = {3, 6, 9};
    private float[] getSkillTimes = {0, 0, 0}; // 스킬의 남은 쿨타임임

    private SkillSpawner skillSpawner;

    void Start()
    {
        skillSpawner = FindObjectOfType<SkillSpawner>();

        for(int i = 0; i < textPros.Length; i++)
        {
            hideSkillTimeTexts[i] = textPros[i].GetComponent<TextMeshProUGUI>();
            hideSkillButtons[i].SetActive(false);
        }
    }

    void Update()
    {
        HideSkillChk();
    }

    
    public void OnSkillButtonClicked(int skillNum) // 버튼 클릭 시 발동되는 함수
    {
        // 스킬 발동 관련
        if(skillSpawner != null)
        {
            skillSpawner.UseSkill((SkillType)skillNum);
        }

        // 버튼 쿨타임 UI 관련
        hideSkillButtons[skillNum].SetActive(true); // 버튼 비활성화
        getSkillTimes[skillNum] = coolTimes[skillNum]; // 쿨타임 시간 반영
        isHideSkills[skillNum] = true; // 스킬 사용 상태 나타내는 bool 변수 저장
    }


    private void HideSkillChk()
    {
        // 스킬 사용 상태 변수 받아서 코루틴 실행
        if(isHideSkills[0])
        {
            StartCoroutine(SkillTimeChk(0));
        }

        if(isHideSkills[1])
        {
            StartCoroutine(SkillTimeChk(1));
        }

        if(isHideSkills[2])
        {
            StartCoroutine(SkillTimeChk(2));
        }
    }

    IEnumerator SkillTimeChk(int skillNum)
    {
        yield return null;

        if(getSkillTimes[skillNum] > 0)
        {
            getSkillTimes[skillNum] -= Time.deltaTime;

            if(getSkillTimes[skillNum] < 0) // 남은 시간이 0보다 작아짐 -> 스킬 사용 가능 상태태
            {
                getSkillTimes[skillNum] = 0;
                isHideSkills[skillNum] = false; // 스킬 사용 가능 상태로 변경
                hideSkillButtons[skillNum].SetActive(false); // 버튼 비활성화
            }

            hideSkillTimeTexts[skillNum].text = getSkillTimes[skillNum].ToString("00");

            float time = getSkillTimes[skillNum] / coolTimes[skillNum];
            hideSkillImages[skillNum].fillAmount = time;
        }
    }

    /*
    private void SpawnWeapon(int skillNum)
        {
            if (weaponPrefabs[skillNum] != null && spawnPoint != null)
            {
                Instantiate(weaponPrefabs[skillNum], spawnPoint.position,Quaternion.identity);
            }
        }
    */
}
