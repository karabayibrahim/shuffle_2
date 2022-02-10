using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeftHand : MonoBehaviour
{
    public GameObject OtherHand;
    public List<Money> MyMoneys = new List<Money>();
    public Animator Anim;
    public float Height;
    public GameObject Chip;
    private Sequence seq;
    private int Carpan = 5;
    private bool _canMove = false;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SwipeMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICollectable>()!=null)
        {
            other.gameObject.GetComponent<ICollectable>().DoCollect(gameObject);
        }
    }
    private void SwipeMove()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (MyMoneys.Count > 0&&!_canMove)
            {
                _canMove = true;
                Anim.CrossFade("Event", 0.05f);
                var moveObject = MyMoneys[MyMoneys.Count - 1];
                seq = DOTween.Sequence();
                OtherHand.GetComponent<RightHand>().MyMoneys.Add(moveObject);
                MyMoneys.Remove(moveObject);
                Vector3 myPoz = new Vector3(-0.5f, ((OtherHand.GetComponent<RightHand>().MyMoneys.Count - 1) + Carpan) * Height, 5f);
                moveObject.transform.SetParent(OtherHand.transform);
                seq.Join(moveObject.transform.DOLocalMoveY((-30f), 0.1f))
                    .Join(moveObject.transform.DOLocalMoveX((10f), 0.1f))
                    .Join(moveObject.transform.DOLocalRotate(new Vector3(270, 0, -180), 0.2f))
                    .Append(moveObject.transform.DOLocalMove(myPoz, 0.1f)).OnComplete(() =>
                    {
                        _canMove = false;
                        moveObject.transform.DOScale(new Vector3(moveObject.transform.localScale.x * 2f, moveObject.transform.localScale.y * 2f, moveObject.transform.localScale.z), 0.2f).From();
                    });
                    
            }

        }
    }

    public void SpawnChip(int _count)
    {
        for (int i = 0; i <_count; i++)
        {
            var newChip=Instantiate(Chip, transform.position, Quaternion.identity,transform);
            MyMoneys.Add(newChip.GetComponent<Money>());
            newChip.transform.localPosition = new Vector3(-0.5f, ((MyMoneys.Count - 1) + Carpan) * Height, 5f);
            newChip.transform.localRotation = Quaternion.Euler(90, 0,0);
        }
    }

    public void RemoveChip(int _count)
    {
        if (_count>MyMoneys.Count)
        {
            _count = MyMoneys.Count;
        }
        for (int i = 0; i < _count; i++)
        {
            Destroy(MyMoneys[MyMoneys.Count - 1].gameObject);
            MyMoneys.Remove(MyMoneys[MyMoneys.Count - 1]);
        }
    }

}
