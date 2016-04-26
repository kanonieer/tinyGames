using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public float smooth = 1f;

    private Vector3 targetAngles;
    // Use this for initialization
    void Start () {
	
	}

    void Update()
    {


                targetAngles = transform.eulerAngles + 90f * Vector3.up; // what the new angles should be
                                                                         // transform.Rotate(0, Time.deltaTime * 30, 0, Space.Self);
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 4 * smooth * Time.deltaTime); // lerp to new angles
            
        

    }
}
