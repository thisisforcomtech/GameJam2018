using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour
{

    public AudioClip destroy;
    public GameObject smallAsteroid;

    private GameController gameController;
    public GameObject grandChild1;
    public GameObject grandChild2;

    // Use this for initialization
    void Start()
    {

        // Get a reference to the game controller object and the script
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();

        grandChild1 = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        grandChild2 = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
        grandChild1.GetComponent<Renderer>().enabled = false;
        grandChild2.GetComponent<Renderer>().enabled = false;

        if (tag.Equals("Small Asteroid"))
        {
            GetComponent<Rigidbody>()
                    .AddForce(transform.up * Random.Range(-50.0f, 150.0f)); 
             grandChild1.GetComponent<Renderer>().enabled = true;
            grandChild2.GetComponent<Renderer>().enabled = true;
        }

        // Push the asteroid in the direction it is facing
        /*       

        // Give a random angular velocity/rotation
        /*        GetComponent<Rigidbody>()
                    .angularVelocity = Random.Range(-0.0f, 90.0f);*/

    }
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up, 100f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Sonar") || other.gameObject.tag.Equals("Blip"))
        {
            grandChild1.GetComponent<Renderer>().enabled = true;
            grandChild2.GetComponent<Renderer>().enabled = true;
        }
    }
    void OnCollisionEnter(Collision c)
    {
      
        if (c.gameObject.tag.Equals("EnemyBullet") )
        {

            // Destroy the bullet

            // If large asteroid spawn new ones

            // Play a sound
            /*AudioSource.PlayClipAtPoint(
                destroy, Camera.main.transform.position);*/

            // Add to the score
            //gameController.IncrementScore();

            // Destroy the current asteroid
            SpawnAsteroids();
            Destroy(c.gameObject);
            Destroy(gameObject);

        }
        else if (c.gameObject.tag.Equals("Enemy") || c.gameObject.tag.Equals("EnemyShip2"))
        {

            
            SpawnAsteroids();

            Destroy(gameObject);

        }
        else if(tag.Equals("Small Asteroid") && c.gameObject.tag.Equals("EnemyBullet"))
        {
            Destroy(gameObject);
        }

    }
    public void SpawnAsteroids ()
    {
        if (tag.Equals("Large Asteroid"))
        {
            // Spawn small asteroids
            Instantiate(smallAsteroid,
                new Vector3(transform.position.x - .5f,
                    transform.position.y - .5f, 0),
                    Quaternion.Euler(0, 0, 90));

            // Spawn small asteroids
            Instantiate(smallAsteroid,
                new Vector3(transform.position.x + .5f,
                    transform.position.y + .0f, 0),
                    Quaternion.Euler(0, 0, 0));

            // Spawn small asteroids
            Instantiate(smallAsteroid,
                new Vector3(transform.position.x + .5f,
                    transform.position.y - .5f, 0),
                    Quaternion.Euler(0, 0, 270));

            //gameController.SplitAsteroid(); // +2

        }
    }
}