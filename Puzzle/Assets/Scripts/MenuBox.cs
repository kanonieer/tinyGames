using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuBox : MonoBehaviour
{
    public Button Continue;
    public Button Repeat;
    public Button Menu;
    public Button Quit;
    public Canvas Menu_Box;

    // Use this for initialization
    void Start()
    {
        Continue = Continue.GetComponent<Button>();
        Repeat = Repeat.GetComponent<Button>();
        Menu = Menu.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();
        Menu_Box = Menu_Box.GetComponent<Canvas>();
    }

    public void Continue_Level()
    {
        Menu_Box.enabled = false;
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();//szuka wszystkich gameObjectow
        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].GetComponent<Collider>() != null)//sprawdza czy danym gameObject ma collider
            {
                allObjects[i].GetComponent<Collider>().enabled = true;//wyłącza wszystkim gameObjectom collidery
            }
        }
    }
    public void Repeat_Level()
    {
        int i = Application.loadedLevel;
        SceneManager.LoadScene(i);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
