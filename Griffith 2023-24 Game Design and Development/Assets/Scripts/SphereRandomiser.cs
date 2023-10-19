using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SphereRandomiser : MonoBehaviour
{
    public float Size; //float is any number that has decimals e.g. 1.2
    public float YSizeMultiplier;
    public float JumpForce;

    public int TestInt ; //int is a whole number 1,2, 5 etc

    public string Name; // string is a series of characters e.g. "Bob"

    public bool Exists; //bool is a condition that is either true or false

    //public Color myColor;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(Size, Size*YSizeMultiplier, Size); // transforming the size to the size variable
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*JumpForce);
            //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(JumpForce, 0, 0));
            Debug.Log("I jumped");
        }
    }

    void OnCollisionEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
