using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 90f;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private void FixedUpdate() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime);

        if (moveY != 0){

            anim.SetBool("Walking", true);
            if (moveY < 0){
                anim.SetInteger("Direction", 0);
            }else{
                anim.SetInteger("Direction", 2);
            }
        }else if (moveX != 0){

            anim.SetBool("Walking", true);
            if (moveX < 0){
                anim.SetInteger("Direction", 3);
            }else{
                anim.SetInteger("Direction", 1);
            }
        }
        else{
            anim.SetBool("Walking", false);
        }
    }
}
