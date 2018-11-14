using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarIniciales : MonoBehaviour {

    public Transform escenaNuevos;
    public Transform escenaNormal;
	// Use this for initialization
	void Start () {
        if (ApplicationModel.primeraMat == 0)
        {
            Instantiate(escenaNuevos, escenaNuevos.position, Quaternion.identity);
        }
        else
        {
            Instantiate(escenaNormal, escenaNormal.position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
