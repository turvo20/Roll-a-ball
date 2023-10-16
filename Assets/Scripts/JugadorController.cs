using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{

	//Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro 
	//Jugador


	private Rigidbody rb;

	//Declaro la variable pública velocidad para poder modificarla desde la 
	//Inspector window

	public float velocidad;

	private int contador;

	//Inicializo variables para los textos
	public Text textoContador, textoGanar;

	float CurrentTime = 0f;
	float StartingTime = 60f;
	public Text CountdownText;
	public AudioSource sonidoMoneda;
	public AudioSource WinnSonido;
	public AudioSource LoseSonido;


	// Use this for initialization
	void Start()
	{
		CurrentTime = StartingTime;

		//Capturo esa variable al iniciar el juego
		rb = GetComponent<Rigidbody>();

		contador = 0;
		//Actualizo el texto del contador por pimera vez
		setTextoContador();
		//Inicio el texto de ganar a vacío
		textoGanar.text = "";
	}
	//Actualizo el texto del contador (O muestro el de ganar si las ha cogido 
	// todas)

	private void setTextoContador()
	{
		textoContador.text = "Contador: " + contador.ToString();
		if (contador >= 17)
		{
			WinnSonido.Play();
			
			textoGanar.text = "¡Ganaste!";
		}
	}


	// Para que se sincronice con los frames de física del motor
	void FixedUpdate()
	{

		//Estas variables nos capturan el movimiento en horizontal y 
		//vertical de nuestro teclado

		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");

		//Un vector 3 es un trío de posiciones en el espacio XYZ, en este 
		// caso el que corresponde al movimiento

		Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);


		//Asigno ese movimiento o desplazamiento a mi RigidBody
		rb.AddForce(movimiento * velocidad);

	}


	//Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Coleccionable"))
		{
			sonidoMoneda.Play();
// LoseSonido.Play();
			other.gameObject.SetActive(false);
			//Incremento el contador en uno (también se peude hacer 
			// como contador++)
			contador = contador + 1;
			//Actualizo elt exto del contador
			setTextoContador();

		}
	}

	// Update is called once per frame
	void Update()
	{
		CurrentTime -= 1 * Time.deltaTime;
		CountdownText.text = CurrentTime.ToString("0");

		if (CurrentTime <= 30)
		{
			CountdownText.color = Color.yellow;
		}
		if (CurrentTime <= 10)
		{
			CountdownText.color = Color.red;
		}
		if (CurrentTime <= 0 && contador < 17)
		{
			LoseSonido.Play();
			textoGanar.text = "¡Perdite!";
			CurrentTime = 0;

			Invoke("Return", 5f);
		}
	}

	private void Return()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
