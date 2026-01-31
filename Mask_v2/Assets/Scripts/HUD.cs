using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public GameObject[] colectables;
  
	void Update () {
		
	}

    public void Activarcolectables(int indice) {
		colectables[indice].SetActive(true);
	}


	public void Desactivarcolectables(int indice) {
		colectables[indice].SetActive(false);
	}
}
