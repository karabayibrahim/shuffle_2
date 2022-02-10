using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gate : MonoBehaviour,ICollectable
{
    public TextMeshPro MyText;
    public int MyCount;
    public void DoCollect(GameObject _object)
    {
        if (gameObject.tag=="Positive")
        {
            if (_object.tag == "Left")
            {
                _object.GetComponent<LeftHand>().SpawnChip(MyCount);
            }
            else if(_object.tag == "Right")
            {
                Debug.Log("Sağ");
                _object.GetComponent<RightHand>().SpawnChip(MyCount);
            }
        }
        else
        {
            if (_object.tag == "Left")
            {
                _object.GetComponent<LeftHand>().RemoveChip(MyCount);
            }
            else
            {
                _object.GetComponent<RightHand>().RemoveChip(MyCount);
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag=="Positive")
        {
            MyText.text = "+" + MyCount.ToString();
        }
        else
        {
            MyText.text = "-" + MyCount.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
