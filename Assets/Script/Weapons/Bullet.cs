﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private float damage = 2f;
    private Rigidbody2D rb;
    public float velocity = 2f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = velocity * (this.transform.rotation * Vector3.up);
    } 

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public float GetDamage()
    {
        return this.damage;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        switch (tag)
        {
            case TAG.ENEMY:
            case TAG.WALL:
            case TAG.GATE_END:
            case TAG.GATE_START:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
