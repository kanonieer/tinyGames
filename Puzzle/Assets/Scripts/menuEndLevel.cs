using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuEndLevel : MonoBehaviour
{
    public Button nextLevel;
    public Button exitText;

    // Use this for initialization
    void Start()
    {
        nextLevel = nextLevel.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
    }

    public void nextLevel_scene()
    {
        int i = Application.loadedLevel;
        //int i = SceneManager.sceneCountInBuildSettings;
        //Application.LoadLevel(i + 1);
        SceneManager.LoadScene(i + 1);
    }

    public void exitLevel()
    {
        SceneManager.LoadScene("menu");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
