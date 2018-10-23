using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataInsert : MonoBehaviour {

    public string inputUserName;
    public string inputPassword;
    public string inputEmail;

    string createUserURL = "http://localhost/db_test/insertUser.php";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateUser(inputUserName, inputPassword, inputEmail);
        }
		
	}

    public void CreateUser(string username, string password, string email) {
        WWWForm form = new WWWForm();
        form.AddField("userPost",username);
        form.AddField("passPost", password);
        form.AddField("emailPost", email);

        WWW www = new WWW(createUserURL,form);
    }
}
