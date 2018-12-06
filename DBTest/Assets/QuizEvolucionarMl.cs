﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuizEvolucionarMl : MonoBehaviour {
    public GameObject prefab;
    public int numerToCreate;
    System.Random rnd = new System.Random();
    int aleatorio;
    public Sprite[] materiasSprites = new Sprite[2];
    // Use this for initialization
    void Start()
    {
        iniciar();

    }

    // Update is called once per frame
    void Update()
    {

    }
    /* se manda al quiz que le corresponde*/
    public void Entrenar_click(int id)
    {
        Debug.Log("entrenar");
        ApplicationModel.QuizEntrenar = id;
        aleatorio = rnd.Next(1, 11);
        Debug.Log(aleatorio);
        // GameObject NewObj = (GameObject)Instantiate(prefabs[0], transform);
        switch (aleatorio)
        {
            case 1:
                SceneManager.LoadScene("EntrenarQuizMul");
                break;
            case 2:
                SceneManager.LoadScene("QuizVF");
                break;
            case 3:
                SceneManager.LoadScene("EntrenarQuizMul");
                break;
            case 4:
                SceneManager.LoadScene("QuizVF");
                break;
            case 5:
                SceneManager.LoadScene("QuizVF");
                break;
            case 6:
                SceneManager.LoadScene("EntrenarQuizMul");
                break;
            case 7:
                SceneManager.LoadScene("QuizVF");
                break;
            case 8:
                SceneManager.LoadScene("QuizVF");
                break;
            case 9:
                SceneManager.LoadScene("EntrenarQuizMul");
                break;
            case 10:
                SceneManager.LoadScene("QuizVF");
                break;
        }
    }
    public void iniciar()
    {
        StartCoroutine(MostrarKardex(PlayerPrefs.GetString("no_control")));
    }
    /*SE consultan las materias que estan en la BD para llenar el grid*/
    IEnumerator MostrarKardex(string v)
    {

        Debug.Log("NUMERO DE CONTROL " + PlayerPrefs.GetString("no_control"));
        WWWForm form = new WWWForm();
        form.AddField("funcion", "materias_usuario");
        form.AddField("parametros", PlayerPrefs.GetString("no_control"));


        WWW www = new WWW(ApplicationModel.URLConsultas, form);

        yield return www;

        Debug.Log(www.text);


        if (www.text != "")
        {
            KardexBd[] kardlist1 = JsonHelper.FromJson<KardexBd>("{\r\n    \"Items\":" + www.text + "\r\n}");

            Debug.Log(kardlist1.Length);
            numerToCreate = kardlist1.Length;
            for (int i = 0; i < kardlist1.Length; i++)
            {
                GameObject NewObj;
                NewObj = (GameObject)Instantiate(prefab, transform);
                Image img = NewObj.GetComponent<Image>();
                img.sprite = materiasSprites[kardlist1[i].id_materia - 1];
                NewObj.transform.GetChild(0).GetComponent<Text>().text = "" + kardlist1[i].nombre_materia;
                //Sprite sprites = new Sprite("Spritesheet");
                int idbtn = kardlist1[i].id_materia;
                NewObj.GetComponentInChildren<Button>().onClick.AddListener(() => Entrenar_click(idbtn));

            }

        }


    }
}
