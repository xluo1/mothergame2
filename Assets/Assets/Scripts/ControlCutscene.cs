using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCutscene : MonoBehaviour
{
    // Start is called before the first frame update

    public List<string> listOfDialogue1;
    public List<string> listOfDialogue2;
    public int index;



    void Start()
    {
        index = 0;
        listOfDialogue1 = new List<string> { "it's time for me to teach you how to fight",
                                            "we will leave home and go thru the real world",
                                            "we will encounter many monsters, but i can help you fight",
                                            "but remember, you need to learn how to fight yourself at some point",
                                            };

        listOfDialogue2 = new List<string> { "you've grown up so much",
                                            "i've protected you as far as i can",
                                            "but you need to take on the final boss yourself",
                                            "I know you can do it!"
                                            };
    }

    public void clickNext()
    {
        // iterate to next part of list
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
