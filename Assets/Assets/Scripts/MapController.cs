using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public Sprite[] spriteArray;
    public int mapLevel;

    // Start is called before the first frame update
    void Start()
    {
        mapLevel = 0;   
    }

    public void updateMap()
    {
        this.GetComponent<SpriteRenderer>().sprite = spriteArray[mapLevel];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
