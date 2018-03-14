using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Contador : MonoBehaviour {

    public Text  contadorTexto;
    public float segundos, minutos;
    public bool UsarContador = false;



	// Use this for initialization
	void Start () {
        contadorTexto = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {
        minutos = (int)(Time.time / 60f);
        segundos = (int)(Time.time % 60f);
        contadorTexto.text ="Tiempo: " +  minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}
