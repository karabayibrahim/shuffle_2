using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gate : MonoBehaviour,ICollectable
{
    public TextMeshPro MyText;
    public int MyCount;
    public int Multiple;
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
  
                _object.GetComponent<Hand>().SpawnChip(MyCount);
            }
        }
        else if (gameObject.tag == "PositiveMultiple")
        {
            if (_object.tag == "Left")
            {
                _object.GetComponent<Hand>().SpawnChip(_object.GetComponent<Hand>().MyMoneys.Count);
            }
            else if (_object.tag == "Right")
            {
 
                _object.GetComponent<Hand>().SpawnChip(_object.GetComponent<Hand>().MyMoneys.Count);
            }
        }
        else if (gameObject.tag == "NegativeDivide")
        {
            if (_object.tag == "Left")
            {
                _object.GetComponent<Hand>().RemoveChip(_object.GetComponent<Hand>().MyMoneys.Count/2);
            }
            else if (_object.tag == "Right")
            {

                _object.GetComponent<Hand>().RemoveChip(_object.GetComponent<Hand>().MyMoneys.Count / 2);
            }
        }
        else
        {
            if (_object.tag == "Left")
            {
                _object.GetComponent<Hand>().RemoveChip(MyCount);
                GameManager.Instance.Player.MoneyControl();
            }
            else
            {
                _object.GetComponent<Hand>().RemoveChip(MyCount);
                GameManager.Instance.Player.MoneyControl();
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
        else if (gameObject.tag == "PositiveMultiple")
        {
            MyText.text = "X" + Multiple.ToString();
        }
        else if (gameObject.tag == "NegativeDivide")
        {
            MyText.text = "/" + Multiple.ToString();

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
