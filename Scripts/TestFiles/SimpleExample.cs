using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleExample : MonoBehaviour
{

    public string TheText = "Hello World!";

    // Start is called before the first frame update
    void Start()
    {
        //Calling TheText into object!
        Debug.Log(TheText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
