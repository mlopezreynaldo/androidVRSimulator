using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnityEngine.XR.XRSettings.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargaNivel(string pNombreNivel){
		SceneManager.LoadScene (pNombreNivel);
	}

	public void exitGame() {
	
		Application.Quit ();
	}
}
