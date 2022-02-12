using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;
public class RouletGate : MonoBehaviour, ICollectable
{
    public static Action RouletteStart;
    public RoulettePanel MyPanel;
    public float Bet { get; set; }
    public TextMeshPro BetText;

    public void DoCollect(GameObject _object)
    {
        if (_object.tag == "Left" && gameObject.tag == "BlackBet")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            BetStartStatus(_object);
            MyPanel.BlackBet = _object.GetComponent<Hand>().MyMoneys.Count;

        }
        else
        {
            gameObject.GetComponent<Collider>().enabled = false;
            BetStartStatus(_object);
            MyPanel.RedBet = _object.GetComponent<Hand>().MyMoneys.Count;

        }
        RouletteStart?.Invoke();

        //if (_object.tag == "Right" && gameObject.tag == "RedBet")
        //{
        //    gameObject.GetComponent<Collider>().enabled = false;
        //    BetStartStatus(_object);
        //    MyPanel.RedBet = _object.GetComponent<Hand>().MyMoneys.Count;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BetTextWrite()
    {
        BetText.text = "$" + (Bet * 10f).ToString();
    }

    private void BetStartStatus(GameObject _object)
    {
        GameManager.Instance.Player.Speed = 0f;

        Bet = _object.GetComponent<Hand>().MyMoneys.Count;

        foreach (var item in _object.GetComponent<Hand>().MyMoneys)
        {

            item.transform.DOMove(transform.position, 0.5f).OnComplete(() =>
            {
                _object.GetComponent<Hand>().MyMoneys.Remove(item);
                Destroy(item.gameObject);
                _object.GetComponent<Hand>().MoneyTextWrite();
            });
        }


        BetTextWrite();
    }
}
