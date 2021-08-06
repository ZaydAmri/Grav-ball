using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level"+this.gameObject.name);
    }
}
