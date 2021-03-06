using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class RandomMovement : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerController PC;
    public int count2;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject winTextObjectDraw;

    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector3 movement;
    private float timeLeft;
     
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        count2 = 0;

        SetCountText();
        winTextObject.SetActive(false);
        winTextObjectDraw.SetActive(false);
     }

     private void SetCountText(){
        countText.text = "Count team2: " + count2.ToString();
        
        if(count2==PC.count1 && PC.Coin == 0){
            winTextObjectDraw.SetActive(true);
        }
        else if(count2>PC.count1 && PC.Coin==0){
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame
     
     void Update()
     {
       timeLeft -= Time.deltaTime;
       if(timeLeft <= 0)
       {
         movement = new Vector3(Random.Range(-1f, 1f), 0.0f, Random.Range(-1f, 1f));
         timeLeft += accelerationTime;
       }
     }
     
     void FixedUpdate()
     {
       rb.AddForce(movement * maxSpeed);
     }  

     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count2 = count2 + 1;
            PC.Coin-=1;
            SetCountText();
        }   
    }
}
