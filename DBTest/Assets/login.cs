using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class login : MonoBehaviour {

    public TMP_InputField inputNoControl;
    public TMP_InputField inputNip;



    string loginUserURL = "https://ihcmon.000webhostapp.com/loginUser.php";

    // Use this for initialization
    void Start () {
        // 1 si la sesion esta iniciada y 0 si no esta iniciada
        int sesionActiva = PlayerPrefs.GetInt("SesionActiva", 0);
        Debug.Log("numero de prefers "+sesionActiva);
        if (sesionActiva == 1)
        {
            SceneManager.LoadScene("SpawningScene");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Logear()
    {
        StartCoroutine(LoginToDB(inputNoControl.text, inputNip.text));
    }

    IEnumerator LoginToDB(string no_control, string nip)
    {
        WWWForm form = new WWWForm();
        form.AddField("no_controlPost", no_control);
        form.AddField("nipPost", nip);

        WWW www = new WWW(loginUserURL, form);

        yield return www;

        Debug.Log(www.text);

        if (www.text.Equals("login success")) {
            PlayerPrefs.SetInt("SesionActiva", 1);
            PlayerPrefs.SetString("no_control", no_control);
            SceneManager.LoadScene("SpawningScene");
        }
        else if (www.text.Equals("user not found")){
            
        }
        else{
           
        }
        
    }

    public void IrRegistro() {
        SceneManager.LoadScene("RegistroScene");
    }
}
