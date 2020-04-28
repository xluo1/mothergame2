using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public string stat;
    public int modifier;
    public int expPoints;
    public int expPointsHalf;
    public Sprite enemySprite;

    public float bottomX;
    public float bottomY;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = enemySprite;
        // move to correct location
        this.transform.position = new Vector2(bottomX - this.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2, bottomY + this.GetComponent<SpriteRenderer>().sprite.bounds.size.y/2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
