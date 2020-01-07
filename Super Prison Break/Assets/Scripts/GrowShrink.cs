using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShrink : MonoBehaviour
{
    float timer = 0;
    bool timerGoing = false;
    bool canSwitch = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CanGrow", 1);
        PlayerPrefs.SetFloat("Stamina", 10);  //Neither of these lines should be in the final game, just testing
    }

    // Update is called once per frame
    void Update()
    {
       /* if (PlayerPrefs.GetInt("CanGrow") == 1 && PlayerPrefs.GetFloat("Stamina") > 0 && Input.GetKey("w"))
        {
            PlayerPrefs.SetString("Size", "Large");
        }
        if (PlayerPrefs.GetInt("CanGrow") == 1 && PlayerPrefs.GetFloat("Stamina") > 0 && Input.GetKey("s"))
        {
            PlayerPrefs.SetString("Size", "Small");
        }*/
        if (PlayerPrefs.GetString("Size") == "Large" && Input.GetKey("s") && canSwitch)
        {
            PlayerPrefs.SetString("Size", "Normal");
            timerGoing = true;
        }
        else if (PlayerPrefs.GetString("Size") == "Small" && Input.GetKey("w") && canSwitch)
        {
            PlayerPrefs.SetString("Size", "Normal");
            timerGoing = true;
        }
        else if (PlayerPrefs.GetInt("CanGrow") == 1 && PlayerPrefs.GetFloat("Stamina") > 0 && Input.GetKey("w") && canSwitch)
        {
            PlayerPrefs.SetString("Size", "Large");
            timerGoing = true;
        }
        else if (PlayerPrefs.GetInt("CanGrow") == 1 && PlayerPrefs.GetFloat("Stamina") > 0 && Input.GetKey("s") && canSwitch)
        {
            PlayerPrefs.SetString("Size", "Small");
            timerGoing = true;
        }
        if (timerGoing)
        {
            canSwitch = false;
            timer += Time.deltaTime;
            if (timer > .25f)
            {
                timerGoing = false;
                canSwitch = true;
                timer = 0;
            }
        }
    }
}
