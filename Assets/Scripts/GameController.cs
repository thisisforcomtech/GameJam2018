using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject pickups;
    public GameObject enemies;
    public Text MissingCounter;
    public Text RescueCounter;
    public Text LossCounter;
    private int score = 0;
    private int total = 0;
    private int lost = 0;

    private int hiscore;
    private int asteroidsRemaining;
    private int lives;
    private int wave;
    private int increaseEachWave = 4;
    private bool SceneMove = true;


    public Transform camera;

    // Use this for initialization
    void Start()
    {
        hiscore = PlayerPrefs.GetInt("hiscore", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        int missing = total - score - lost;
        // Quit if player presses escape
        MissingCounter.text = "Missing " + missing;
        RescueCounter.text = "Rescued " + score;
        LossCounter.text = "Lost " + lost;

        // Quit if player presses escape
        if (Input.GetKey("escape"))
            Application.Quit();

    }
    public void BeginGame()
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
        GameObject[] x = GameObject.FindGameObjectsWithTag("LivesPickup");
        foreach (GameObject y in x)
        {
            total++;
        }
    }

    void SpawnAsteroids()
    {


        // Decide how many asteroids to spawn
        // If any asteroids left over from previous game, subtract them
        asteroidsRemaining = (wave * increaseEachWave);

        for (int i = 0; i < 100; i++)
        {

            // Spawn an asteroid
            Instantiate(asteroid,
                new Vector3(Random.Range( -50.0f,  50.0f),
                    Random.Range( -50.0f, 50.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        }
        for (int i = 0; i < 9; i++)
        {

            // Spawn an asteroid
            Instantiate(pickups,
                new Vector3(Random.Range(-50.0f, 50.0f),
                    Random.Range(-30.0f, 50.0f), 0),
                Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));

        }
        for (int i = 0; i < 5; i++)
        {

            // Spawn an asteroid
            Instantiate(enemies,
                new Vector3(Random.Range(-50.0f, 50.0f),
                    Random.Range(-10.0f, 50.0f), 0),
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

        

        //waveText.text = "WAVE: " + wave;
    }

    public void spawnEnemies(int number, int type)
    {
       
    
        
    }


    public void IncrementScore(int score)
    {
        this.score = this.score + score;
        if (this.score > 8)
        {
            SceneManager.LoadScene("Victory");
        }
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
        lost++;
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

    public void NextScene()
    {

            SceneManager.LoadScene("GameOver");

    }

}