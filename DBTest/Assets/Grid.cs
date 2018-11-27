using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Grid : MonoBehaviour {
    public GameObject prefab;
    public int numerToCreate;
    System.Random rnd = new System.Random();
    int aleatorio;
    // Use this for initialization
    void Start () {
        iniciar();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Evolucionar_click()
    {
        Debug.Log("EVOLUCIONA");
        aleatorio = rnd.Next(1, 11);
        Debug.Log(aleatorio);
        switch (aleatorio)
        {
            case 1:
                SceneManager.LoadScene("RelacionarQ");
                break;
            case 2:
                SceneManager.LoadScene("QuizVF");
                break;
            case 3:
                SceneManager.LoadScene("QuizMult");
                break;
            case 4:
                SceneManager.LoadScene("RelacionarQ");
                break;
            case 5:
                SceneManager.LoadScene("QuizVF");
                break;
            case 6:
                SceneManager.LoadScene("QuizMult");
                break;
            case 7:
                SceneManager.LoadScene("RelacionarQ");
                break;
            case 8:
                SceneManager.LoadScene("QuizVF");
                break;
            case 9:
                SceneManager.LoadScene("QuizMult");
                break;
            case 10:
                SceneManager.LoadScene("QuizVF");
                break;
        }
    }
    void populate()
    {
        /*GameObject NewObj;
        for (int i = 0; i < numerToCreate; i++)
        {
            NewObj = (GameObject)Instantiate(prefab, transform);
            //NewObj.GetComponent<Image>().color = Random.ColorHSV();
            NewObj.transform.GetChild(0).GetComponent<Text>().text="hello";

        }*/
    }
    public void iniciar()
    {
            StartCoroutine(MostrarKardex(PlayerPrefs.GetString("no_control")));   
    }

    IEnumerator MostrarKardex(string v)
    {

        //Texts[2].enabled = false;
        Debug.Log("NUMERO DE CONTROL "+ PlayerPrefs.GetString("no_control"));
        WWWForm form = new WWWForm();
        form.AddField("funcion", "materias_usuario");
        form.AddField("parametros", PlayerPrefs.GetString("no_control"));


        WWW www = new WWW(ApplicationModel.URLConsultas, form);

        yield return www;

        Debug.Log(www.text);


        if (www.text != "")
        {

            //JsonUtility.FromJsonOverwrite(www.text, kardList);

            /*string jsonString = "{\r\n    \"Items\": [\r\n        {\r\n            \"playerId\": \"8484239823\",\r\n            \"playerLoc\": \"Powai\",\r\n            \"playerNick\": \"Random Nick\"\r\n        },\r\n        {\r\n            \"playerId\": \"512343283\",\r\n            \"playerLoc\": \"User2\",\r\n            \"playerNick\": \"Rand Nick 2\"\r\n        }\r\n    ]\r\n}"*/
            KardexBd[] kardlist1 = JsonHelper.FromJson<KardexBd>("{\r\n    \"Items\":" + www.text + "\r\n}");

            Debug.Log(kardlist1.Length);
            numerToCreate = kardlist1.Length;
            for (int i = 0; i < kardlist1.Length; i++)
            {
                GameObject NewObj;
                    NewObj = (GameObject)Instantiate(prefab, transform);
                    NewObj.transform.GetChild(0).GetComponent<Text>().text = ""+ kardlist1[i].nombre_materia;
                Debug.Log("ACTIVAR "+ kardlist1[i].seriada);
                if (kardlist1[i].seriada == 0)
                {
                    //NewObj.transform.GetChild(1).GetComponent<Button>().enabled = false;
                    NewObj.GetComponentInChildren<Button>().enabled = false;
                }
                NewObj.GetComponentInChildren<Button>().onClick.AddListener(() => Evolucionar_click());
               ApplicationModel.ponyActual = kardlist1[i].id_materia;
            }

        }


    }

}
