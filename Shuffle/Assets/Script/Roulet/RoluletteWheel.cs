using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RoluletteWheel : MonoBehaviour
{
    public float Speed;
    public Vector3 StartScale;
    public Ball MyBall;
    void Start()
    {
        StartGrow();
    }

    // Update is called once per frame
    void Update()
    {
       RotateMethod();
    }

    private void RotateMethod()
    {
        transform.Rotate(0, 0, Time.deltaTime * Speed);
    }

    private void StartGrow()
    {
        Speed = Random.Range(500f, 1001f);
        StartScale = transform.localScale;
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(StartScale, 2f).OnComplete(() =>
        {
            DOTween.To(() => Speed, x => Speed = x, 0f, 1);
            MyBall.RandomSelectBet();
        });
    }
}
