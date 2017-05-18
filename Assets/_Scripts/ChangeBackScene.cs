using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBackScene : MonoBehaviour {

    public GameObject fader1, fader2;
    
    bool survived = true;

    // Use this for initialization
    void Start () {

        iTween.FadeTo(fader1, 0f, 5f);
        iTween.FadeTo(fader2, 0f, 0f);
        StartCoroutine(sceneChangeSurvived());

    }

    public bool hasSurvived()
    {
        return survived;
    }

    public void FireWasKilled()
    {
        survived = false;
        print("fire was killed!!! survived = false");
        StartCoroutine(sceneChange1());
    }

    IEnumerator sceneChange1()
    {
        iTween.FadeTo(fader1, 1f, 6f);
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator sceneChangeSurvived()
    {

        yield return new WaitForSeconds(154);
        print("150 seconds passed!");
        if (survived)
        {

            iTween.FadeTo(fader2, 1f, 6f);
            yield return new WaitForSeconds(8);
            SceneManager.LoadScene("Menu");
        }


    }



}
