using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour {

    public InputField inputNoControl;
    public InputField inputNip;



    string loginUserURL = "https://ihcmon.000webhostapp.com/loginUser.php";

    // Use this for initialization
    void Start () {
		
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
            SceneManager.LoadScene("GameScene");
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
