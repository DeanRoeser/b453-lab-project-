using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{

    public Light scale;
    float duration;
    float originalRange;
    public float highLight;
    public float lowLight;
    private float val;
    public float smoothTime;
    private int frames = 0;
    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        //scale = GetComponent<light>();
        originalRange = scale.range;
    }




    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames %7 == 0){
            Burnout();
        }

        if(Input.GetKey("w"))
        {
            TurnUp();
        }
        if(Input.GetKey("s"))
        {
            TurnDown();
        }
        if(!Input.GetKey("s") || !Input.GetKey("w"))
        {
            scale.range = Mathf.SmoothDamp(scale.range, originalRange, ref val, smoothTime);
        }
    }

    public void LightReset(){
        scale.intensity = 100;
    }

    void Burnout(){
        scale.intensity = scale.intensity - 1;

        if(scale.intensity == 0){
            gm.EndGame();
        }

    }


    void TurnUp()
    {
        scale.range = Mathf.SmoothDamp(scale.range, highLight, ref val, smoothTime);
    }

    void TurnDown()
    {
        scale.range = Mathf.SmoothDamp(scale.range, lowLight, ref val, smoothTime);
    }
}
