using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.y > 8){
            Destroy(this.gameObject);
        }
    }
}
