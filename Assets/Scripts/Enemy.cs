using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 12.5f;
    public float startHealth = 115f;
    public int startWorth = 12;
    public bool laserSlow = false;
    public bool coldSlow = false;
    public float cSlowPercent = .5f;
    public float lSlowPercent = .3f;
    public float totalCurrentSlowPercent = 0f;
    public float slowLength = 5f;
    public float slowLengthLeft;
    //[HideInInspector]
    public float speed;

    public float health;
    public int worth;
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed + (PlayerStats.Rounds / 10.0f);
        if (speed > 25f)
            speed = 25f;
        health = (startHealth + (PlayerStats.Rounds * 10f)) * (1 + (PlayerStats.Rounds - 1) / 15f);
        worth = startWorth + (int)((PlayerStats.Rounds - 1) * 1.02);
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Slow(int slow)//pcnt is between 0f-1f
    {
        if (slow == 0)
        {
            laserSlow = true;
            if (coldSlow)
                totalCurrentSlowPercent = cSlowPercent + lSlowPercent;
            else
                totalCurrentSlowPercent = lSlowPercent;
        }
        if (slow == 1)
        {
            if (!coldSlow)
                totalCurrentSlowPercent += cSlowPercent;
            coldSlow = true;
            slowLengthLeft = slowLength;
        }
        speed = startSpeed * (1 - totalCurrentSlowPercent);

    }
    void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}