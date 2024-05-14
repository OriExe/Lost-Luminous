using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FirstBoss : MonoBehaviour
{
    private bool TriggeredEvent = false; //When death event is triggered
    private Transform Player; 
    [SerializeField] private float speed = 0.009f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private EnemyHit healthCode;

    /// <summary>
    /// Attack Phases
    /// </summary>
    private float[] phases = new float[4];
    private float lengthOfAttack = 2f;
    private int currentPhase = 0;
    private float startingHealth;

    //Player in range
    [SerializeField] private float attackDelay = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        startingHealth = healthCode.getHealth();
        phases[0] = speed;
        phases[1] = speed*2;
        phases[2] = phases[1]*2;
        phases[3] = phases[2]*2.2f;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(dashAttack());
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if boss is dead otherwise it keeps moving
        if (healthCode.isDead == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed);
        }
        else
        {
            if (!TriggeredEvent)
            {
                TriggeredEvent = true;
                //Triggers an event
                Destroy(gameObject);
            }

        }

        

        if (speed == phases[3])
        {
            lengthOfAttack -= Time.deltaTime;
        }
        if (lengthOfAttack <=0)
        {
            speed = phases[currentPhase];
            lengthOfAttack = 2f;
            StartCoroutine(dashAttack());
        }

        float currentHealth = healthCode.getHealth();
        //Get health
        if (currentHealth <= startingHealth * 0.66 && currentHealth >= startingHealth * 0.33)
        {
            currentPhase = 1;
            if (speed != phases[3])
                speed = phases[currentPhase];
        }
        else if (currentHealth <= startingHealth * 0.33)
        {
            currentPhase = 2;
            if (speed != phases[3])
                speed = phases[currentPhase];
        }

    }

    /// <summary>
    /// Activates dash attack if certain number achieved 
    /// </summary>
    IEnumerator dashAttack()
    {
        int random = 0;
        while (random != 4)
        {
            random = Random.Range(1, 12);
            yield return new WaitForSeconds(0.5f);
        }
        speed = phases[3];
        lengthOfAttack = 2f;
        yield return null;
        
    }

    IEnumerator takeDamage()
    {
        yield return new WaitForSeconds(attackDelay);
        PlayerHealth.healthInstance.healthChange(-damage);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(takeDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopCoroutine(takeDamage());
        }
    }
}
