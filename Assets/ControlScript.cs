using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public bool disableControls = false;

    public GameObject explosion;

    public WinLoseScript winlose;
    public HPScript hpbar;

    public float HP = 1;

    public Rigidbody2D body;
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;
    public KeyCode chrg;
    public float speed = 10f;
    public float jumpSpeed = 10f;

    public float chargeTime = 1f;
    public float walkTime = 0.3f;

    public SpriteRenderer spriteRenderer;
    public Sprite idle;
    public Sprite charge;
    public Sprite jump1;
    public Sprite jump2;
    public Sprite walk1;
    public Sprite walk2;

    bool charging = false;
    float chargingCounter = 1f;

    float walkingCounter = 0.3f;
    bool walkSwitch = false;

    bool falling = true;
    bool jumpReady = true;
    float jump = 0f;

    float hMove = 0f;

    public AudioSource winS;
    public AudioSource loseS;
    public AudioSource chargeS;
    public AudioSource hit1S;
    public AudioSource hit2S;
    public AudioSource walk1S;
    public AudioSource walk2S;
    public AudioSource jumpS;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        chargingCounter = chargeTime;
        walkingCounter = walkTime;
    }

    void Update()
    {
        jump = 0f;
        hMove = 0f;

        //check for reset jump
        if (body.velocity.y < -0.001f)
        {
            falling = true;
        }
        else if (body.velocity.y > 0.001f)
        {
            falling = false;
        }
        else if (falling == true)
        {
            jumpReady = true;
        }


        //set sprite
        if (charging == true)
        {
            spriteRenderer.sprite = charge;
            chargingCounter -= Time.deltaTime;
        }
        else if (body.velocity.y < -0.001f || body.velocity.y > 0.001f)
        {
            spriteRenderer.sprite = jump2;
        }
        else if (body.velocity.x != 0f)
        {
            if (walkSwitch == true)
            {
                spriteRenderer.sprite = walk1;
            }
            else
            {
                spriteRenderer.sprite = walk2;
            }
            walkingCounter -= Time.deltaTime;
        }
        else
        {
            spriteRenderer.sprite = idle;
        }

        //flip sprite
        if (body.velocity.x < -0.001f)
        {
            spriteRenderer.flipX = true;
        }
        else if (body.velocity.x > 0.001f)
        {
            spriteRenderer.flipX = false;
        }

        if (disableControls == false)
        {
            //check inputs
            if (Input.GetKeyDown(up) && jumpReady == true)
            {
                jumpS.Play();
                spriteRenderer.sprite = jump1;
                jump = 1f;
                jumpReady = false;
            }
            if (Input.GetKeyDown(chrg) && charging == false)
            {
                chargeS.Play();
                charging = true;
                speed *= 1.5f;
            }
            if (Input.GetKey(left))
            {
                hMove -= 1f;
            }
            if (Input.GetKey(right))
            {
                hMove += 1f;
            }
        }



        //counters
        if (chargingCounter <= 0f)
        {
            charging = false;
            speed /= 1.5f;
            chargingCounter = chargeTime;
        }
        if (walkingCounter <= 0f)
        {
            if (walkSwitch == true)
            {
                walk1S.Play();
            }
            else
            {
                walk2S.Play();
            }
            walkSwitch = !walkSwitch;
            walkingCounter = walkTime;
        }

        body.velocity = new Vector2(hMove * speed, body.velocity.y + jump * jumpSpeed);
        Camera.main.transform.position = new Vector3(body.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            hit1S.Play();
            Destroy(collider.gameObject);
            HP -= 0.25f;
            hpbar.setHP(HP);
            if (HP <= 0f)
            {
                loseS.Play();
                winlose.lose = true;
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else if (collider.gameObject.tag == "flag")
        {
            winS.Play();
            disableControls = true;
            winlose.win = true;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "turret")
        {
            if (charging)
            {
                Instantiate(explosion, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);
            }
        }
    }
}