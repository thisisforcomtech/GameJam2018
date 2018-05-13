using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    GameObject P;
    ShipController Player;
    bool IsAttacking = false;
    Vector3 Distance;
    float DistanceFrom;
    float minAimDis;
    float minAtkDis;
    float fireRate = 3f;
    float nextFire = 3f;
    float aggro;
    float wanderTime = 300;
    float turnTime = 120;
    public float speed;
    public float interval;
    Vector3 position;

    public GameObject enemyBullet;
    public GameObject boomBleedR;

    // Use this for initialization
    void Start () {
		P = GameObject.FindWithTag("Player");
        Player = P.GetComponent<ShipController>();
        IsAttacking = false;
        aggro = 0;
        minAimDis = 5;
        minAtkDis = 3;
        aggro = 0;
        InvokeRepeating("flip", interval,interval);
        position = transform.forward*-100;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the player  the enemy

        Distance = (transform.position - Player.transform.position);
        Distance.y = 0;
        DistanceFrom = Distance.magnitude;
        Distance /= DistanceFrom;

        // If the player is 10m away from the enemy, ATTACK!

        if (aggro > 0)
        {
            minAimDis = 10;
            minAtkDis = 6;
            if (tag.Equals("EnemyShip1"))
            {
                speed = 0.75f;
            }
            if (tag.Equals("EnemyShip2"))
            {
                speed = 1f;
            }
            aggro--;
        }
        else if (aggro <= 0)
        {
            minAimDis = 5;
            minAtkDis = 3;
        }

        if (DistanceFrom < minAimDis)
        {
            IsAttacking = true;
            Attacking();
        }
        else
        {
            IsAttacking = false;
            GetComponent<Rigidbody>()
             .AddForce(transform.up * -speed);

            //Vector3 turnRot = position - this.transform.position;
            //Quaternion finalRot = Quaternion.LookRotation(turnRot);
            //float x = this.transform.position.x -position.x;
            //float y = this.transform.position.y - position.y;
            //float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            //Quaternion finalRot = Quaternion.Euler(0, 0, (angle - 90));
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, finalRot, Time.deltaTime * 100f);
            

        }
    }
    void flip()
    {

        speed = speed*-1;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sonar")
        {
            aggro = 600;
        }
    }

        void Attacking()
    {
        if (IsAttacking)
        {
            // The enemy isn't blind so it should face the player
            Vector3 turnRot = Player.transform.position - this.transform.position;
            //Quaternion finalRot = Quaternion.LookRotation(turnRot);
            float x = this.transform.position.x - Player.transform.position.x;
            float y = this.transform.position.y - Player.transform.position.y;
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            Quaternion finalRot = Quaternion.Euler(0, 0, (angle - 90));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, finalRot, Time.deltaTime * 30f);

            if (tag.Equals("EnemyShip2"))
            {
                GetComponent<Rigidbody>().AddForce(transform.up * -1f);
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(transform.up * -0.75f);
            }

            //Shoot
            if (DistanceFrom < minAtkDis)
            {
                if (Time.time > nextFire && !tag.Equals("EnemyShip2"))
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(enemyBullet,
                        new Vector3(transform.position.x, transform.position.y, 0),
                        transform.rotation);
                }
            }
        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (tag.Equals("EnemyShip2"))
        {
            if (c.gameObject.tag == "EnemyShip2" || c.gameObject.tag == "Enemy")
            {
		Instantiate(boomBleedR,
                        new Vector3(transform.position.x, transform.position.y, 0),
                        transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
            void spinBehind()
	{
	}
}
