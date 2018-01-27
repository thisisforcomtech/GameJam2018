using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    //used for movements
    float rotationSpeed = 100.0f;
    float thrustForce = 2f;

    //used for rotation towards pointer
    private Vector3 mouse_pos;
    private Transform target; //Assign to the object you want to rotate
    private Vector3 object_pos;
    private float angle;

    //ship stats
    int lives;

    GameObject warning;
    GameObject lost;
    GameObject exit;

    // Use this for initialization
    void Start () {
        target = this.GetComponent<Transform>();
        lives = 1;
        warning = GameObject.Find("Warning");
        lost = GameObject.Find("Lost");
        exit = GameObject.Find("Exit");
        lost.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) || Input.GetAxis("Vertical") != 0)
        {
            // Thrust the ship if necessary
            GetComponent<Rigidbody>().
                AddForce(transform.up * thrustForce);
        }
        
        // Has a bullet been fired
        if (Input.GetMouseButtonUp(0) || Input.GetKey("space"))
        {
            Debug.Log("ping");
            SendSignal();
        }
        

        //calls rotation method
        LookAtMouse();
        SpawnHelpers();
        checkDead();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LivesPickup")
        {
            lives++;
        }
        if (other.gameObject.tag == "EnemyBullet")
        {
            lives--;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rocks")
        {
            lives--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            lives--;
        }
        if (other.gameObject.tag == "Home")
        {
            if (lives < 5)
            {
                Destroy(other.gameObject);
            }
            else if (lives >= 5)
            {
                lives = 1;
            }
        }
    }

    void checkDead()
    {
        if (lives <= 0)
        {
            warning.gameObject.SetActive(false);
            lost.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void SpawnHelpers ()
    {
        switch (lives)
        {
            case 1:
                warning.gameObject.SetActive(true);
                transform.Find("Helper (0)").gameObject.SetActive(false);
                transform.Find("Helper (1)").gameObject.SetActive(false);
                transform.Find("Helper (2)").gameObject.SetActive(false);
                transform.Find("Helper (3)").gameObject.SetActive(false);
                break;
            case 2:
                warning.gameObject.SetActive(false);
                transform.Find("Helper (0)").gameObject.SetActive(true);
                transform.Find("Helper (1)").gameObject.SetActive(false);
                transform.Find("Helper (2)").gameObject.SetActive(false);
                transform.Find("Helper (3)").gameObject.SetActive(false);
                break;
            case 3:
                transform.Find("Helper (0)").gameObject.SetActive(true);
                transform.Find("Helper (1)").gameObject.SetActive(true);
                transform.Find("Helper (2)").gameObject.SetActive(false);
                transform.Find("Helper (3)").gameObject.SetActive(false);
                break;
            case 4:
                transform.Find("Helper (0)").gameObject.SetActive(true);
                transform.Find("Helper (1)").gameObject.SetActive(true);
                transform.Find("Helper (2)").gameObject.SetActive(true);
                transform.Find("Helper (3)").gameObject.SetActive(false);
                break;
            case 5:
                transform.Find("Helper (0)").gameObject.SetActive(true);
                transform.Find("Helper (1)").gameObject.SetActive(true);
                transform.Find("Helper (2)").gameObject.SetActive(true);
                transform.Find("Helper (3)").gameObject.SetActive(true);
                break;
        }

    }

    void SendSignal()
    {
        
    }

    //rotation method
    void LookAtMouse()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = (float)5.23; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        Quaternion finalRot = Quaternion.Euler(0, 0, (angle - 90));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, finalRot, Time.deltaTime * rotationSpeed);
    }
}
