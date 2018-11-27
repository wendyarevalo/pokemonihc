using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validaciones : MonoBehaviour {

    
    public GameObject juegoHombre;
    public GameObject juegoMujer;
    public GameObject juegoHombreInicial;
    public GameObject juegoMujerInicial;
    public Camera camaraPony;

    // Use this for initialization
    void Start () {
        camaraPony.enabled = true;
        StartCoroutine(ConocerGenero(PlayerPrefs.GetString("no_control","14121150")));
        
    }

    IEnumerator ConocerGenero(string numero) {

        WWWForm form = new WWWForm();
        form.AddField("funcion", "genero_usuario");
        form.AddField("parametros", numero);


        WWW www = new WWW(ApplicationModel.URLConsultas, form);

        yield return www;

        Debug.Log(www.text);

        WWWForm form2 = new WWWForm();
        form2.AddField("funcion", "NumMat_usuario");
        form2.AddField("parametros", numero);


        WWW www2 = new WWW(ApplicationModel.URLConsultas, form2);

        yield return www2;

        Debug.Log(www2.text);

        if (www.text.Equals("m"))
        {
            if (www2.text != "0")
            {
                camaraPony.enabled = false;
                Instantiate(juegoHombre, juegoHombre.transform.position, juegoHombre.transform.rotation);
            }
            else {
                camaraPony.enabled = false;
                Instantiate(juegoHombreInicial, juegoHombreInicial.transform.position, juegoHombreInicial.transform.rotation);
            }
            
        }
        else {
            if (www2.text != "0")
            {
                camaraPony.enabled = false;
                Instantiate(juegoMujer, juegoMujer.transform.position, juegoMujer.transform.rotation);
            }
            else
            {
                camaraPony.enabled = false;
                Instantiate(juegoMujerInicial, juegoMujerInicial.transform.position, juegoMujerInicial.transform.rotation);
            }
            
        }


    }
}
