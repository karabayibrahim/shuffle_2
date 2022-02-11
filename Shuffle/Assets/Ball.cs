using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public GameObject pv;
    public float Speed;
    private int tour;
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
        int rnd = Random.Range(0,2);
        float tour;
        if (rnd==0)
        {
            tour = 2.951f;
            Debug.Log(tour + "Kırmızı");
        }
        else
        {
            tour = 3f;
            Debug.Log(tour + "Siyah");
        }
        //Debug.Log("Random" + rnd);
        DOTween.To(() => Speed, x => Speed = x, 0f,tour).OnComplete(() => transform.DOLocalMove(new Vector3(transform.localPosition.x-0.002f, transform.localPosition.y-0.0002f, transform.localPosition.z-0.0008f), 0.5f));
    }
}
