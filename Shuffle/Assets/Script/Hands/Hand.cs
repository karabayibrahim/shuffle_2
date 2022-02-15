using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Hand : MonoBehaviour
{
    public GameObject OtherHand;
    public List<Money> MyMoneys = new List<Money>();
    public int SpawnCount;
    public TextMeshPro MyMoneyText;
    public IList<Money> AbsLis;
    public bool FinishPanelControl = false;
    private int Carpan = 5;
    public float Height;
    public List<GameObject> Chips = new List<GameObject>();
    public Animator Anim;
    public Sequence seq;
    private float fireRate = 0.01f;
    private float lastShot = 0;
    private bool _finishControl = false;
    public int MyId = 1;
    void Start()
    {
        Finish.FinishEvent += FinishStatus;
        Anim = GetComponent<Animator>();
        SpawnSystem();
        foreach (var item in gameObject.GetComponentsInChildren<Money>())
        {
            MyMoneys.Add(item);
        }
        MoneyTextWrite();
    }

    private void OnDisable()
    {
        Finish.FinishEvent += FinishStatus;
    }
    // Update is called once per frame
    void Update()
    {
        SwipeMove();
        HorizontalMovement();
        if (_finishControl&&MyMoneys.Count<=0)
        {
            FinishPanelControl = true;
        }
        //Debug.Log(Input.mousePosition.normalized.x);
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
        if (Input.GetKey(KeyCode.Space)&&gameObject.tag=="Right")
        {

            RightMove();
        }
        if (Input.GetKey(KeyCode.Return) && gameObject.tag == "Left")
        {
            LeftMove();
        }
    }

    private void HorizontalMovement()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPosMove;
            Touch _theTouch = Input.GetTouch(0);


            if (_theTouch.phase == TouchPhase.Stationary)
            {
                 touchPosMove= _theTouch.position;
                if (touchPosMove.x>Screen.width/2f&&gameObject.tag=="Left")
                {
                    LeftMove();
                }
                else if(touchPosMove.x < Screen.width / 2f && gameObject.tag == "Right")
                {
                    RightMove();
                }
                

            }
        }
    }
    private void SpawnSystem()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            if (i == 0)
            {
                var rndChip = Random.Range(0, Chips.Count);
                var newChip = Instantiate(Chips[rndChip], transform.position, Quaternion.identity, transform);
                newChip.transform.localPosition = new Vector3(-0.5f, Carpan * -0.5f, 5);
                newChip.transform.localRotation = Quaternion.Euler(-90, 0, -180);
            }
            else
            {
                var rndChip = Random.Range(0, Chips.Count);
                var newChip = Instantiate(Chips[rndChip], transform.position, Quaternion.identity, transform);
                newChip.transform.localPosition = new Vector3(-0.5f, ((i) + Carpan) * Height, 5);
                newChip.transform.localRotation = Quaternion.Euler(-90, 0, -180);
            }


        }
    }

    public void SpawnChip(int _count)
    {
        for (int i = 0; i < _count; i++)
        {

            var rndChip = Random.Range(0, Chips.Count);
            var newChip = Instantiate(Chips[rndChip], transform.position, Quaternion.identity, transform);
            MyMoneys.Add(newChip.GetComponent<Money>());
            newChip.transform.localPosition = new Vector3(-0.5f, ((MyMoneys.Count - 1) + Carpan) * Height, 5f);
            newChip.transform.localRotation = Quaternion.Euler(270, 0, -180);
        }
        MoneyTextWrite();
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
        MoneyTextWrite();
    }
    private void ResetScale()
    {
        foreach (var item in MyMoneys)
        {
            item.transform.DOScale(new Vector3(400, 400, 50), 0.01f);
        }
    }

    private void RightMove()
    {
        if (MyMoneys.Count > 0 && Time.time > fireRate + lastShot)
        {
            OtherHand.GetComponent<Hand>().seq.Kill(true);
            ResetScale();
            lastShot = Time.time;
            Anim.CrossFade("Event", 0.05f);
            var moveObject = MyMoneys[MyMoneys.Count - 1];
            seq = DOTween.Sequence();
            OtherHand.GetComponent<Hand>().MyMoneys.Add(moveObject);
            MyMoneys.Remove(moveObject);
            Vector3 myPoz = new Vector3(-0.5f, ((OtherHand.GetComponent<Hand>().MyMoneys.Count - 1) + Carpan) * Height, 5f);
            moveObject.transform.SetParent(OtherHand.transform);
            seq.Join(moveObject.transform.DOLocalJump(myPoz, -20f, 1, 0.25f)).SetEase(Ease.OutCubic)
               .Join(moveObject.transform.DOLocalRotate(new Vector3(90, -180, -180), 0.25f)).OnComplete(() =>
               {
                   moveObject.transform.DOScale(new Vector3(moveObject.transform.localScale.x * 1.2f, moveObject.transform.localScale.y * 1.2f, moveObject.transform.localScale.z), 0.1f).From();
               });
            OtherHand.GetComponent<Hand>().MoneyTextWrite();
            MoneyTextWrite();
        }
    }

    private void LeftMove()
    {
        if (MyMoneys.Count > 0 && Time.time > fireRate + lastShot)
        {
            OtherHand.GetComponent<Hand>().seq.Kill(true);
            ResetScale();
            lastShot = Time.time;
            Anim.CrossFade("Event", 0.05f);
            var moveObject = MyMoneys[MyMoneys.Count - 1];
            seq = DOTween.Sequence();
            OtherHand.GetComponent<Hand>().MyMoneys.Add(moveObject);
            MyMoneys.Remove(moveObject);
            Vector3 myPoz = new Vector3(-0.5f, ((OtherHand.GetComponent<Hand>().MyMoneys.Count - 1) + Carpan) * Height, 5f);
            moveObject.transform.SetParent(OtherHand.transform);
            seq.Join(moveObject.transform.DOLocalJump(myPoz, -20f, 1, 0.25f)).SetEase(Ease.OutCubic)
               .Join(moveObject.transform.DOLocalRotate(new Vector3(90, -180, -180), 0.25f)).OnComplete(() =>
               {
                   moveObject.transform.DOScale(new Vector3(moveObject.transform.localScale.x * 1.2f, moveObject.transform.localScale.y * 1.2f, moveObject.transform.localScale.z), 0.1f).From();
               });
            OtherHand.GetComponent<Hand>().MoneyTextWrite();
            MoneyTextWrite();
        }
    }
    public void MoneyTextWrite()
    {
        MyMoneyText.text = "$" + (MyMoneys.Count * 10f).ToString();
    }

    private void FinishStatus()
    {
        if (!_finishControl)
        {
            MyMoneys.Reverse();
            if (Anim != null)
            {
                Anim.enabled = false;
            }
            foreach (var item in MyMoneys)
            {
                item.gameObject.transform.SetParent(null);
            }
            StartCoroutine(ChipFinishTime());
            _finishControl = true;
        }
        
    }

    private IEnumerator ChipFinishTime()
    {
        if (MyMoneys!=null)
        {
            foreach (var item in MyMoneys.ToArray())
            {
                item.gameObject.transform.DOMove(GameManager.Instance.ATM.ChipGatepos.position, 0.5f).OnComplete(() =>
                {
                    GameManager.Instance.ATM.ChipCount++;
                    MyMoneys.Remove(item);
                    MoneyTextWrite();
                });
                yield return new WaitForSeconds(0.01f);

            }
        }
        
        yield break;
    }
}
