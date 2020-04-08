using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float gravityModifier;
    public bool isOnGround = true;
    public float speed = 4.0F;
    public float turnspeed = 25.0f;
    public float horizontalInput;
    public float forwardInput;
    public float jumpForce = 5;

    public Text scoreText;
    private int damageCount;


    public GameObject projectilePrefab;

    private Vector3 moveDirection = Vector3.back;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
       
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalInput);
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isOnGround = true;
        if (other.gameObject.CompareTag("PickUp"))
        {
            print("We Have our pickup");
            other.gameObject.SetActive(false);

            UpdateDamageUI();
            isOnGround = true;
        }

    }
    public void UpdateDamageUI()
    {
        damageCount += 1;
        scoreText.text = "Score: " + (int)damageCount;
    }
}
