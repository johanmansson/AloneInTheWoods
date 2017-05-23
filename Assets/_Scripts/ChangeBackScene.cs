using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBackScene : MonoBehaviour {

    public GameObject fader1, fader2;
    public AudioClip dayAudio;
    
    bool survived = false;

    // Use this for initialization
    void Start () {

        iTween.FadeTo(fader1, 0f, 5f);
        iTween.FadeTo(fader2, 0f, 0f);
        StartCoroutine(sceneChangeSurvived());
        StartCoroutine(backgroundWolf());
    }

    public bool hasSurvived()
    {
        return survived;
    }

    public void FireWasKilled()
    {
        //survived = false;
        print("fire was killed!!! survived = false");
        StartCoroutine(sceneChange1());
        
    }

    IEnumerator sceneChange1()
    {
        iTween.FadeTo(fader1, 1f, 6f);
        yield return new WaitForSeconds(2);
        GameObject.Find("GameOverSound").GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(12);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator backgroundWolf() {
        yield return new WaitForSeconds(16);

        while(!survived) {

            GameObject.Find("Backgrounfd Wolf Sound").GetComponent<AudioSource>().Play();
            float timeIntervall = Random.Range(15f, 30f);
            yield return new WaitForSeconds(timeIntervall);

        }
       
    }

    IEnumerator sceneChangeSurvived()
    {

        yield return new WaitForSeconds(150);
        print("150 seconds passed!");
        survived = true;

        yield return new WaitForSeconds(2);
        //Sound here?
        AudioSource audio = GetComponent<AudioSource>();

        float startVolume = audio.volume;

        while (audio.volume > 0) {
            audio.volume -= startVolume * Time.deltaTime / 3.0f;

            yield return null;
        }

        audio.clip = dayAudio;
        audio.volume = startVolume;


        audio.Play();

        yield return new WaitForSeconds(8);
        iTween.FadeTo(fader2, 1f, 6f);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Menu");
        


    }



}
