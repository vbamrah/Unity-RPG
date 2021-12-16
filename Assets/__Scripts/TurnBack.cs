using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class TurnBack : MonoBehaviour
{

    [Space(10)]
    [Header("Toggle for the gui on off")]
    public bool GuiOn;
    public bool shown = false;


    [Space(10)]
    [Header("The text to Display on Trigger")]

    public string Text = "Level 1 Complete!";


    public Rect BoxSize = new Rect(0, 0, 200, 100);


    [Space(10)]

    public GUISkin customSkin;



    // if this script is on an object with a collider display the Gui
    void OnTriggerEnter(Collider other)
    {
        if (!shown)
        {
            PlayerController cont = other.GetComponent<PlayerController>();
            cont.maxHealth = 120;
            cont.currentHealth += 20;
            GuiOn = true;
            shown = true;
        }
    }

    /*
    void OnTriggerExit()
    {
        GuiOn = false;
    }*/

    void OnGUI()
    {

        if (customSkin != null)
        {
            GUI.skin = customSkin;
        }

        if (GuiOn == true)
        {

            GUI.BeginGroup(new Rect((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));


            GUI.Label(BoxSize, Text);


            GUI.EndGroup();

            StartCoroutine(waiter());

        }


    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3f);
        GuiOn = false;
        StopCoroutine(waiter());
    }
}