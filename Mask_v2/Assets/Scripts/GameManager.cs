using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager Instance { get; private set; }
    public GameOver GameOverScript;
    public GameObject Player;

    public Coleccionable ScriptColeccionable;
    
    public GameObject[] colectables;
    public HUD hud;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }

    public void mask1()
    {

        hud.Activarcolectables(0);

    }

    public void mask2()
    {

        hud.Activarcolectables(2);

    }

    public void mask3()
    {

        hud.Activarcolectables(4);

    }

    public void mask4()
    {

        hud.Activarcolectables(6);

    }

    public void Img1()
    {

        hud.Desactivarcolectables(1);

    }

    public void Img2()
    {

        hud.Desactivarcolectables(3);

    }

    public void Img3() 
	{
        
        hud.Desactivarcolectables(5);
        
	}

    public void Img4() 
	{
        
        hud.Desactivarcolectables(7);
        
	}
}
