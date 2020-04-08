using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTracker : MonoBehaviour
{
    public bool isOnGround;
    public Text scoreText;
    private int damageCount;


    public void UpdateDamageUI()
    {
        damageCount += 1;
        scoreText.text = "Score: " + (int)damageCount;
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;

        if (collision.gameObject.CompareTag("PickUp"))
        {

            UpdateDamageUI();
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            isOnGround = true;

        }

    }*/

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

}
