using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public RandomMovement RM;
    public int Coin=10;
    public int count1;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject winTextObjectDraw;

    public float speed = 0;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count1 = 0;

        SetCountText();
        winTextObject.SetActive(false);
        winTextObjectDraw.SetActive(false);
    }

    private void SetCountText(){
        countText.text = "Count team1: " + count1.ToString();
        
        if(count1==RM.count2 && Coin == 0){
            winTextObjectDraw.SetActive(true);
        }
        else if(count1>RM.count2 && Coin==0){
            winTextObject.SetActive(true);
        }
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count1 = count1 + 1;
            Coin-=1;
            SetCountText();
        }   
    }

}