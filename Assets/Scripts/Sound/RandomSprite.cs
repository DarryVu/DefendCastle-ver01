using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    private int rand;
    public Sprite[] spriteBG;
    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        rand = Random.Range(0, spriteBG.Length);
        GetComponent<SpriteRenderer>().sprite = spriteBG[rand];
    }
}
