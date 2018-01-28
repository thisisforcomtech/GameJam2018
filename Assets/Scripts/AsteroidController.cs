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

        // Push the asteroid in the direction it is facing
        /*        GetComponent<Rigidbody>()
                    .AddForce(transform.up * Random.Range(-50.0f, 150.0f));*/

        // Give a random angular velocity/rotation
        /*        GetComponent<Rigidbody>()
                    .angularVelocity = Random.Range(-0.0f, 90.0f);*/

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
      
        if (c.gameObject.tag.Equals("Bullet"))
        {

            // Destroy the bullet
            Destroy(c.gameObject);

            // If large asteroid spawn new ones
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

                gameController.SplitAsteroid(); // +2

            }
            else
            {
                // Just a small asteroid destroyed
                gameController.DecrementAsteroids();
            }

            // Play a sound
            /*AudioSource.PlayClipAtPoint(
                destroy, Camera.main.transform.position);*/

            // Add to the score
            //gameController.IncrementScore();

            // Destroy the current asteroid
            Destroy(gameObject);

        }

    }
}