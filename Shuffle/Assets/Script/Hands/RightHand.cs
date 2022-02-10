using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RightHand : MonoBehaviour
{
    public GameObject OtherHand;
    public List<Money> MyMoneys = new List<Money>();
    public int SpawnCount;

    private int Carpan = 5;
    public float Height;
    public GameObject Chip;
    public Animator Anim;
    private Sequence seq;
    private bool _canMove = false;
    void Start()
    {
        Anim = GetComponent<Animator>();
        SpawnSystem();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ICollectable>() != null)
        {
            other.gameObject.GetComponent<ICollectable>().DoCollect(gameObject);
        }
    }

    private void SwipeMove()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MyMoneys.Count > 0&&!_canMove)
            {
                _canMove = true;
                Anim.CrossFade("Event", 0.05f);
                var moveObject = MyMoneys[MyMoneys.Count - 1];
                seq = DOTween.Sequence();
                OtherHand.GetComponent<LeftHand>().MyMoneys.Add(moveObject);
                MyMoneys.Remove(moveObject);
                Vector3 myPoz = new Vector3(-0.5f, ((OtherHand.GetComponent<LeftHand>().MyMoneys.Count-1)+Carpan) * Height,5f);
                moveObject.transform.SetParent(OtherHand.transform);
                seq.Join(moveObject.transform.DOLocalMoveY((-30f), 0.1f))
                    .Join(moveObject.transform.DOLocalMoveX((10f), 0.1f))
                    .Join(moveObject.transform.DOLocalRotate(new Vector3(90, -180, -180), 0.2f))
                    .Append(moveObject.transform.DOLocalMove(myPoz, 0.1f)).OnComplete(() =>
                    {
                        _canMove = false;
                        moveObject.transform.DOScale(new Vector3(moveObject.transform.localScale.x * 2f, moveObject.transform.localScale.y * 2f, moveObject.transform.localScale.z), 0.2f).From();
                    });

                //
                //seq.Append(moveObject.transform.DOLocalMoveX((-0.001f), 0.1f));
            }
            
        }
    }
    private void SpawnSystem()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            if (i==0)
            {
                var newMoney = Instantiate(Chip, transform.position, Quaternion.identity, transform);
                newMoney.transform.localPosition = new Vector3(-0.5f, Carpan*-0.5f, 5);
                newMoney.transform.localRotation = Quaternion.Euler(-90, 0, -180);
            }
            else
            {
                var newMoney = Instantiate(Chip, transform.position, Quaternion.identity, transform);
                newMoney.transform.localPosition = new Vector3(-0.5f, ((i)+Carpan) * Height, 5);
                newMoney.transform.localRotation = Quaternion.Euler(-90, 0, -180);
            }
            

        }
    }

    public void SpawnChip(int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            var newChip = Instantiate(Chip, transform.position, Quaternion.identity, transform);
            MyMoneys.Add(newChip.GetComponent<Money>());
            newChip.transform.localPosition = new Vector3(-0.5f, ((MyMoneys.Count - 1) + Carpan) * Height, 5f);
            newChip.transform.localRotation = Quaternion.Euler(270, 0, -180);
        }
    }
    public void RemoveChip(int _count)
    {
        if (_count > MyMoneys.Count)
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
