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
    public Sprite deadSprite;

    public float bottomX;
    public float bottomY;

    public Sprite deadSnake;
    public Sprite deadWorm;
    public Sprite deadSquirrel;
    public Sprite lossCat;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = enemySprite;
        // move to correct location
        this.transform.position = new Vector2(bottomX - this.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2, bottomY + this.GetComponent<SpriteRenderer>().sprite.bounds.size.y/2);

        // hardcode dead sprite
        if (modifier <= 2)
        {
            deadSprite = deadWorm;
        } else if (modifier == 4)
        {
            deadSprite = deadSquirrel;
        } else if (modifier == 5)
        {
            deadSprite = deadSnake;
        } else
        {
            deadSprite = lossCat;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
