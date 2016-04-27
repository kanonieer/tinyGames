using UnityEngine;
using System.Collections;


public class ColorChange : MonoBehaviour
{
        Gradient g;
        GradientColorKey[] gck;
        GradientAlphaKey[] gak;
    float time;
    bool switcher;
    Color[] colorTab = { Color.blue,Color.white,Color.cyan};
    Color alpha, betha;
    void Start()
    {
        colorSet(Color.magenta,Color.cyan);
        time = 0.0F;
        switcher = true;
    }
   void colorSet(Color a, Color b)
    {
        alpha = a;
        betha = b;
        g = new Gradient();
        gck = new GradientColorKey[2];
        gck[0].color = a;
        gck[0].time = 0.0F;
        gck[1].color = b;
        gck[1].time = 1.0F;
        gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;
        gak[1].alpha = 0.0F;
        gak[1].time = 1.0F;
        g.SetKeys(gck, gak);
    }
    Color chooseColor()
    {
        int i = Random.Range(0,3);
        return colorTab[i];
    }
     
    void FixedUpdate()
    {
        if (time < 1.0F && switcher == true)
        {
            time = time + 0.001F;
            if(time > 0.95F)
            {
                colorSet(chooseColor(),betha);
                switcher = false;
            }
        }
        else
        {
                time = time - 0.001F;
            if (time < 0.05F)
            {
                colorSet(alpha,chooseColor());
                switcher = true;
            }
            
            
        }
        gameObject.GetComponent<Renderer>().material.color = g.Evaluate(time);
    
    }
}
