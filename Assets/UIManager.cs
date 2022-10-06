using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager UImanager;

    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private GameObject winCanvas;
    void Awake()
    {
        if (UImanager != null && UImanager != this)
        {
            Destroy(this);
        }
        else
        {
            UImanager = this;
        }
    }

    public void LoseGameAct()
    {
        loseCanvas.SetActive(true);
    } 
    public void WinGameAct()
    {
        winCanvas.SetActive(true);
    }
}
