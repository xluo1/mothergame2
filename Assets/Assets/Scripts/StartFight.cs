using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class StartFight : MonoBehaviour
{

    // fight state
    public string fightState;

    // numbers   

    private int playerRoll;
    private int enemyRoll;

    private int enemyScore;
    private int playerScore;

    private int playerModifierNumber;

    public string stat;
    GameObject enemy;
    GameObject child;
    GameObject mother;

    private GameObject dicePrefab;
    private GameObject rollPrefab;
    private GameObject modifierPrefab;

    private GameObject playerDice;
    private GameObject playerRollNumber;
    private GameObject playerMod;

    private GameObject enemyDice;
    private GameObject enemyRollNumber;
    private GameObject enemyMod;
    Canvas mainCanvas;

    private GameObject victoryPrefab;
    private GameObject defeatPrefab;
    private GameObject victory;
    private GameObject defeat;

    public GameObject nextPrefab;
    public GameObject next;

    // no public variables bc this is attached to a button...sad

    // Start is called before the first frame update
    void Start()
    {

    }

    public void afterClick()
    {
        // get fightstate
        fightState = GameObject.Find("gameController").GetComponent<StateController>().fightState;
 
        // find child and mother
        mother = GameObject.Find("Actors/mother");
        child = GameObject.Find("Actors/child");

        // set enemy and stat
        enemy = GameObject.FindGameObjectWithTag("enemy");
        stat = enemy.GetComponent<EnemyStats>().stat;

        // get dice stuff
        dicePrefab = GameObject.Find("gameController").GetComponent<DiceObjectHolder>().dicePrefab;
        rollPrefab = GameObject.Find("gameController").GetComponent<DiceObjectHolder>().rollPrefab;
        modifierPrefab = GameObject.Find("gameController").GetComponent<DiceObjectHolder>().modifierPrefab;
        mainCanvas = GameObject.Find("gameController").GetComponent<DiceObjectHolder>().mainCanvas;

        // get victory stuff
        victoryPrefab = GameObject.Find("gameController").GetComponent<DiceObjectHolder>().victory;
        defeatPrefab = GameObject.Find("gameController").GetComponent<DiceObjectHolder>().defeat;
        nextPrefab = GameObject.Find("gameController").GetComponent<DiceObjectHolder>().nextPrefab;

        // randomize rolls // (check if mom help or not here)
        roll();

        // instantiate dice with number + modifier (must instantiate sprite and text separately because damn ugh)
        instantiateDice();
        // pop up "you win" or "you lose"
        instantiateWinLose();

    }

    void roll()
    {
        playerRoll = Random.Range(1, 6);
        enemyRoll = Random.Range(1, 6);

        if (fightState == "help")
        {
            if (stat == "A")
            {
                playerModifierNumber = child.GetComponent<PlayerStats>().Amodifier + (mother.GetComponent<PlayerStats>().Amodifier / 2);
            }
            else if (stat == "B")
            {
                playerModifierNumber = child.GetComponent<PlayerStats>().Bmodifier + (mother.GetComponent<PlayerStats>().Bmodifier / 2);
            }
            else
            {
                playerModifierNumber = child.GetComponent<PlayerStats>().Cmodifier + (mother.GetComponent<PlayerStats>().Cmodifier / 2);
            }
        }   else if (fightState == "alone")
        {
            if (stat == "A")
            {
                playerModifierNumber = child.GetComponent<PlayerStats>().Amodifier;
            }
            else if (stat == "B")
            {
                playerModifierNumber = child.GetComponent<PlayerStats>().Bmodifier;
            }
            else
            {
                playerModifierNumber = child.GetComponent<PlayerStats>().Cmodifier;
            }
        }

        playerScore = playerRoll + playerModifierNumber;

        // normally would check if mom helps or not but for now let's assume she does
        enemyScore = enemyRoll + enemy.GetComponent<EnemyStats>().modifier;
       
        
    }

    void instantiateDice()
    {
        // insantiate dice above player
        playerDice = Instantiate(dicePrefab, new Vector2(-4.61f, 1.99f), Quaternion.identity); // figure out position later
        playerRollNumber = Instantiate(rollPrefab, new Vector2(-185, 115), Quaternion.identity);
        playerMod = Instantiate(modifierPrefab, new Vector2(-154, 115), Quaternion.identity);
        // put text on canvas
        playerRollNumber.transform.SetParent(mainCanvas.transform, false);
        playerMod.transform.SetParent(mainCanvas.transform, false);

        // change text
        playerRollNumber.GetComponent<TextMeshProUGUI>().text = playerRoll.ToString();
        playerMod.GetComponent<TextMeshProUGUI>().text = "+" + (playerScore - playerRoll).ToString();


        // insantiate dice above enemy
        enemyDice = Instantiate(dicePrefab, new Vector2(-3.47f, 1.99f), Quaternion.identity); // figure out position later
        enemyRollNumber = Instantiate(rollPrefab, new Vector2(-69, 115), Quaternion.identity);
        enemyMod = Instantiate(modifierPrefab, new Vector2(-40, 115), Quaternion.identity);

        // put text on canvas
        enemyRollNumber.transform.SetParent(mainCanvas.transform, false);
        enemyMod.transform.SetParent(mainCanvas.transform, false);

        // change text
        enemyRollNumber.GetComponent<TextMeshProUGUI>().text = enemyRoll.ToString();
        enemyMod.GetComponent<TextMeshProUGUI>().text = "+" + (enemyScore - enemyRoll).ToString();
    }

    void instantiateWinLose()
    {
        if (playerScore >= enemyScore)
        {
            // instantiate you win text if win
            victory = Instantiate(victoryPrefab, new Vector2(-3.91f, 1.577f), Quaternion.identity);
            // set win variable
            GameObject.Find("gameController").GetComponent<StateController>().isWin = true;
        }
        else
        {
            // instantiate you lose text if loss
            defeat = Instantiate(defeatPrefab, new Vector2(-3.91f, 1.577f), Quaternion.identity);
            GameObject.Find("gameController").GetComponent<StateController>().isWin = false;

        }


        // disable button press
        this.GetComponent<Button>().interactable = false;

        // instantiate next button
        next = Instantiate(nextPrefab, new Vector2(-125, 57), Quaternion.identity);
        next.transform.SetParent(mainCanvas.transform, false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
