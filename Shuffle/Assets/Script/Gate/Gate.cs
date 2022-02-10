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
                _object.GetComponent<Hand>().SpawnChip(MyCount);
            }
            else if(_object.tag == "Right")
            {
                Debug.Log("Sağ");
                _object.GetComponent<Hand>().SpawnChip(MyCount);
            }
        }
        else
        {
            if (_object.tag == "Left")
            {
                _object.GetComponent<Hand>().RemoveChip(MyCount);
            }
            else
            {
                _object.GetComponent<Hand>().RemoveChip(MyCount);
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
