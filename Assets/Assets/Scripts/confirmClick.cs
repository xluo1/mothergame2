using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void clicked()
    {
        // find parent statchangecontroller and click clickConfirm()
        this.transform.parent.gameObject.transform.parent.GetComponent<StatChangeController>().clickConfirm();
        // find state controller and gdo changelevel() and destroyStatScreen()
       
        GameObject.Find("gameController").GetComponent<StateController>().changeLevel();
        GameObject.Find("gameController").GetComponent<StateController>().destroyStatScreen();
        
        int level = GameObject.Find("gameController").GetComponent<StateController>().level;
        if (level == 9)
        {
            GameObject.Find("gameController").GetComponent<StateController>().instantiateCutscene(2);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
