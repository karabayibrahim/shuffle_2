using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulettePanel : MonoBehaviour
{
    public GameObject RouletteWhell;
    public int MyId = 0;
    public int OtherId;
    public float RedBet { get; set; }
    public float BlackBet { get; set; }
    void Start()
    {
        RouletGate.RouletteStart += RoulettStart;
        Ball.ResultEvent += RoulettFinish;
    }
    private void OnDisable()
    {
        RouletGate.RouletteStart -= RoulettStart;
        Ball.ResultEvent -= RoulettFinish;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void RoulettStart()
    {
        if (MyId == OtherId)
        {
            Debug.Log("Başladı");
            RouletGate.RouletteStart -= RoulettStart;
            RouletteWhell.SetActive(true);
        }

    }

    private void RoulettFinish(int _result)
    {
        if (MyId == OtherId)
        {
            if (_result == 0)
            {
                GameManager.Instance.Player.RightHand.SpawnChip((int)(RedBet * 2));
            }
            else
            {
                GameManager.Instance.Player.LeftHand.SpawnChip((int)(BlackBet * 2));
            }
            GameManager.Instance.Player.Speed = 5f;
            Destroy(gameObject);
            GameManager.Instance.Player.LeftHand.MyId++;
            GameManager.Instance.Player.RightHand.MyId++;
        }

    }

}
