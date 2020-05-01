using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatChangeController : MonoBehaviour
{
    // camera
    public Camera mainCamera;

    // fightstate
    public string fightState;

    // ui to control (get as gameobjects)

    public int currentPointsToSpend;
    public int currentAStat;
    public int currentBStat;
    public int currentCStat;

    public GameObject child;
    public GameObject enemy;

    public GameObject aPlusButton;
    public GameObject aMinusButton;
    public GameObject bPlusButton;
    public GameObject bMinusButton;
    public GameObject cPlusButton;
    public GameObject cMinusButton;

    public GameObject pointsToSpendText;
    public GameObject AStatText;
    public GameObject BStatText;
    public GameObject CStatText;

    public GameObject confirmButton;

    // stuff from other 
    public int maxPointsToSpend;
    public int oldAStat;
    public int oldBStat;
    public int oldCStat;


    // Start is called before the first frame update
    void Start()
    {
       

        // get stats
        enemy = GameObject.FindGameObjectWithTag("enemy");
        child = GameObject.Find("child");

        // get fightState
        fightState = GameObject.Find("gameController").GetComponent<StateController>().fightState;

        if (fightState == "alone")
        {
            maxPointsToSpend = enemy.GetComponent<EnemyStats>().expPoints;

        } else
        {
            maxPointsToSpend = enemy.GetComponent<EnemyStats>().expPointsHalf;
        }

        currentPointsToSpend = maxPointsToSpend;
        oldAStat = child.GetComponent<PlayerStats>().Amodifier;
        oldBStat = child.GetComponent<PlayerStats>().Bmodifier;
        oldCStat = child.GetComponent<PlayerStats>().Cmodifier;
        currentAStat = oldAStat;
        currentBStat = oldBStat;
        currentCStat = oldCStat;


        // get ui to control
        aPlusButton = this.transform.Find("stat canvas/aPlus").gameObject;
        aMinusButton = this.transform.Find("stat canvas/aMinus").gameObject;

        bPlusButton = this.transform.Find("stat canvas/bPlus").gameObject;
        bMinusButton = this.transform.Find("stat canvas/bMinus").gameObject;

        cPlusButton = this.transform.Find("stat canvas/cPlus").gameObject;
        cMinusButton = this.transform.Find("stat canvas/cMinus").gameObject;

        pointsToSpendText = this.transform.Find("stat canvas/points").gameObject;

        AStatText = this.transform.Find("stat canvas/APoints").gameObject;
        BStatText = this.transform.Find("stat canvas/BPoints").gameObject;
        CStatText = this.transform.Find("stat canvas/CPoints").gameObject;

        confirmButton = this.transform.Find("stat canvas/confirmButton").gameObject;

        // update ui
        updateScreen();
    }

    public void setCamera()
    {
        // set render camera to main camera
        this.transform.Find("stat canvas").GetComponent<Canvas>().worldCamera = mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    public void clickConfirm()
    {
        // change child stats
        child.GetComponent<PlayerStats>().Amodifier = currentAStat;
        child.GetComponent<PlayerStats>().Bmodifier = currentBStat;
        child.GetComponent<PlayerStats>().Cmodifier = currentCStat;

    }

    // other functions

    public void changeStat(int change, string stat)
    {
        if (stat == "STR")
        {
            currentAStat = currentAStat + change;    
        } else if (stat == "DEX")
        {
            currentBStat = currentBStat + change;
        } else
        {
            currentCStat = currentCStat + change;
        }

        currentPointsToSpend = currentPointsToSpend - change;

        updateScreen();
    }

    void updateScreen()
    {
        // update ui
        pointsToSpendText.GetComponent<TextMeshProUGUI>().text = currentPointsToSpend.ToString();
        AStatText.GetComponent<TextMeshProUGUI>().text = "+" + currentAStat.ToString();
        BStatText.GetComponent<TextMeshProUGUI>().text = "+" + currentBStat.ToString();
        CStatText.GetComponent<TextMeshProUGUI>().text = "+" + currentCStat.ToString();

        // disable or enable + and confirm buttons based on current points to spend
        if (currentPointsToSpend == 0)
        {
            aPlusButton.GetComponent<Button>().interactable = false;
            bPlusButton.GetComponent<Button>().interactable = false;
            cPlusButton.GetComponent<Button>().interactable = false;

            confirmButton.GetComponent<Button>().interactable = true;

        } else
        {
            aPlusButton.GetComponent<Button>().interactable = true;
            bPlusButton.GetComponent<Button>().interactable = true;
            cPlusButton.GetComponent<Button>().interactable = true;

            confirmButton.GetComponent<Button>().interactable = false;
        }

        // disable or enable - buttons based on individual stats
        if (currentAStat == oldAStat)
        {
            aMinusButton.GetComponent<Button>().interactable = false;
        } else
        {
            aMinusButton.GetComponent<Button>().interactable = true;
        }

        if (currentBStat == oldBStat)
        {
            bMinusButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            bMinusButton.GetComponent<Button>().interactable = true;
        }

        if (currentCStat == oldCStat)
        {
            cMinusButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            cMinusButton.GetComponent<Button>().interactable = true;
        }
    }
}
