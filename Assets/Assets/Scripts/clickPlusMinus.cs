using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPlusMinus : MonoBehaviour
{
    StatChangeController controller;

    // Start is called before the first frame update
    void Start()
    {

        controller = this.transform.parent.gameObject.transform.parent.GetComponent<StatChangeController>();
    }

    // button click functions

    public void clickPlusA()
    {
        controller.changeStat(1, "A");
    }

    public void clickMinusA()
    {
        controller.changeStat(-1, "A");
    }

    public void clickPlusB()
    {
        controller.changeStat(1, "B");
    }

    public void clickMinusB()
    {
        controller.changeStat(-1, "B");
    }

    public void clickPlusC()
    {
        controller.changeStat(1, "C");
    }

    public void clickMinusC()
    {
        controller.changeStat(-1, "C");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
