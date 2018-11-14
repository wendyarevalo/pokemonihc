using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtraparPony : MonoBehaviour {

    public Transform[] pony;
    float x = 387.92f;
    float y = 677f;
    float z = -775f;

    // Use this for initialization
    void Start () {
        int idPony = ApplicationModel.ponyId;
        ApplicationModel.ponyActual = idPony;
        showPony(idPony);
	}

    private void showPony(int idPony)
    {
        //Debug.Log(ApplicationModel.ponyId.ToString());
        Instantiate(pony[idPony], new Vector3(x, y, z), Quaternion.identity);
        
    }
}
