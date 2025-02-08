using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wonje_ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Wonje_ShopManager instance;

    void Awake()
    {
        instance = this;
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Wonje_Main");
    }
}
