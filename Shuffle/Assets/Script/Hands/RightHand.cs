using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RightHand : MonoBehaviour
{
    public GameObject OtherHand;
    public List<Money> MyMoneys = new List<Money>();
    private Sequence seq;
    void Start()
    {
        foreach (var item in gameObject.GetComponentsInChildren<Money>())
        {
            MyMoneys.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SwipeMove();
    }

    private void SwipeMove()
    {
        var moveObject = MyMoneys[MyMoneys.Count - 1];
        if (Input.GetKeyDown(KeyCode.Space))
        {
            seq = DOTween.Sequence();
            Vector3 myPoz = moveObject.transform.localPosition;
            moveObject.transform.SetParent(OtherHand.transform);
            MyMoneys.Remove(moveObject);
            seq.Append(moveObject.transform.DOLocalMoveZ((-0.003f), 0.1f));
            seq.Append(moveObject.transform.DOLocalMoveX((-0.001f), 0.1f));
            seq.Join(moveObject.transform.DOLocalRotate(new Vector3(-90, 0, -180), 0.2f));
            seq.Append(moveObject.transform.DOLocalMove(myPoz, 0.1f));
        }
    }
}
