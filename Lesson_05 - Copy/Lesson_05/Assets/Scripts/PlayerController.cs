using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float jumpForce = 400f;
    public float horizontalMove;
    private bool jump = false;
    public bool inAir = false;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public GameObject MageWeapon;
    public GameObject WarriorWeapon;

    string PlayerClass;
    int PlayerHealth;
    int PlayerStrength;
    int PlayerAgility;
    int PlayerDamage;
    int PlayerAbilityDamage;
    int PlayerIntelligence;
    int PlayerMana;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inAir = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        WarriorClass();
    }

    void WarriorClass()
    {
        if(!GetComponent<BaseWarrior>())
        {
            var Class = gameObject.AddComponent<BaseWarrior>();
            PlayerClass = Class.ClassName;
            PlayerHealth = Class.Health;
            PlayerStrength = Class.Strength;
            PlayerAgility = Class.Agility;
            PlayerDamage = Class.Damage;
            PlayerAbilityDamage = Class.AbilityDamage;
        }

        var weapon = Instantiate(WarriorWeapon, gameObject.transform);
        weapon.transform.position += new Vector3(0.6f, 0.3f, 0);
    }    

    void MageClass()
    {
        if(!GetComponent<Mage>())
        {
            var Class = gameObject.AddComponent<Mage>();
            PlayerClass = Class.ClassName;
            PlayerHealth = Class.Health;
            PlayerStrength = Class.Strength;
            PlayerAgility = Class.Agility;
            PlayerDamage = Class.Damage;
            PlayerIntelligence = Class.Intelligence;
            PlayerAbilityDamage = Class.AbilityDamage;
            PlayerMana = Class.Mana;
        }
        var weapon = Instantiate(MageWeapon, gameObject.transform);
        weapon.transform.position += new Vector3(0.6f, -0.4f, 0);
        weapon.transform.Rotate(0,0,-20,Space.Self);

    }


    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;
        if (horizontalMove < 0f) transform.localEulerAngles = new Vector3(0, 180, 0);
        if (horizontalMove > 0f) transform.localEulerAngles = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("Jump"))
        {
            animator.speed = 0.5f;
            
            jump = true;
            inAir = true;

        }

        if (transform.position.y < -10f)
            SceneManager.LoadScene("SampleScene");

        if (horizontalMove == 0&!jump)
        {
            //idle animation
            animator.speed = 1;
            animator.Play("Base Layer.IdleAnimation");
        }
        if(inAir)
        {
            animator.Play("Base Layer.JumpAnimation",0,2f);
        }
        
    }


    private void FixedUpdate()
    {
        Move(horizontalMove, jump);
    }



    void Move(float movement, bool canJump)
    {
        rb.velocity = new Vector2(movement * movementSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if(canJump&&GetComponent<CircleCollider2D>().IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = !canJump;

        }
        else if(horizontalMove!=0&&!jump)
        {
            animator.speed = 1;
            animator.Play("Base Layer.RunAnimation");
        }
    }


}
