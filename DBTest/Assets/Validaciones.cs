using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Validaciones : MonoBehaviour {

    
    public GameObject juegoHombre;
    public GameObject juegoMujer;
    public GameObject juegoHombreInicial;
    public GameObject juegoMujerInicial;
    public Camera camaraPony;
    public Image imgMujer;
    public Image imgHombre;
    public TMP_Text txtNombre;
    public TMP_Text txtSemestre;

    // Use this for initialization
    void Start () {
        camaraPony.enabled = true;
        imgHombre.enabled = false;
        imgMujer.enabled = false;
        
        StartCoroutine(ConocerNivel(PlayerPrefs.GetString("no_control", "14121153")));
        StartCoroutine(ConocerGenero(PlayerPrefs.GetString("no_control","14121153")));
        
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
                imgHombre.enabled = true;
                Instantiate(juegoHombre, juegoHombre.transform.position, juegoHombre.transform.rotation);
            }
            else {
                camaraPony.enabled = false;
                imgHombre.enabled = true;
                Instantiate(juegoHombreInicial, juegoHombreInicial.transform.position, juegoHombreInicial.transform.rotation);
            }
            
        }
        else {
            if (www2.text != "0")
            {
                camaraPony.enabled = false;
                imgMujer.enabled = true;
                Instantiate(juegoMujer, juegoMujer.transform.position, juegoMujer.transform.rotation);
            }
            else
            {
                camaraPony.enabled = false;
                imgMujer.enabled = true;
                Instantiate(juegoMujerInicial, juegoMujerInicial.transform.position, juegoMujerInicial.transform.rotation);
            }
            
        }


    }

    IEnumerator ConocerNivel(string numero) {

        WWWForm form = new WWWForm();
        form.AddField("funcion", "nivel_alumno");
        form.AddField("parametros", numero);


        WWW www = new WWW(ApplicationModel.URLConsultas, form);

        yield return www;

        Debug.Log(www.text);

        WWWForm form2 = new WWWForm();
        form2.AddField("funcion", "nombre_alumno");
        form2.AddField("parametros", numero);

        WWW www2 = new WWW(ApplicationModel.URLConsultas, form2);

        yield return www2;

        Debug.Log(www2.text);

        PlayerPrefs.SetString("nombre", www2.text);
        PlayerPrefs.SetString("nivel", www.text);
       

        txtNombre.text = PlayerPrefs.GetString("nombre", "Fulanx");
        txtSemestre.text = ("" + PlayerPrefs.GetString("nivel", "1"));


        //funcion para saber los creditos del usuario
        PlayerPrefs.SetString("creditos", "0");

        if (PlayerPrefs.GetString("creditos","0").Equals("168"))
        {
            SceneManager.LoadScene("EligeScene");
        }

    }
}
