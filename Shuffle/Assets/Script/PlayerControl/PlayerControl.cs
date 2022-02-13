using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed { get; set; }
    public Hand LeftHand;
    public Hand RightHand;
    void Start()
    {
        Finish.FinishEvent += FinishStatus;
        Speed = 5f;
    }

    private void OnDisable()
    {
        Finish.FinishEvent -= FinishStatus;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed*Time.deltaTime);
    }

    private void FinishStatus()
    {
        Speed = 0;
    }
}
