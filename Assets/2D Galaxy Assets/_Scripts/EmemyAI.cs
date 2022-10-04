using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 3.0f;
    void Start()
    {
        Debug.Log("Enemy: MUAHAHAHA I will kill you " + name);
        transform.position = new Vector3(-8,7,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -7){
            transform.position = new Vector3(Random.Range(-7,7),7,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Colidiu com: " + other.name);

        if(other.tag == "Laser"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if(other.tag == "Player"){
            Player p1 = other.GetComponent<Player>();
                if(p1 != null)
                    p1.Damage();
                    Destroy(this.gameObject);
        }
    
    }
}
