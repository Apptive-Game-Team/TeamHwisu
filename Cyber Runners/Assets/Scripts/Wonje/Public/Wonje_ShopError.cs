using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wonje_ShopError : MonoBehaviour
{
    public int partyNum; 

    private Text myText;
    private CanvasGroup canvasGroup;
    private Coroutine errorCoroutine;

    private void Awake()
    {
        myText = GetComponentInChildren<Text>();
        canvasGroup = GetComponent<CanvasGroup>();

        transform.localScale = Vector3.zero;
        canvasGroup.alpha = 1f;
    }

    private void Start()
    {
        gameObject.SetActive(false);   
    }

    public void ErrorSkillUpgrade()
    {
        if (Wonje_DataManager.instance.characterUpgradeStatus[Wonje_ShopManager.instance.characterNum] == Wonje_ShopManager.instance.maxSkillLevel) {
            ShowError("이미 최대 레벨입니다.");
        } 
        else if (Wonje_DataManager.instance.curCoin < Wonje_ShopManager.instance.costSkill) {
            ShowError("현재 코인이 부족합니다다.");
        }
    }

    public void ErrorParty1()
    {
        if (Wonje_DataManager.instance.partyCharacterNum[1] == Wonje_ShopManager.instance.characterNum) {
            ShowError("이미 캐릭터가 2번 파티에 포함되어 있습니다.");
        }
    }

    public void ErrorParty2()
    {
        if (Wonje_DataManager.instance.partyCharacterNum[0] == Wonje_ShopManager.instance.characterNum) {
            ShowError("이미 캐릭터가 1번 파티에 포함되어 있습니다.");
        }
    }

    private void ShowError(string message)
    {
        if (errorCoroutine != null) {
            StopCoroutine(errorCoroutine); 
        }

        gameObject.SetActive(true);
        myText.text = message;
        transform.localScale = Vector3.zero; 
        canvasGroup.alpha = 1f; 

        errorCoroutine = StartCoroutine(AnimateError());
    }

    private IEnumerator AnimateError()
    {
        float appearDuration = 0.2f; // 등장 애니메이션 시간
        float fadeOutDuration = 0.8f; // 사라지는 애니메이션 시간
        float elapsedTime = 0f;

        while (elapsedTime < appearDuration) {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / appearDuration;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }

        transform.localScale = Vector3.one; 
        yield return new WaitForSeconds(1f); 

        elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration) {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeOutDuration;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
        errorCoroutine = null; 
    }
}
