using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwipeMovement : MonoBehaviour
{

    //public Vector3 Distance;
    //public Vector3 MovementFrequemcy;
    //Vector3 Moveposition;
    //Vector3 startPosition;
    
    Sequence seq;

    public GameObject sagel, solel, para;

    


    // Start is called before the first frame update
    void Start()
    {
        // startPosition = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Aktar());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Moveposition.x = startPosition.x + Mathf.Sin(Time.timeSinceLevelLoad * MovementFrequemcy.x) * Distance.x;
        //Moveposition.y = startPosition.y + Mathf.Sin(Time.timeSinceLevelLoad * MovementFrequemcy.y) * Distance.y;
        //Moveposition.z = startPosition.z + Mathf.Sin(Time.timeSinceLevelLoad * MovementFrequemcy.z) * Distance.z;
        //transform.position = new Vector3(Moveposition.x, Moveposition.y, Moveposition.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            seq = DOTween.Sequence();

            //seq.Append(transform.DOMoveX(0.180f,0.5f));
            //seq.Join(transform.DOMoveY(1, 0.5f))
        }
    }
    IEnumerator Aktar()
    { // -0.18  ----0.18


        if (para.transform.position.x < 0)
        {
            //para soldadır.
            while (Vector3.Distance(para.transform.position, sagel.transform.position) > .01f)
            {
                para.transform.position = new Vector3(para.transform.position.x + .1f, para.transform.position.y, para.transform.position.z);
                yield return new WaitForSeconds(.05f);
            }
            Debug.Log("sol");
        }
        else
        {
            while (Vector3.Distance(para.transform.position, sagel.transform.position) > .01f)
            {
                para.transform.position = new Vector3(para.transform.position.x - .1f, para.transform.position.y, para.transform.position.z);
                yield return new WaitForSeconds(.05f);
            }
            Debug.Log("sağ");
        }
    }
}
