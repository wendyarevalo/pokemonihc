using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class registro : MonoBehaviour {


    public InputField inputNombre;
    public InputField inputNoControl;
    public InputField inputNip;
    string createUserURL = "https://ihcmon.000webhostapp.com/insertUser.php";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Registro()
    {
        StartCoroutine(CreateUser(inputNombre.text, inputNoControl.text, inputNip.text));
    }

    IEnumerator CreateUser(string nombre, string no_control, string nip)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombrePost", nombre);
        form.AddField("no_controlPost", no_control);
        form.AddField("nipPost", nip);

        WWW www = new WWW(createUserURL, form);

        yield return www;
        Debug.Log(www.text);
        
        if (www.text.Equals("ok"))
        {
            SceneManager.LoadScene("LoginScene");
        }
        else {
            
        }
    }
}
