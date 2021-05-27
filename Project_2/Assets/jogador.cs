using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class jogador : MonoBehaviour
{
    public Text placarTexto;
    public int placar = 0;
    private Rigidbody rbd;
    private Animator anim;
    public float velRot = 10;
    private float rotMouseX=0;
    public float vel =500;
    private Quaternion rotOriginal;
    public float altura;
    public float largura;
    void Start()
    {
                rbd = GetComponent<Rigidbody>();
                rotOriginal = transform.localRotation;
                altura = 17;
                largura = 13;
                anim = GetComponent<Animator>();
                

    }

    // Update is called once per frame
    void Update()
    {
        placarTexto.text = "Placar: "+ placar;

        Move();
        
    }
    void Move(){
        float moveFrente = Input.GetAxis("Vertical");
        float moveLados = Input.GetAxis("Horizontal");
    
                //this.transform.position = new Vector3(-(largura-4), transform.position.y,0);

        Vector3 velo = transform.TransformDirection(new Vector3(moveLados * vel, rbd.velocity.y, moveFrente*vel));
        rbd.velocity = velo;
        if(moveFrente*vel>0)
            anim.SetInteger("transition",1);
        if(moveFrente*vel==0)
                anim.SetInteger("transition",0);
                
        rotMouseX += Input.GetAxis("Mouse X");
        Quaternion lado = Quaternion.AngleAxis(rotMouseX, Vector3.up);
        transform.localRotation = rotOriginal * lado;
        // Rotação Teclado
        int rot = 0;
        if(Input.GetKey(KeyCode.Q))
            rot =-1;
        else if(Input.GetKey(KeyCode.E))
            rot=1;
        transform.Rotate(new Vector3(0,rot*Time.deltaTime * velRot,0));

        if (this.transform.position.x > largura)
            this.transform.position = new Vector3(-(largura), transform.position.y,0);
        if (this.transform.position.x < -largura)
            this.transform.position = new Vector3((largura), transform.position.y,0);
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "objetos"){
            placar+= 10;
            collision.gameObject.SetActive(false);
        }
        if(placar>=80){
            SceneManager.LoadScene(2);
            //Destroy(gameObject);
        }
    }
  
}
