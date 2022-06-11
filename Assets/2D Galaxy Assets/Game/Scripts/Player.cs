using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalImput;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start(){
        Debug.Log("Hello: " + name);
        transform.position = new Vector3(0,0,0);
        
    }

    // Update is called once per frame
    void Update(){
        horizontalImput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalImput);
    }
}
