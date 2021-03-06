﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateController : MonoBehaviour
{
    // black
    public GameObject black;

    // level change stuff
    public int level;
    public int mapPhase; //either 1 (easy) 2 (middle) 3 (boss)
    private GameObject[] toDestroy;
    private GameObject enemyToDestroy;


    // stat screen stuff
    public GameObject statScreen;
    public GameObject statScreenPrefab;
    public Camera mainCamera;

    // fight state
    public string fightState; //either alone or help

    // speech bubble
    public GameObject speechPrefab;
    public GameObject speechInstance;

    // fight win/lose stuff
    public bool isWin;
    public GameObject mother;
    public string currentStat;
    public int currentMod;

    // lose screens
    public GameObject momLossPrefab;
    public GameObject childLossPrefab;
    public GameObject winPrefab;

    // cutscene
    public GameObject cutscenePrefab;

    // map
    public GameObject map;

    void Start()
    {
        // select enemy
        this.GetComponent<InstantiateEnemy>().selectEnemy();
  

        // set level
        mapPhase = 1;
        level = 1;

        // set stat ui
        this.GetComponent<UpdateStatUI>().updateStats();
        this.GetComponent<UpdateStatUI>().updateEnemy();

        // instantiate speech bubble
        instantiateSpeech();

        // fade in
        StartCoroutine(fadeIn());
        
        // start music
        this.GetComponent<AudioSource>().Play();

        // get needed variables
        mother = GameObject.Find("mother").gameObject;
        instantiateCutscene(1);

        


    }

    IEnumerator fadeIn()
    {
        //////////
        Color tmp = black.GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a - .25f;
        black.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.25f);
        tmp = black.GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a - .25f;
        black.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.25f);
        tmp = black.GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a - .25f;
        black.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.25f);
        tmp = black.GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a - .25f;
        black.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.25f);
        ////////////
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkWin()
    {
        // TODO if phase is 3, do NOT make stat screen


        if (isWin == true)
        {
            if (mapPhase != 3)
            {
                makeStatScreen();
            } else
            {
                changeLevel();
            }
            
        } else
        {
            if (fightState == "alone")
            {
                // if not aided by mom
                loseScreen();
            } else if (fightState == "help")
            {
                currentStat = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyStats>().stat;
                currentMod =GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyStats>().modifier;
                if (currentStat == "STR")
                {
                    mother.GetComponent<PlayerStats>().Amodifier = mother.GetComponent<PlayerStats>().Amodifier - currentMod;
                    this.GetComponent<UpdateStatUI>().updateStats();
                    if (mother.GetComponent<PlayerStats>().Amodifier <=0)
                    {
                        loseScreen();
                    }
                } else if (currentStat == "DEX")
                {
                    mother.GetComponent<PlayerStats>().Bmodifier = mother.GetComponent<PlayerStats>().Bmodifier - currentMod;
                    this.GetComponent<UpdateStatUI>().updateStats();
                    if (mother.GetComponent<PlayerStats>().Bmodifier <= 0)
                    {
                        loseScreen();
                    }
                } else if (currentStat == "CON")
                {
                    mother.GetComponent<PlayerStats>().Cmodifier = mother.GetComponent<PlayerStats>().Cmodifier - currentMod;
                    this.GetComponent<UpdateStatUI>().updateStats();
                    if (mother.GetComponent<PlayerStats>().Cmodifier <= 0)
                    {
                        loseScreen();
                    }
                }

            }
            makeStatScreen();



        }
    }

    public void loseScreen()
    {
        // check fightstate
        if (fightState == "alone")
        {
            Instantiate(childLossPrefab, new Vector2(-2.67f, 0.86f), Quaternion.identity);
        } else
        {
            Instantiate(momLossPrefab, new Vector2(-2.67f, 0.86f), Quaternion.identity);
        }


    }

    public void winScreen()
    {
        Instantiate(winPrefab, new Vector2(-2.67f, 0.86f), Quaternion.identity);

    }

    public void makeStatScreen()
    {
        // does stat stuff instead of changing level

        // instantiate stat prefab
        statScreen = Instantiate(statScreenPrefab, new Vector2(-2.76f, -1.08f), Quaternion.identity);
        // put in camera as variable and set camera
        statScreen.GetComponent<StatChangeController>().mainCamera = mainCamera;
        statScreen.GetComponent<StatChangeController>().setCamera();

        Debug.Log("made stat screen");

    }

    public void destroyStatScreen()
    {
        
        Destroy(statScreen);
        statScreen.SetActive(false);
        Debug.Log("destroy stat screen");



    }

 

    public void changeLevel() // call this when confirm is clicked on stat screen too
    {

        

        //delete dice, mods, rolls, next level button
        toDestroy = GameObject.FindGameObjectsWithTag("diceRelated");
        if (toDestroy.Length > 0)
        {
            foreach(GameObject GO in toDestroy)
            {
                Destroy(GO);
            }
        }

    

        // destroy enemy
        enemyToDestroy = GameObject.FindGameObjectWithTag("enemy");
        Destroy(enemyToDestroy.gameObject);
        enemyToDestroy.SetActive(false);


        // re-enable fight button
        GameObject.Find("fight button").GetComponent<Button>().interactable = true;

        // change phase
        level = level + 1;
        
        if (level == 4)
        {
            mapPhase = 2;
        } 
        else if (level == 9)
        {
           
            mapPhase = 3;
        } else if (level == 12)
        {
            winScreen();
        }

        

        // change map
        map.GetComponent<MapController>().mapLevel = level-1;
        map.GetComponent<MapController>().updateMap();

       

        // select new enemy
        this.GetComponent<InstantiateEnemy>().selectEnemy();

      
        // set stat ui
        this.GetComponent<UpdateStatUI>().updateStats();


        // if boss battle, mother is not here

        if (mapPhase == 3)
        {
            // if mother prefab is not null, destroy and disable
            if (mother != null)
            {
                Destroy(mother);
                mother.SetActive(false);
            }
            // set  fight state to alone
            fightState = "alone";
           

        } else
        {
            // instantiate speech bubble
            instantiateSpeech();
        }
        

    }

    public void instantiateSpeech()
    {
        // disable fight button
        GameObject.Find("fight button").GetComponent<Button>().interactable = false;
        speechInstance = Instantiate(speechPrefab, new Vector2(-3.93f, 1.03f), Quaternion.identity);
        // set camera,,, or dont...
        speechInstance.GetComponent<setCameraSpeech>().setCanvasCamera(mainCamera);
    }

    public void startFight()
    {
        // destroy speech 
        Destroy(speechInstance);
        speechInstance.SetActive(false);

        // enable fight button
        GameObject.Find("fight button").GetComponent<Button>().interactable = true;
    }

    public void instantiateCutscene(int x)
    {
        Debug.Log("IN CUTSCENE");
        // x is which cutscene
        GameObject cutscene = Instantiate(cutscenePrefab, new Vector2(-2.69f, 0.87f), Quaternion.identity);
        cutscene.GetComponent<ControlCutscene>().setCanvasCamera(mainCamera);
        cutscene.GetComponent<ControlCutscene>().setWhichCutscene(x);
    }

    public void destroyCutscene()
    {
        GameObject cutsceneToDestroy = GameObject.FindGameObjectWithTag("cutsceneRelated");
        Destroy(cutsceneToDestroy);
        cutsceneToDestroy.SetActive(false);
    }
}


