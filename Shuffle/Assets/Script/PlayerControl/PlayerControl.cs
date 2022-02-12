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
        Speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed*Time.deltaTime);
    }
}
