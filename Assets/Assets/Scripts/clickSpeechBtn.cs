using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSpeechBtn : MonoBehaviour
{

    private StateController state;

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("gameController").GetComponent<StateController>();
    }

    public void clickAidButton()
    {
        state.fightState = "help";
        state.startFight();
    }

    public void clickAloneButton()
    {
        state.fightState = "alone";
        state.startFight();
    }

    public void clickFleeButton()
    {
        // destroy current speech bubble
        GameObject speech = GameObject.FindGameObjectWithTag("speechRelated").gameObject;
        Destroy(speech);
        speech.SetActive(false);
        // start new level
        state.changeLevel();
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
