using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour {

	// Use this for initialization
	public void CambiarScena (string nombre) {
		SceneManager.LoadScene(nombre);
	}
	
	
}
