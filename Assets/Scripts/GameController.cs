using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject pickups;
    public GameObject enemies;

    private int score;
    private int hiscore;
    private int asteroidsRemaining;
    private int lives;
    private int wave;
    private int increaseEachWave = 4;


    public Transform camera;

    // Use this for initialization
    void Start()
    {

        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {

        // Quit if player presses escape
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void BeginGame()
    {

        score = 0;
        lives = 3;
        wave = 1;

        // Prepare the HUD
        /*scoreText.text = "SCORE:" + score;
        hiscoreText.text = "HISCORE: " + hiscore;
        livesText.text = "LIVES: " + lives;
        waveText.text = "WAVE: " + wave;*/

        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {

        DestroyExistingAsteroids();

        // Decide how many asteroids to spawn
        // If any asteroids left over from previous game, subtract them
        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < 100; i++)
        {

            // Spawn an asteroid
            Instantiate(asteroid,
                new Vector3(Random.Range(camera.position.x - 50.0f, camera.position.x + 50.0f),
                    Random.Range( camera.position.y -50.0f, camera.position.y + 50.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        }

        //for (int i = 0; i < 9; i++)
        //{

            // Spawn an asteroid
            /*GameObject[] Lives = GameObject.FindGameObjectsWithTag("LivesPickup");
            GameObject u = Instantiate(pickups,
                new Vector3(Random.Range(camera.position.x - 50.0f, camera.position.x + 50.0f),
                        Random.Range( camera.position.y -50.0f, camera.position.y + 50.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
            if (Lives != null)
            {
                foreach (GameObject Live in Lives)
                {
                    if (Physics.CheckSphere(Live.transform.position, 12f))
                    {
                        Destroy(u);
                        i--;
                    }
                }
            }*/
            /*Instantiate(pickups,
                new Vector3(Random.Range(camera.position.x - 50.0f, camera.position.x + 50.0f),
                    Random.Range( camera.position.y -50.0f, camera.position.y + 50.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));*/

        //}
        spawnEnemies(9,1);
        spawnEnemies(5,2);
        

        //waveText.text = "WAVE: " + wave;
    }

    public void spawnEnemies(int number, int type)
    {
        GameObject R;
        if (type == 1)
        {
            R = pickups;
        }
        else
        {
            R = enemies;
        }
        for (int i = 0; i < number; i++)
        {
            int t = Random.Range(1,3);
            int f = Random.Range(1,3);
            float RandomX = 0.0f;
            float RandomY = 0.0f;
            {
                if (t == 1)
                {
                    RandomX = Random.Range(camera.position.x, camera.position.x + 50.0f);
                }
                else 
                {
                    RandomX = Random.Range(camera.position.x , camera.position.x - 50.0f);
                }
                if (f == 1)
                {
                    RandomY = Random.Range(camera.position.y , camera.position.y + 50.0f);
                }
                else 
                {
                    RandomY = Random.Range(camera.position.y , camera.position.y - 50.0f);
                }

            }
            Instantiate(R,
                new Vector3(RandomX,
                    RandomY, 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
    
        }
    }

    
    public void IncrementScore()
    {
        score++;

        //scoreText.text = "SCORE:" + score;

       /*if (score > hiscore)
        {
            hiscore = score;
            hiscoreText.text = "HISCORE: " + hiscore;

            // Save the new hiscore
            PlayerPrefs.SetInt("hiscore", hiscore);
        }*/

        // Has player destroyed all asteroids?
    }

    public void DecrementLives()
    {
        //lives--;
        //livesText.text = "LIVES: " + lives;

        // Has player run out of lives?
        if (lives < 1)
        {
            // Restart the game
            BeginGame();
        }
    }

    public void DecrementAsteroids()
    {
        asteroidsRemaining--;
    }

    public void SplitAsteroid()
    {
        // Two extra asteroids
        // - big one
        // + 3 little ones
        // = 2
        asteroidsRemaining += 2;

    }

    void DestroyExistingAsteroids()
    {
        GameObject[] asteroids =
            GameObject.FindGameObjectsWithTag("Large Asteroid");

        foreach (GameObject current in asteroids)
        {
            GameObject.Destroy(current);
        }

        GameObject[] asteroids2 =
            GameObject.FindGameObjectsWithTag("Small Asteroid");

        foreach (GameObject current in asteroids2)
        {
            GameObject.Destroy(current);
        }
    }

}