using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{

	float CurrentTime = 0f;
	float StartingTime = 60f;
	public Text CountdownText;
	void Start()
	{
		CurrentTime = StartingTime;
	}

	void Update( int contador)
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
		if (CurrentTime <= 0 && contador < 17  )
		{
		
			CurrentTime = 0;
		}
	}
}
