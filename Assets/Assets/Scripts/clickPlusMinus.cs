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
        controller.changeStat(1, "STR");
    }

    public void clickMinusA()
    {
        controller.changeStat(-1, "STR");
    }

    public void clickPlusB()
    {
        controller.changeStat(1, "DEX");
    }

    public void clickMinusB()
    {
        controller.changeStat(-1, "DEX");
    }

    public void clickPlusC()
    {
        controller.changeStat(1, "CON");
    }

    public void clickMinusC()
    {
        controller.changeStat(-1, "CON");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
