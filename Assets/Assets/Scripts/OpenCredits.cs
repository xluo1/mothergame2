using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OpenCredits : MonoBehaviour
{
    public GameObject black;
    public GameObject credits;
    


    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
      
    }

    public void clickButton()
    {
        // if inactive set active and vice versa
        if (credits.activeSelf == true)
        {
            credits.SetActive(false);
        }
        else
        {
            credits.SetActive(true);
        }
    }


    public void clickStart()
    {
        StartCoroutine(loadNewScene());
    }

    IEnumerator loadNewScene()
    {
        playAudio();

        //////////
        Color tmp = black.GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a + .25f;
        black.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.25f);
        tmp = black.GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a + .25f;
        black.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.25f);
        tmp = black.GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a + .25f;
        black.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.25f);
        tmp = black.GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a + .25f;
        black.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.25f);
        ////////////

        changeScene();

    }

 
    
    public void playAudio()
    {
        this.GetComponent<AudioSource>().Play();

    }

    public void changeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

   



    // Update is called once per frame
    void Update()
    {
        
    }
}
