using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PonyClick : MonoBehaviour {


   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select Stage
                if (hit.transform.name == "ponyMates")
                {
                    SceneManager.LoadScene("AtraparPony");
                }
                else if (hit.transform.name == "ponyFundProg")
                {
                    SceneManager.LoadScene("AtraparPony");
                }
                else if (hit.transform.name == "ponyIntroTics")
                {
                    SceneManager.LoadScene("AtraparPony");
                }
            }
        }

    }

}
