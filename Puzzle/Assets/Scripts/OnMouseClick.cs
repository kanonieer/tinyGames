using UnityEngine;
using System.Collections;

public class OnMouseClick : MonoBehaviour {

    public float smooth = 1f;

    private Vector3 targetAngles;

	void OnMouseDown()
    {
       
        if (gameObject.tag == "false")
        {
            if (GameObject.FindGameObjectsWithTag("true").Length == 2) { }
            else{
            gameObject.transform.tag = "true";
             }
       }
    }
    void Update()
    {
        
        if (gameObject.transform.tag == "true")
        {
            if(gameObject.transform.eulerAngles.y<=175)
            {
                // some condition to rotate 180
                targetAngles = transform.eulerAngles + 90f * Vector3.up; // what the new angles should be
                                                                          // transform.Rotate(0, Time.deltaTime * 30, 0, Space.Self);
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 4*smooth * Time.deltaTime); // lerp to new angles
            }
        }
      
    }
  
}
