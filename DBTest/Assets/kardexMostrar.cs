using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class kardexMostrar : MonoBehaviour {

    public UnityEngine.UI.Image[] Images;
    public UnityEngine.UI.Text[] Texts;

    string MateriaUrl = "http://ihcmon.000webhostapp.com/consultas.php?funcion=materias_usuario&parametros=14121153";

    // Use this for initialization
    void Start () {

        
        
    }

    public void iniciar() {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            StartCoroutine(MostrarKardex("14121153"));
        }
        else
        {
            gameObject.SetActive(true);
            StartCoroutine(MostrarKardex("14121153"));
        }
    }
    
    IEnumerator MostrarKardex(string v)
    {

        //Texts[2].enabled = false;

        WWWForm form = new WWWForm();
        form.AddField("funcion", "materias_usuario");
        form.AddField("parametros", "14121153");


        WWW www = new WWW(MateriaUrl, form);

        yield return www;

        Debug.Log(www.text);


        if (www.text != "")
        {

            //JsonUtility.FromJsonOverwrite(www.text, kardList);

            /*string jsonString = "{\r\n    \"Items\": [\r\n        {\r\n            \"playerId\": \"8484239823\",\r\n            \"playerLoc\": \"Powai\",\r\n            \"playerNick\": \"Random Nick\"\r\n        },\r\n        {\r\n            \"playerId\": \"512343283\",\r\n            \"playerLoc\": \"User2\",\r\n            \"playerNick\": \"Rand Nick 2\"\r\n        }\r\n    ]\r\n}"*/
            KardexBd[] kardlist = JsonHelper.FromJson<KardexBd>("{\r\n    \"Items\":" + www.text + "\r\n}");
            //     Debug.Log(kardlist[0].id_materia);
            //   Debug.Log(kardlist[1].id_materia);

            for (int j = 0; j < 12; j++)
            {
                Images[j].enabled = false;
            }

            Debug.Log(kardlist.Length);
            for (int i = 0; i < kardlist.Length; i++)
            {
                Images[kardlist[i].id_materia - 1].enabled = true;
                Texts[kardlist[i].id_materia - 1].enabled = false;
            }

            

 

        }

            /*kardexBd myObject = JsonUtility.FromJson<kardexBd>(www.text);

             JsonUtility.FromJsonOverwrite(www.text, myObject);
             */

            /* kardexBd[] objects = JsonHelper.FromJsonWrapped<kardexBd>(www.text);

             Debug.Log(objects[0].id_material + " " + objects[1].id_material + " " + objects[2].id_material);
             for(int a=0; a < objects.Length; a++)
             {
                 Debug.Log(a + " - "+ objects[a] + " - " + objects[a].id_material);
                 Texts[objects[a].id_material].enabled = false;
             }*/

        
    }



    // Update is called once per frame
    void Update () {
		
	}
}


[System.Serializable]
public class KardexBDList
{

    public List<KardexBd> KardexBdList;
}


public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}