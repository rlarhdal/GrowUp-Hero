using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Vector2 dirVec;

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
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");

        if(inputVec.x == 0 && inputVec.y != 0)
        {
            if (inputVec.y == 1)
                dirVec = Vector3.up;
            else if (inputVec.y == -1)
                dirVec = Vector3.down;
        }
        else
        {
            if(inputVec.x == 1)
                dirVec = Vector3.right;
            else if (inputVec.x == -1)
                dirVec = Vector3.left;
        }

        if (Input.GetMouseButtonDown(0) && scanObject != null)
        {
            Debug.Log("This is : " + scanObject.name);
        }
    }

    void FixedUpdate()
    {
        Vector2 moveVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 1.0f, Color.red);
        RaycastHit2D ray = Physics2D.Raycast(rigid.position, dirVec * 1.0f, LayerMask.GetMask("Object"));

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
