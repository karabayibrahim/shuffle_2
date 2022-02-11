using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulettePanel : MonoBehaviour
{
    public GameObject RouletteWhell;
    void Start()
    {
        RouletGate.RouletteStart += RoulettStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RoulettStart()
    {
        GameManager.Instance.LevelCam.Follow = transform;
        GameManager.Instance.LevelCam.LookAt = transform;
        RouletteWhell.SetActive(true);
    }
    
    private void RoulettFinish()
    {
        Destroy(gameObject);
    }

}
