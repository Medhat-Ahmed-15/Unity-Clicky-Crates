using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnpos = -2;

    private GameManager gameManager;
 
    public ParticleSystem explosionParticle;
    public int pointValue;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

      gameManager= GameObject.Find("Game_Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void OnMouseEnter()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            explosionParticle.Play();
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (gameObject.CompareTag("Good1")|| gameObject.CompareTag("Good2")|| gameObject.CompareTag("Good3"))
        {
            gameManager.GameOver();
         
        }

       /* if (!gameObject.CompareTag("Bad1"))
        {
            gameManager.GameOver();
        }*///el if dee haya haya bzbt el if el fo2 bs taree2 mo5talfa 3ashan a show el gameover text
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnpos, 0);
    }
}
