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
    
    //오브젝트 상호작용
    public InteractiveObject InteractiveObject { set {  _interactiveObject = value; } }
    private InteractiveObject _interactiveObject;


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

        //Player's Dir
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


        //scan object
        if (Input.GetMouseButtonDown(0))
        {
            Interaction();
        }
    }

    void FixedUpdate()
    {
        Vector2 moveVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);

        //Ray
        //Debug.DrawRay(rigid.position, dirVec * 1.0f, Color.red);
        //RaycastHit2D ray = Physics2D.Raycast(rigid.position, dirVec * 1.0f, LayerMask.GetMask("Object"));
        /*if (ray.collider != null)
        {
            scanObject = ray.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }*/
    }

    void LateUpdate()
    {
        animator.SetFloat("Speed", inputVec.magnitude);

        if(inputVec.x != 0)
        {
            spriteRenderer.flipX = inputVec.x < 0;
        }
    }

    void OnMove(InputValue value)
    {
        //Move Action -> Using InputSystem
        inputVec = value.Get<Vector2>();
    }

    private void Interaction()
    {
        if (_interactiveObject == null)
            return;

        _interactiveObject.Interaction();
    }
}
