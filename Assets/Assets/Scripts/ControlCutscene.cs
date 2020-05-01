using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlCutscene : MonoBehaviour
{
    // Start is called before the first frame update

    public List<string> listOfDialogue1;
    public List<string> listOfDialogue2;
    public int index;
    public string currentStr;
    public int whichCutscene;

    public Canvas speechCanvas;
    public TextMeshProUGUI speechText;
    public Button nextButton;
    public Button exitButton;

    void Start()
    {
        exitButton.GetComponent<Button>().interactable = false;
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
        setDialogue();

    }



    public void setDialogue()
    {
        if (whichCutscene == 1){
            currentStr = listOfDialogue1[index];
        }
        if (whichCutscene == 2)
        {
            currentStr = listOfDialogue2[index];
        }

        speechText.GetComponent<TextMeshProUGUI>().text = currentStr;
    }

    public void setWhichCutscene(int x)
    {
        whichCutscene = x;
        setDialogue();
    }

    public void clickNext()
    {
        // iterate to next part of list
        index = index + 1;
        setDialogue();

        if (whichCutscene == 1)
        {
            if (index == listOfDialogue1.Count-1)
            {
                disableButton();
                enableExit();
            }
        }
        if (whichCutscene == 2)
        {
            if (index == listOfDialogue2.Count-1)
            {
                disableButton();
                enableExit();
            }
        }


    }

    public void enableExit()
    {
        exitButton.GetComponent<Button>().interactable = true;
    }

    public void disableButton()
    {
        nextButton.GetComponent<Button>().interactable = false;
    }

    public void exitCutscene()
    {
        GameObject.Find("gameController").GetComponent<StateController>().destroyCutscene();
    }

    public void setCanvasCamera(Camera camera)
    {
        speechCanvas.GetComponent<Canvas>().worldCamera = camera;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
