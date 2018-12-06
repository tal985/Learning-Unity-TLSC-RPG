using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour
{
    private BaseCharClass pepe = new BaseFirstClass();

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnGUI()
    {
        GUILayout.Label(pepe.CharClassName);
        GUILayout.Label(pepe.CharClassDesc);
        GUILayout.Label("Health Points: " + pepe.HealthPoints);
        GUILayout.Label("Meme Points: " + pepe.MemePoints);
    }
}
