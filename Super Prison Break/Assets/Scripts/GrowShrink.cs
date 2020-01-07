using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShrink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("CanGrow") == 1 && PlayerPrefs.GetInt("Stamina") > 0 && Input.GetKey("w"))
        {
            PlayerPrefs.SetString("Size", "Large");
        }
        if (PlayerPrefs.GetInt("CanGrow") == 1 && PlayerPrefs.GetInt("Stamina") > 0 && Input.GetKey("s"))
        {
            PlayerPrefs.SetString("Size", "Small");
        }
    }
}
