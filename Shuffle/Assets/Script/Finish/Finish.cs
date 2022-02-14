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
        StartCoroutine(WinPanelTimer());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WinPanelTimer()
    {
        yield return new WaitForSeconds(5f);
        UIManager.WinEvent?.Invoke();
        yield break;
    }
}
