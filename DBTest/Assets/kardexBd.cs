using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [Serializable]
    public class KardexBd
    {
        public int id_materia;
        public string clave;
        public int seriada;
        public string nombre_materia;
        public string objetivos;
        public int creditos;

        public KardexBd(int id, string clv, int s, string mat)
        {
        id_materia = id;
        clave = clv;
        seriada = s;
        nombre_materia = mat;
        }
        public KardexBd(int id, string clv, string nom, string obj, int cred)
        {
            id_materia = id;
            clave = clv;
            nombre_materia = nom;
            objetivos = obj;
            creditos = cred;
        }
    }

