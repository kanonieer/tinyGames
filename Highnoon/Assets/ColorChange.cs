using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour
{
        Gradient g;
        GradientColorKey[] gck;
        GradientAlphaKey[] gak;
    float time;
    bool switcher;
    void Start()
    {

        g = new Gradient();
        gck = new GradientColorKey[2];
        gck[0].color = Color.red;
        gck[0].time = 0.0F;
        gck[1].color = Color.blue;
        gck[1].time = 1.0F;
        gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;
        gak[1].alpha = 0.0F;
        gak[1].time = 1.0F;
         g.SetKeys(gck, gak);
        time = 0.0F;
        switcher = true;
    }
   

     
    void FixedUpdate()
    {
        if (time < 1.0F && switcher == true)
        {
            time =+ 0.01F;
            if(time == 1.0F)
            {
                switcher = false;
            }
        }
        else
        {
                time = -0.01F;
            if (time == 0.0F)
            {
                switcher = true;
            }
            
            
        }
        gameObject.GetComponent<Renderer>().material.color = g.Evaluate(time);
    
    }
}
