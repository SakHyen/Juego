using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContent : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float speed;

    int score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float movementhorizontal = Input.GetAxis("Horizontal");
        float movementvertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movementhorizontal, 0f, movementvertical);
        myRigidbody.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Comparo el tag del objeto contra el que he colisionado, para 
        // desactivarlo solo en el caso de que sea pickup
        if (other.gameObject.CompareTag("Pickup"))
        {
            // Si es un pickup, lo desactivo
            other.gameObject.SetActive(false);

            score += other.gameObject.GetComponent<Pickup>().points;
            Debug.Log("Mi Puntuacion es --->" + score);
        }
    }
}
