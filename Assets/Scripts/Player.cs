using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    GameObject scanObject;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 moveVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);

        //Ray
        Debug.DrawRay(rigid.position, inputVec, new Color(0, 1, 0));
        RaycastHit2D ray = Physics2D.Raycast(rigid.position, inputVec.normalized, 1f, LayerMask.GetMask("Object"));

        if (ray.collider != null)
        {
            scanObject = ray.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    void OnMove(InputValue value)
    {
        //Move Action -> Using InputSystem
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        animator.SetFloat("Speed", inputVec.magnitude);

        if(inputVec.x != 0)
        {
            spriteRenderer.flipX = inputVec.x < 0;
        }   
    }
}
