using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarIniciales : MonoBehaviour {

    public Transform escenaNuevos;
    public Transform escenaNormal;
	// Use this for initialization
	void Start () {
        ConsultarMaterias();
	}

    public void ConsultarMaterias()
    {
        StartCoroutine(ConsultarBDMatUsr(PlayerPrefs.GetString("no_control")));
    }

    IEnumerator ConsultarBDMatUsr(string no_control)
    {
        Debug.Log("hilo ejecutandose "+ no_control);
        WWWForm form = new WWWForm();
        form.AddField("funcion", "NumMat_usuario");
        form.AddField("parametros", no_control);

        WWW www = new WWW(ApplicationModel.URLConsultas, form);

        yield return www;
        Debug.Log("recibo de url");
        Debug.Log(" respuesta "+www.text);

        if (www.text.Equals("0")){
        }
        else { ApplicationModel.primeraMat = 1; }
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
