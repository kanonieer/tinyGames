using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public Text tekstWynik;

    public float smooth = 1f;

    int count;

    private Vector3 targetAngles;

    private int wynik;
    GameObject[] licz;
    GameObject[] licz2;
    GameObject kolor1, kolor2;

    void Start()
    {
        count = 0;
        wynik = 0;
        tekstWynik.text = "Wynik: " + wynik.ToString();
    }
    void Update()
    {
        licz2 = GameObject.FindGameObjectsWithTag("false");
        licz = GameObject.FindGameObjectsWithTag("true");
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
                    count = 0 ;
                }
                else
                {
                    count++;
                }
            }
            else
            {
                if(count == 50)
                {

                
              //  if (gameObject.transform.eulerAngles.y <= 180)
               // {

                    targetAngles = transform.eulerAngles + 1f * Vector3.up; // what the new angles should be
                    //    licz[0].transform.Rotate(0,-180,0);
                     //   licz[1].transform.Rotate(0, -180, 0);    // transform.Rotate(0, Time.deltaTime * 30, 0, Space.Self);
                        licz[0].transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 3 * smooth * Time.deltaTime); // lerp to new angles
                    licz[1].transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 3 * smooth * Time.deltaTime);
                    licz[0].transform.tag = "false";
                    licz[1].transform.tag = "false";
               // }
                    count = 0;
                }
                else
                {
                    count++;
                }
  
            }
            licz = new GameObject[2];
            licz2 = new GameObject[8];

        }

    }
}
