using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuLoseLevel : MonoBehaviour
{
    public Button repeatLevelText;
    public Button exitText;

    // Use this for initialization
    void Start()
    {
        repeatLevelText = repeatLevelText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
    }

    public void repeatLevel_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
