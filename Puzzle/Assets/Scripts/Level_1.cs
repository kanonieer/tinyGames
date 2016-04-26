using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level_1 : MonoBehaviour {
    public Text tekstWynik;
    public Text LicznikProb;
    public float smooth = 1f;
    public Canvas Plansza;
    public Canvas MenuLose;
    public Canvas menuBox;
    public Button MENU;

    int count;

    private Vector3 targetAngles;

    private int wynik;
    private int licznik;
    GameObject[] licz;
    GameObject[] licz2;
    GameObject[] allObjects;


    void Start()
    {

        MENU = MENU.GetComponent<Button>();
        menuBox.enabled = false;
        MenuLose.enabled = false;
        Plansza.enabled = false;
        count = 0;
        wynik = 0;
        licznik = 3;
        tekstWynik.text = "Wynik: " + wynik.ToString();
        LicznikProb.text= "Pozostało prób: " + licznik.ToString();

    }
    public void loadMenu()
    {
        menuBox.enabled = true;
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();//szuka wszystkich gameObjectow
        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].GetComponent<Collider>() != null)//sprawdza czy danym gameObject ma collider
            {
                allObjects[i].GetComponent<Collider>().enabled = false;//wyłącza wszystkim gameObjectom collidery
            }
        }
    }
    void Update()
    {
        licz2 = GameObject.FindGameObjectsWithTag("false");
        licz = GameObject.FindGameObjectsWithTag("true");
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();//szuka wszystkich gameObjectow
        if (licz.Length == 2 || (licz.Length == 2 && licz2.Length == 0))
        {
            if (licz[0].transform.FindChild("kolor").GetComponent<Renderer>().material.color.Equals(licz[1].transform.FindChild("kolor").GetComponent<Renderer>().material.color))
            {
                if(count == 45) {
                licz[0].transform.GetComponent<Rigidbody>().AddForce(transform.forward * 650);
                licz[0].transform.GetComponent<Rigidbody>().useGravity = true;
                licz[1].transform.GetComponent<Rigidbody>().AddForce(transform.forward * 650);
                licz[1].transform.GetComponent<Rigidbody>().useGravity = true;
                licz[0].transform.tag = "off";
                licz[1].transform.tag = "off";
                wynik = wynik + 10;
                
                tekstWynik.text = "Wynik: " + wynik.ToString();
                    licznik = licznik - 1;
                    LicznikProb.text = "Pozostało prób: " + licznik.ToString();
                    if (wynik == 20)
                    {
                        Plansza.enabled = true;
                    }
                    else if (licznik == 0)
                    {
                        MenuLose.enabled = true;
                        for (int i = 0; i < allObjects.Length; i++)
                        {
                            if (allObjects[i].GetComponent<Collider>() != null)//sprawdza czy danym gameObject ma collider
                            {
                                allObjects[i].GetComponent<Collider>().enabled = false;//wyłącza wszystkim gameObjectom collidery
                            }
                        }

                    }
                    count = 0 ;
                }
                else
                {
                    count++;
                }
            }
            else
            {
                if(count == 70)
                {

                    targetAngles = transform.eulerAngles + 1f * Vector3.up; // what the new angles should be
                    licz[0].transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 3 * smooth * Time.deltaTime); // lerp to new angles
                    licz[1].transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 3 * smooth * Time.deltaTime);
                    licz[0].transform.tag = "false";
                    licz[1].transform.tag = "false";
                    count = 0;
                    licznik = licznik - 1;
                    LicznikProb.text = "Pozostało prób: " + licznik.ToString();
                    if (licznik == 0)
                    {
                        MenuLose.enabled = true;
                        for (int i = 0; i < allObjects.Length; i++)
                        {
                            if (allObjects[i].GetComponent<Collider>()!=null)//sprawdza czy danym gameObject ma collider
                            {
                                allObjects[i].GetComponent<Collider>().enabled = false;//wyłącza wszystkim gameObjectom collidery
                            }
                        }
                    }

                }
                else
                {
                    count++;
                }


            }

            licz = new GameObject[2];
            licz2 = new GameObject[4];
        }
    }
}
