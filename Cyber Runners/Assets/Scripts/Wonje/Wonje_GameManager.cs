using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wonje_GameManager : MonoBehaviour
{
    public static Wonje_GameManager instance;

    void Awake()
    {
        instance = this;
    }

    public void ToShop()
    {
        SceneManager.LoadScene("Wonje_Shop");
    }
}
