using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour {

    public InputField inputUsername;
    public InputField inputPassword;
    

    string loginUserURL = "http://localhost/db_test/loginUser.php";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        if (Input.GetKeyDown(KeyCode.L))
        {
           StartCoroutine(LoginToDB(inputUsername.text, inputPassword.text));
        }
    }

    public void Logear() {
        StartCoroutine(LoginToDB(inputUsername.text, inputPassword.text));
    }

    IEnumerator LoginToDB(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("userPost", username);
        form.AddField("passPost", password);

        WWW www = new WWW(loginUserURL, form);

        yield return www;

        Debug.Log(www.text);
    }
}
