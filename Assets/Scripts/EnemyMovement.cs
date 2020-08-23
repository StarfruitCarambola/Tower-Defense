using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Wavepoints.points[0];
        //sets target to the first wavepoint
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime);
        //dir.normalized normalizes the speed
        //Time.deltaTime makes sure the speed isn't dependent on the frame rate and the speed is the same on every computer

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWavePoint();
            //if the object is near the wavepoint, then it gets the next wavepoint
        }
        enemy.laserSlow = false;
        if (!enemy.coldSlow)
        {
            enemy.totalCurrentSlowPercent = 0f;
        }
        else
        {
            enemy.slowLengthLeft -= Time.deltaTime;
            if (enemy.slowLengthLeft <= 0)
            {
                enemy.coldSlow = false;
                enemy.totalCurrentSlowPercent =0f;
            }
            else
            {
                enemy.totalCurrentSlowPercent = enemy.cSlowPercent;
            }
        }
        enemy.speed = enemy.startSpeed * (1 - enemy.totalCurrentSlowPercent);
    }

    void GetNextWavePoint()
    {
        if (wavepointIndex >= Wavepoints.points.Length - 1)
        {
            EndPath();
            // when the enemy reaches the end, it gets destroyed
            return;
        }

        wavepointIndex++;
        target = Wavepoints.points[wavepointIndex];
        //sets a new target wavepoint
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);

    }
}
