using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    //used for movements
    float rotationSpeed = 100.0f;
    float thrustForce = 2f;
    private float horizontal = 0.0f;
    private float vertical = 0.0f;

    //#ScoreUI
    [SerializeField]
    private GameObject[] tallies = new GameObject[3];




    //used for rotation towards pointer
    private Vector3 mouse_pos;
    private Transform target; //Assign to the object you want to rotate
    private Vector3 object_pos;
    private float angle;
    public GameObject sonar;
    public GameObject Sonar2;
    public GameObject Radar;
    public GameObject gamecontroller;

    private bool cutSceneMove = true;

    //ship stats
    int lives;



    GameObject warning;
    GameObject lost;
    GameObject exit;



    // Use this for initialization
    void Start()
    {

        for (int i = 0; i <= tallies.Length; i++)
        {
            //switch (tallies[i].name) {

            //}

        }

        //CutScene();
        target = this.GetComponent<Transform>();
        lives = 1;
        warning = GameObject.Find("Warning");
        lost = GameObject.Find("Lost");
        exit = GameObject.Find("Exit");
        lost.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);

        //for (int i = 0; i < 150; i++)
        //{

        //  Instantiate(sonar, new Vector3 (0,0,0), new Quaternion(0,0,0,0));

        //}

        cutSceneMove = false;
        gamecontroller = GameObject.FindWithTag("GameController");
        gamecontroller.GetComponent<GameController>().BeginGame();


    }
    void CutScene()
    {
        //StartCoroutine(Example());
    }
    IEnumerator Example()
    {

        GameObject Scene = GameObject.FindWithTag("Scene");
        yield return new WaitForSeconds(5);
        Scene.GetComponent<Dialogue>().changeScene(2);

        yield return new WaitForSeconds(5);
        ShootSonar2();
        yield return new WaitForSeconds(5);
        Scene.GetComponent<Dialogue>().changeScene(3);

        yield return new WaitForSeconds(5);
        Scene.GetComponent<Dialogue>().changeScene(4);

        yield return new WaitForSeconds(5);
        Scene.GetComponent<Dialogue>().changeScene(5);

        yield return new WaitForSeconds(5);
        Destroy(Scene);

        cutSceneMove = false;

        gamecontroller.GetComponent<GameController>().BeginGame();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!cutSceneMove)
        {

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            if (Input.GetMouseButton(0) || Input.GetAxis("Vertical") != 0)
            {
                // Thrust the ship if necessary
                GetComponent<Rigidbody>().
                    AddForce(transform.up * thrustForce);
            }

            // Has a bullet been fired
            if (Input.GetKey("space"))
            {
                ShootSonar2();
            }


            //calls rotation method
            SpawnHelpers();
            checkDead();
        }
        LookAtMouse();
        checkBounds();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LivesPickup")
        {
            lives++;
            Destroy(other.gameObject);
            //gamecontroller.GetComponent<GameController>().spawnEnemies(5,2);
        }
        else if (other.gameObject.tag == "EnemyBullet")
        {
            lives--;
            gamecontroller.GetComponent<GameController>().DecrementLives();
        }
        else if (other.gameObject.tag == "HomeFrame")
        {
            gamecontroller.GetComponent<GameController>().IncrementScore(lives - 1);
            lives = 1;
        }


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Large Asteroid" || other.gameObject.tag == "Small Asteroid")
        {
            lives--;
            gamecontroller.GetComponent<GameController>().DecrementLives();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            lives--;
            gamecontroller.GetComponent<GameController>().DecrementLives();
        }

    }
    void ShootSonar()
    {

        // Spawn a bullet
        //Instantiate(bullet,
        //   new Vector3(transform.position.x, transform.position.y, 0),
        //   transform.rotation);
        //Debug.Log(transform.rotation);
        GameObject Rad =
            GameObject.FindWithTag("Radar");
        GameObject[] sonars = GameObject.FindGameObjectsWithTag("Sonar");

        if (Rad == null)
        {
            Vector3 center = transform.position;
            foreach (GameObject sonar in sonars)
            {
                Vector3 pos = RandomCircle(center, 1.5f);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                sonar.transform.position = pos;
                sonar.transform.rotation = rot;
                sonar.GetComponent<SonarController>().run();

            }
            Instantiate(Radar, this.transform.position, this.transform.rotation);
        }
        // Play a shoot sound
    }
    void ShootSonar2()
    {
        GameObject son =
            GameObject.FindWithTag("Sonar");
        if (son == null)
            Instantiate(Sonar2, this.transform.position, this.transform.rotation).GetComponent<MeshRenderer>().material.color = new Color(1, 0.92f, 0.016f, 0.2f);
        // Spawn a bullet
        //Instantiate(bullet,
        //   new Vector3(transform.position.x, transform.position.y, 0),
        //   transform.rotation);
        //Debug.Log(transform.rotation);

        // Play a shoot sound
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

    void SpawnHelpers()
    {
        switch (lives)
        {
            case 1:
                transform.Find("Helper (0)").gameObject.SetActive(false);
                transform.Find("Helper (1)").gameObject.SetActive(false);
                transform.Find("Helper (2)").gameObject.SetActive(false);
                transform.Find("Helper (3)").gameObject.SetActive(false);
                break;
            case 2:
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
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    void checkBounds()
    {
        
        if ((transform.position.x > 35  ||
            transform.position.x < -35 ||
            transform.position.y > 35 ||
            transform.position.y < -35) &&
            (transform.position.x < 40 ||
            transform.position.x > -40 ||
            transform.position.y < 40 ||
            transform.position.y > -40))
        {
            warning.gameObject.SetActive(true);
        }
        else if (transform.position.x < 35 ||
            transform.position.x > -35 ||
            transform.position.y < 35 ||
            transform.position.y > -35)
        {
            warning.gameObject.SetActive(false);
        }
        if (transform.position.x > 40 || transform.position.x < -40 || transform.position.y > 40 || transform.position.y < -40)
        {
            warning.gameObject.SetActive(false);
            lives--;
        }
    }
}
