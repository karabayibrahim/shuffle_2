using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class Ball : MonoBehaviour
{
    public GameObject pv;
    public float Speed;
    public static Action<int> ResultEvent;
    private int _result;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pv.transform.position, new Vector3(0, 1, 0),Speed*Time.deltaTime);
    }

    public void RandomSelectBet()
    {
        int rnd = UnityEngine.Random.Range(0,2);
        float tour;
        if (rnd==0)
        {
            tour = 2.94f;
            _result = 0;
        }
        else
        {
            tour = 3f;
            _result = 1;
        }
        //Debug.Log("Random" + rnd);
        DOTween.To(() => Speed, x => Speed = x, 0f,tour).OnComplete(() => transform.DOLocalMove(new Vector3(transform.localPosition.x-0.002f, transform.localPosition.y-0.0002f, transform.localPosition.z-0.0008f), 0.5f).OnComplete(()=>ResultEvent?.Invoke(_result)));
    }
}
