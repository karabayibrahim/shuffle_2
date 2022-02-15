using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Finish : MonoBehaviour,ICollectable
{
    public static Action FinishEvent;
    public void DoCollect(GameObject _object)
    {
        FinishEvent?.Invoke();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Player.LeftHand.FinishPanelControl&& GameManager.Instance.Player.RightHand.FinishPanelControl)
        {
            StartCoroutine(WinPanelTimer());
        }
    }

    private IEnumerator WinPanelTimer()
    {
        yield return new WaitForSeconds(2f);
        UIManager.WinEvent?.Invoke();
        yield break;
    }
}
