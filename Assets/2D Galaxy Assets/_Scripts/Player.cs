using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalImput;
    public float speed = 5.0f;

    public float fireRate = 0.35f;
    public float canFire = 0.0f;

    public bool powerShoot = false;
    public bool powerSpeed = false;
    public bool powerShield = false;

    [SerializeField]// Variavel privada mas pode ser modificada no unity
    private GameObject NormalLaser;

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
        
        if (powerSpeed){
            transform.Translate(Vector3.right * Time.deltaTime * (speed*2) * horizontalImput);
        }
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

            if (powerShoot){
                 Instantiate(NormalLaser, transform.position + new Vector3(-0.55f,0,0), Quaternion.identity);
                 Instantiate(NormalLaser, transform.position + new Vector3(0.55f,0,0), Quaternion.identity);
                 
            }
            // Input.GetKeyDown(KeyCode.Space)
            // Sempre que apertar espaço um novo objeto é instanciado
            //          (O objeto, O local, );
                Instantiate(NormalLaser, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
            //          (Marco quem é o objeto a ser instanciado la no unity)
            //          (transform.position retorna a posição atual do player)
            //          (Quaternion = )

                canFire = fireRate + Time.time;
                //Atira denovo depois do tempo de cooldown
        }
    } 

    public void powerUpOn(string power){
        switch(power){
            case "triple":
                powerShoot = true;
                StartCoroutine(PowerDownRotine("triple"));
            break;

            case "speed":
                powerSpeed = true;
                StartCoroutine(PowerDownRotine("speed"));
            break;

            case "shield":
                powerShield = true;
                StartCoroutine(PowerDownRotine("shield"));
            break;
        }
    }
    IEnumerator PowerDownRotine(string power){
        yield return new WaitForSeconds(5.0f);

        switch(power){
            case "triple":
                powerShoot = false;
            break;

            case "speed":
                powerSpeed = false;
            break;

            case "shield":
                powerShield = false;
            break;
        }
    }
}