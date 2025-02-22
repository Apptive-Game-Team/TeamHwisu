using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Wonje_ShopHud : MonoBehaviour
{
    public enum InfoType { Menu, Character, Ability, Weapon, Setting, Coin}
    public InfoType type;

    private RectTransform rectTransform;
    private Vector2 showPosition; // 보이는 위치
    private Vector2 hidePosition; // 숨겨진 위치
    private float duration = 0.2f; // 애니메이션 지속 시간
    private Coroutine moveCoroutine;
    

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        switch (type) {
            case InfoType.Menu:
                hidePosition = new Vector2(800f, rectTransform.anchoredPosition.y);
                break;
            case InfoType.Character:
            case InfoType.Ability:
            case InfoType.Weapon:
            case InfoType.Setting:
                hidePosition = new Vector2(-800f, rectTransform.anchoredPosition.y);
                break;
            case InfoType.Coin:
                hidePosition = new Vector2(-108f, rectTransform.anchoredPosition.y);
                break;    
        }

        showPosition = rectTransform.anchoredPosition;
        rectTransform.anchoredPosition = hidePosition;

        gameObject.SetActive(false);

        switch (type) {
            case InfoType.Menu:
            case InfoType.Character:
            case InfoType.Coin:
                ShowUI();
                break;
        }
    }

    public void ShowUI()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        gameObject.SetActive(true); 

        moveCoroutine = StartCoroutine(MoveUI(showPosition, duration, false, false));
    }

    public void HideUI(bool loadSceneAfter = false)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveUI(hidePosition, duration, true, loadSceneAfter));
    }

    public void HideUIAndLoadScene()
    {
        HideUI(true);
    }

    private IEnumerator MoveUI(Vector2 target, float duration, bool deactivateAfter = false, bool loadSceneAfter = false)
    {
        Vector2 start = rectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(start, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = target;
        moveCoroutine = null;

        if (deactivateAfter)
        {
            gameObject.SetActive(false);
        }

        if (loadSceneAfter)
        {
            Wonje_ShopManager.instance.ResetParty();
            SceneManager.LoadScene("Test_Main_Wonje");
        }
    }
}
