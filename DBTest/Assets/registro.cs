using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class registro : MonoBehaviour {


    public TMP_InputField inputNombre;
    public TMP_InputField inputNoControl;
    public TMP_InputField inputNip;
    public TMP_Text alertaNip;
    public TMP_Text alertaNumero;
    public TMP_Text alertaNombre;
    public Toggle mujer;
    string createUserURL = "https://ihcmon.000webhostapp.com/insertUser.php";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Registro()
    {
        alertaNombre.text = "";
        alertaNumero.text = "";
        alertaNip.text = "";
        string genero = "m";
        if (mujer.isOn)
        {
            genero = "f";
        }
        Debug.Log(genero);
        StartCoroutine(CreateUser(inputNombre.text, inputNoControl.text, inputNip.text,genero));
    }

    public void Volver()
    {
        SceneManager.LoadScene("LoginScene");
    }

    IEnumerator CreateUser(string nombre, string no_control, string nip,string genero)
    {

        if (nombre.Length < 1)
        {
            alertaNombre.text = "El nombre no puede estar vacío";
        }
        else if (no_control.Length != 8)
        {
            alertaNumero.text = "Longitud inválida. 8 números";
        }
        else if (nip.Length != 4)
        {
            alertaNip.text = "Longitud inválida. 4 números";
        }
        else {
            
            Debug.Log(genero);
            WWWForm form = new WWWForm();
            form.AddField("nombrePost", nombre);
            form.AddField("no_controlPost", no_control);
            form.AddField("nipPost", nip);
            form.AddField("post_genero", genero);



            WWW www = new WWW(createUserURL, form);

            yield return www;
            Debug.Log(www.text);

            if (www.text.Equals("ok"))
            {
                SceneManager.LoadScene("LoginScene");
            }
        }
        
    }
}
