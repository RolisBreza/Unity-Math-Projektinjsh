using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    

    void Start()
    {
        //Transform.localScale.y = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0f)
        {
            transform.localScale += new Vector3(-0.01f, 0f, 0f);
            transform.position += new Vector3(0f, -0.005f, 0f);
        }
    }
}
