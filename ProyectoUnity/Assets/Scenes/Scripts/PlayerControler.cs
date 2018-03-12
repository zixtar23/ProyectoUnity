using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

	//Aplicar fuerza a la esfera para que se mueva, componente caracteristica solides afectado por la gravedad

	public float speed;
	private Rigidbody rb;
	public Transform particulas;
	private ParticleSystem systemaParticulas;
	private Vector3 posicion;
	private AudioSource audioRecoleccion;
    private int cubos = 0;
    private int cuboObjetivo = 0;
	private int contador;
	public Text TextoContador;
	public Text TextoFin;

	// Use this for initialization
	void Start () {
		TextoContador.text = "Bonus: " + contador.ToString();
		TextoContador.text = "" ;
		contador = 0;
		rb = GetComponent<Rigidbody> ();
		systemaParticulas = particulas.GetComponent<ParticleSystem> ();
		systemaParticulas.Stop ();
		audioRecoleccion = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//float moveHorizontal = Input.acceleration.x;(Movil)
		//float moveVertical = Input.acceleration.z;(Movil)
		Vector3 movimiento = new Vector3 (moveHorizontal,0.0f, moveVertical);
		//Vector3 movimiento = new Vector3 (moveHorizontal,0.0f, -moveVertical);(Movil)
		rb.AddForce (movimiento*speed);
	}

	//referencia los objetos que impactamos
	void OnTriggerEnter(Collider other ){
		if (other.gameObject.CompareTag ("Recolectable")) {
			contador = contador + 1;
			TextoContador.text = "Bonus: " + contador.ToString();
			cubos = cubos + 1;
			other.gameObject.SetActive (false);
			posicion = other.gameObject.transform.position;
			particulas.position = posicion;
			systemaParticulas = particulas.GetComponent<ParticleSystem> ();
			systemaParticulas.Play ();
			audioRecoleccion.Play ();
			Debug.Log(cubos);
			if (cubos == 3) {
				//Debug.Log("Fin del nivel");
				//SceneManager.LoadScene (1);
				TextoFin.text = "Fin del nivel";

			}

		}

        if (other.gameObject.CompareTag("Final")){
			cuboObjetivo = cuboObjetivo + 1;
			other.gameObject.SetActive (false);
			posicion = other.gameObject.transform.position;
			particulas.position = posicion;
			systemaParticulas = particulas.GetComponent<ParticleSystem> ();
			if (cuboObjetivo == 1)
            {
                SceneManager.LoadScene(1);
            }
        }
            //Desaparece el objeto
            //Destroy (other.gameObject);

        }
}
