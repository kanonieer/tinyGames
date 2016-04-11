using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start () {

        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
    }

    public void game()
    {
        SceneManager.LoadScene("scene 1");
    }
	
    public void exitGame()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
