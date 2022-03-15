using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Replace this game object with another
/// 
/// @author Alex Wills
/// </summary>
public class FrogTransfiguration : MonoBehaviour
{

    public GameObject shrek;
    public GameObject cat;
    public GameObject duck;

    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void prepareScene()
    {
        this.GetComponent<SceneChange>().changeable = true;
    }

    // Code is repeated! To be fixed in the future
    public void transfigureShrek()
    {
        sound.Play();
        Instantiate(shrek, this.transform.position, this.transform.rotation);
        GameObject[] frogs = GameObject.FindGameObjectsWithTag("Frog");
        foreach(GameObject obj in frogs)
        {
            obj.SetActive(false);
        }
        prepareScene();
    }

    public void transfigureCat()
    {
        Instantiate(cat, this.transform.position, this.transform.rotation);
        sound.Play();
        GameObject[] frogs = GameObject.FindGameObjectsWithTag("Frog");
        foreach (GameObject obj in frogs)
        {
            obj.SetActive(false);
        }
        prepareScene();
    }

    public void transfigureDuck()
    {
        Instantiate(duck, this.transform.position, this.transform.rotation);
        sound.Play();
        GameObject[] frogs = GameObject.FindGameObjectsWithTag("Frog");
        foreach (GameObject obj in frogs)
        {
            obj.SetActive(false);
        }
        prepareScene();
    }
}
