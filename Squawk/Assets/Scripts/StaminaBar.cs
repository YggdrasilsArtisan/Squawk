using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Class that handles how the bar is displayed
public class StaminaBar : MonoBehaviour
{
    public static StaminaBar instance;

    private Stamina stamina;
    private Image barImage;

    private void Awake()
    {
        //Allows script to be referenced in other scripts
        instance = this;

        //Links Script to  image asset in Unity editor.
        barImage = transform.Find("Stamina").GetComponent<Image>();

        //Creates a new "Stamina" object
        stamina = new Stamina();
    }

    //Allows for the bar to drain based on numbers aquired from the "Stamina" class's "Update" function
    private void Update()
    {
        stamina.Update();

        barImage.fillAmount = stamina.GetStaminaNormalized();
    }

    //Allows for the regenStamina function to be called in other scripts
    public void regenStamina() 
    {
        stamina.regenStamina();    
    }

}

//Class that handles the number to track and drain stamina
public class Stamina
{
    public const int STAM_MAX = 100;

    private float staminaAmount;
    private float drainAmount;

    //Sets starting amount and rate at which stamina drains
    public Stamina() 
    {
        staminaAmount = 100;
        drainAmount = 5f;
    }

    //Drains stamina
    public void Update() {
        staminaAmount -= drainAmount * Time.deltaTime;

        if (staminaAmount == 0)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single); //Loads the fourth Scene (Game Over) in Build Settings
        }
        else if (staminaAmount <= 40)
        {
            //Change player portrait image to Player Portrait Tired
        }
    }

    //Normalizes the number allowing for a clearer draining effect on the bar.
    public float GetStaminaNormalized() 
    {
        return staminaAmount / STAM_MAX;    
    }

    //Regens stamina when collecting a feather
    public void regenStamina()
    {
        this.staminaAmount = 100;

    }


}