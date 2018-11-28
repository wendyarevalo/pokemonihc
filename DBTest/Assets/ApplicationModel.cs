using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ApplicationModel
{
    public static int ponyId = 0;
    public static int ponyActual = 0;
    public static int primeraMat = 0;
    public static int matActivas = 0;
    public static string URLConsultas = "http://ihcmon.000webhostapp.com/consultas.php";
    public static string URLInsert = "http://ihcmon.000webhostapp.com/inserts.php?";


    public static bool mostarAasistente = true;


    public static List<GameObject> activos = new List<GameObject>();

    public static int pasos = 0;


    public static int aciertos = 0;
    public static int intentos = 3;
    
}
