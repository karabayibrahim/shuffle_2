using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class GameManager : MonoSingleton<GameManager>
{
    public PlayerControl Player;
    public CinemachineVirtualCamera LevelCam;
    public ATM ATM;
    public UIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
