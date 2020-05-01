using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    public GameObject helpScreen;
    // Start is called before the first frame update
    void Start()
    {

        // set helpscreen to inactive
        helpScreen.SetActive(false);
    }

    public void clickButton()
    {
        // if inactive set active and vice versa
        if (helpScreen.activeSelf == true)
        {
            helpScreen.SetActive(false);
        } else
        {
            helpScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
