using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class UIManager : MonoBehaviour
{
    public static Action RestartEvent;
    public static Action WinEvent;
    [Header("RestartPanel")]
    public GameObject RestartPanel;
    public Button RestartButton;
    [Header("GamePanel")]
    public GameObject GamePanel;
    [Header("WinPanel")]
    public GameObject WinPanel;
    public Button WinButton;

    void Start()
    {
        RestartEvent += RestartStatus;
        WinEvent += WinStatus;
        RestartButton.onClick.AddListener(RestartOperation);
        WinButton.onClick.AddListener(RestartOperation);
    }

    private void OnDisable()
    {
        RestartButton.onClick.RemoveListener(RestartOperation);
        WinButton.onClick.RemoveListener(RestartOperation);
        RestartEvent -= RestartStatus;
        WinEvent -= WinStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RestartOperation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RestartStatus()
    {
        GamePanel.SetActive(false);
        RestartPanel.SetActive(true);
    }

    private void WinStatus()
    {
        GamePanel.SetActive(false);
        WinPanel.SetActive(true);
    }

}
