using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateStatUI : MonoBehaviour
{
    public GameObject motherText;
    public GameObject childText;
    public GameObject enemyText;


    private GameObject mother;
    private GameObject child;
    private GameObject enemy;

    private int motherA;
    private int motherB;
    private int motherC;

    private int childA;
    private int childB;
    private int childC;

    private string enemyStat;
    private int enemyMod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void updateStats()
    {
        mother = GameObject.Find("mother");
        child = GameObject.Find("child");
       

        motherA = mother.GetComponent<PlayerStats>().Amodifier;
        motherB = mother.GetComponent<PlayerStats>().Bmodifier;
        motherC = mother.GetComponent<PlayerStats>().Cmodifier;

        childA = child.GetComponent<PlayerStats>().Amodifier;
        childB = child.GetComponent<PlayerStats>().Bmodifier;
        childC = child.GetComponent<PlayerStats>().Cmodifier;

       

        childText.GetComponent<TextMeshProUGUI>().text = "Child has +" + childA.ToString()+ " in STR, +" + childB.ToString() + " in DEX and +" + childC.ToString() + " in CON.";

        // red if mother lost HP
        string motherAStr = motherA.ToString();
        string motherBStr = motherB.ToString();
        string motherCStr = motherC.ToString();

        if (motherA <= 6)
        {
            motherAStr = "<color=#8e4747>" + motherAStr + "</color>";
        }

        if (motherB <= 6)
        {
            motherBStr = "<color=#8e4747>" + motherBStr + "</color>";
        }

        if (motherC <= 6)
        {
            motherCStr = "<color=#8e4747>" + motherCStr + "</color>";
        }

        motherText.GetComponent<TextMeshProUGUI>().text = "Mother has +" + motherAStr + " in STR, +" + motherBStr + " in DEX and +" + motherCStr  + " in CON.";
       

    }

    public void updateEnemy()
    {
      

        enemy = GameObject.FindGameObjectWithTag("enemy");
        enemyStat = enemy.GetComponent<EnemyStats>().stat;
        enemyMod = enemy.GetComponent<EnemyStats>().modifier;
        enemyText.GetComponent<TextMeshProUGUI>().text = "The monster they encountered has +" + enemyMod.ToString() + " in " + enemyStat + ".";

    }
}
