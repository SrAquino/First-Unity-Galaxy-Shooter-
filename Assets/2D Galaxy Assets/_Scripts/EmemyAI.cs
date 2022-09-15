using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy: MUAHAHAHA I will kill you " + name);
        transform.position = new Vector3(-8,7,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
