using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour


{

    [System.Serializable]
    public struct enemyType
    {
        public string stat;
        public int modifier;
        public int expPoints;
        public int expPointsHalf;
        public Sprite enemySprite;
    }

    public List<enemyType> enemyArrayEasy; // phase 1 list
    public List<enemyType> enemyArray; // regular enemies
    public List<enemyType> bossArray;

    public GameObject enemyPrefab;

    public float bottomX;
    public float bottomY; // instantiate sprite based on bottom right + width/height
    private float spriteHeight;
    private float spriteWidth;

    private int mapPhase;
    private enemyType newEnemy;
    private int randomIndex;
    GameObject NewenemyObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeEnemy(enemyType x)
    {
        // instantiate prefab
        // dump all the stats in
    

        NewenemyObject = Instantiate(enemyPrefab, new Vector2(bottomX, bottomY), Quaternion.identity);
        NewenemyObject.GetComponent<EnemyStats>().stat = x.stat;
        NewenemyObject.GetComponent<EnemyStats>().modifier = x.modifier;
        NewenemyObject.GetComponent<EnemyStats>().expPoints = x.expPoints;
        NewenemyObject.GetComponent<EnemyStats>().expPointsHalf = x.expPointsHalf;
        NewenemyObject.GetComponent<EnemyStats>().enemySprite = x.enemySprite;

        NewenemyObject.GetComponent<EnemyStats>().bottomX = bottomX;
        NewenemyObject.GetComponent<EnemyStats>().bottomY = bottomY;

    }

    public void selectEnemy()
    {
        // check if in phase 1 or 2
     
        mapPhase = this.GetComponent<StateController>().mapPhase;

        // take element from list at random, remove fromt list (?)
        if (mapPhase == 1)
        {
            // take from easy enemy list
            // take in order from beginning

            if (enemyArrayEasy.Count == 0)
            {
                // change map phase using function in statecontroller!
                //transform.parent.gameObject.GetComponent<StateController>().changeLevel(2);
                // call make enemy again?
                //selectEnemy();
                Debug.Log("ran out of enemies! something is wrong");

            } else
            {
                newEnemy = enemyArrayEasy[0];
                enemyArrayEasy.RemoveAt(0);
                makeEnemy(newEnemy);
            }

        }
        else if (mapPhase == 2)
        {
            //take from hard enemy list
            randomIndex = Random.Range(0, enemyArray.Count);
            newEnemy = enemyArray[randomIndex];
            enemyArray.RemoveAt(randomIndex);
            makeEnemy(newEnemy);
        }
        else
        {
            // generate boss i guess
            newEnemy = bossArray[0];
            bossArray.RemoveAt(0);
            makeEnemy(newEnemy);
        }

        // update stats
        GameObject.Find("gameController").GetComponent<UpdateStatUI>().updateEnemy();

    }
}
