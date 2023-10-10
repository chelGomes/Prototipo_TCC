using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // speed -> velocidade; jumpforce - > forca pulo
    public float Speed;
    public float JumpForce;

    // manipular a fisica do componente
    private Rigidbody2D rig;

    // variavel que define se o personagem pula ou não
    private bool isJumping;  

    // Start is called before the first frame update
    void Start(){
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update(){
        rig.velocity = new Vector2(Speed, rig.velocity.y); // passando a velocidade no eixo x

        // condicao de pular  do personagem
        if(Input.GetMouseButtonDown(0) && !isJumping){
             
             rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
             isJumping = true;
        }
    }

     // metodo que verifica se o personagem colidiu ou não no chão
    void OnCollisionEnter2D(Collision2D colisor){
        
        if(colisor.gameObject.layer == 8){
           isJumping = false;
        }
    }
}
