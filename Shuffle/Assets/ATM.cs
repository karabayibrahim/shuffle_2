using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ATM : MonoBehaviour
{
    public Transform ChipGatepos;
    public Transform MoneySpawnPos;
    public int ChipCount;
    public GameObject Money;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ChipCount>=10)
        {
            var newMoney = Instantiate(Money, MoneySpawnPos.position, Quaternion.identity);
            newMoney.transform.rotation = Quaternion.Euler(-90, 0, -90);
            Vector3 startScale = newMoney.transform.localScale;
            newMoney.transform.localScale = new Vector3(0, 0, 0);
            newMoney.transform.DOScale(startScale, 0.5f);
            ChipCount = 0;
        }
    }


}
