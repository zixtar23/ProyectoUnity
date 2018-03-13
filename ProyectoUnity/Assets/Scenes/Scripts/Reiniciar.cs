using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void ReiniciarJuego()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
       // SceneManager.LoadScene(0);
    }
}
