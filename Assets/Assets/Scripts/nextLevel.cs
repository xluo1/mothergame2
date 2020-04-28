using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void click()
    {
        GameObject.Find("gameController").GetComponent<StateController>().checkWin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
