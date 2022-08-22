using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalImput;
    public float speed = 5.0f;

    public float fireRate = 0.25f;
    public float canFire = 0.0f;

    public bool powerShoot = false;
    public bool powerSpeed = false;

    [SerializeField]// Variavel privada mas pode ser modificada no unity
    private GameObject NormalLaser;
    [SerializeField]
    private GameObject TripleLaser;

    // Start is called before the first frame update
    void Start(){
        Debug.Log("Hello: " + name);
        transform.position = new Vector3(0,-4,0);
        
    }

    // Update is called once per frame
    void Update(){
        Moviment();
        Shooting();

        
    }

    private void Moviment(){

        // Captura entrada do teclado (setas '<-' '->' ou 'a' 'd')
        horizontalImput = Input.GetAxis("Horizontal");
        // Atualiza as informações do objeto player multiplicando por 1 ou -1 o que faz ir pra direita ou esquerda
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalImput);

        // Limita o player para não sair da tela
        if (transform.position.x > 7.5f){
            transform.position = new Vector3(7.5f, transform.position.y, 0);
        }
        if (transform.position.x < -7.5f) {
            transform.position = new Vector3(-7.5f, transform.position.y, 0);
        }
    }

    private void Shooting(){
        if(Time.time > canFire){

            if (powerShoot == true){
                 Instantiate(TripleLaser, transform.position + new Vector3(-1.246f,0.5f,0), Quaternion.identity);
                 
            } else {
            // Input.GetKeyDown(KeyCode.Space)
            // Sempre que apertar espaço um novo objeto é instanciado
            //          (O objeto, O local, );
                Instantiate(NormalLaser, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
            //          (Marco quem é o objeto a ser instanciado la no unity)
            //          (transform.position retorna a posição atual do player)
            //          (Quaternion = )

            }
            
                canFire = fireRate + Time.time;
                //Atira denovo depois do tempo de cooldown
        }
    } 
}
