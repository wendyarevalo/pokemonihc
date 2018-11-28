using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MateriaMostrar : MonoBehaviour
{
    public Sprite[] Sprites;
    public UnityEngine.UI.Image Imagen;
    public Text mensaje;
    public Text Objetivo;
    public Text Creditos;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void iniciar(int a)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            StartCoroutine(MostrarMateria(PlayerPrefs.GetString("no_control"), a));
        }
        else
        {
            gameObject.SetActive(true);
            StartCoroutine(MostrarMateria(PlayerPrefs.GetString("no_control"), a));
        }
    }

    public void iniciarEsp(int x, int y, int z)
    {

    }

    IEnumerator MostrarMateria(string v, int a)
    {

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
            KardexBd[] kardlist2 = JsonHelper.FromJson<KardexBd>("{\r\n    \"Items\":" + www.text + "\r\n}");
            //   Debug.Log(kardlist[0].id_materia);
            //   Debug.Log(kardlist[1].id_materia);

            for (int i = 0; i < kardlist2.Length; i++)
            {
                Debug.Log(kardlist2[i].clave + kardlist2[i].creditos + kardlist2[i].id_materia + kardlist2[i].nombre_materia + kardlist2[i]);
                if (kardlist2[i].id_materia == a)
                {
                    mensaje.text = kardlist2[i].nombre_materia;
                    Objetivo.text = kardlist2[i].objetivos;
                    Creditos.text = "Creditos: " + kardlist2[i].creditos;
                    Imagen.sprite = Sprites[kardlist2[i].id_materia-1]; 
                }
            }
            
        }
    }
}

