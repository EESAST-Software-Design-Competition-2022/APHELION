using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    private CharacterController controller;
    public float VerticalMoveSpeed = 5f;
    public float HorizontalMoveSpeed = 5f;
    public float RunSpeed = 10f;

    public float RotateSpeed = 5f;
    public float Gravity = -9.8f;
    private Vector3 Velocity = Vector3.zero;
    public Transform GroundCheck;
    private bool IsGround;
    public LayerMask layerMask;

    public float JumpHeight = 3f;
    public int life = 100;

    private float CheckRadius = 0.2f;

    public GameObject Bag;
    public bool isOpen = false;
    Animator anim;

    public AudioSource bgm;
    public AudioSource jump;
    public AudioSource damage;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        var data = GameObject.Find("Player").GetComponent<PlayerData>();
        VerticalMoveSpeed = 5+(data.moveSpeed-300)/20;
        HorizontalMoveSpeed = 5+(data.moveSpeed-300)/20;
        RunSpeed = 10+(data.moveSpeed-300)/20;
        Move();
        Rotate();
        OpenBag();
    }
    private void Move()
    {
        IsGround = Physics.CheckSphere(GroundCheck.position, CheckRadius, layerMask);
        if(IsGround && Velocity.y<0)
        {
            Velocity.y = 0;
        }
        if(IsGround && Input.GetButtonDown("Jump"))
        {
            jump.Play();
            Velocity.y += Mathf.Sqrt(JumpHeight * -2 * Gravity);
        }

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var move1 = transform.forward * VerticalMoveSpeed * vertical * Time.deltaTime;
        var move2 = transform.right * HorizontalMoveSpeed * horizontal * Time.deltaTime;
        controller.Move(move1);
        controller.Move(move2);

        Velocity.y += Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);

        if(vertical!=0)
        {
            //walk.Play();
            if(vertical>0)
            {
                if(Input.GetKey("r"))
                {
                    anim.SetBool("Run", true);
                    move1 = transform.forward * RunSpeed * vertical * Time.deltaTime;
                    controller.Move(move1);
                }
                else
                {
                    anim.SetBool("Run", false);
                    anim.SetBool("Movefront", true);
                }
            }
            else
            {
                anim.SetBool("Moveback", true);
            }
        }
        else if(horizontal!=0)
        {
            //walk.Play();
            if(horizontal>0)
            {
                anim.SetBool("Moveright", true);
            }
            else
            {
                anim.SetBool("Moveleft", true);
            }
        }
        else
        {
            anim.SetBool("Movefront", false);
            anim.SetBool("Moveback", false);
            anim.SetBool("Moveleft", false);
            anim.SetBool("Moveright", false);
        }
    }
    private void Rotate()
    {
        if(Input.GetKey("e"))
        {
            transform.Rotate(Vector3.up, RotateSpeed);
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.down, RotateSpeed);
        }
    }
    void OpenBag()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            Bag.SetActive(isOpen);
        }
    }
}
