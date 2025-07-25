﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;


    public GameObject weapon;

    float count = 0;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        this.followMouse();
    }

    private void followMouse()
    {
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
            );
        direction.Normalize();

        if (direction.x < 0)
        {
            this.spriteRenderer.flipX = true;
        }
        else
        {
            this.spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("xyz: " + other.collider.tag + " - " + ParametersScript.healValue);
        switch (other.collider.tag)
        {
            case TAG.ENEMY:
                ParametersScript.healValue -= 100;
                GetComponent<ReceiveDame>().FlashOnDamage();
                break;
            case TAG.ENEMY_BULLET:
                ParametersScript.healValue -= 200;
                GetComponent<ReceiveDame>().FlashOnDamage();
                break;
            default:
                break;

        }
        if (ParametersScript.healValue <= 0)
        {
            LevelController.Instance.startGame();
            ParametersScript.healValue = 1000; ;
            ParametersScript.scoreValue = 0;
            ParametersScript.point = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        count += Time.deltaTime;
        if (count > 1)
        {
            switch (other.collider.tag)
            {
                case TAG.ENEMY:
                    ParametersScript.healValue -= 50;
                    break;
                case TAG.ENEMY_BULLET:
                    ParametersScript.healValue -= 100;
                    break;
                default:
                    break;

            }
            count = 0;
        }
        if (ParametersScript.healValue <= 0)
        {
            int score = PlayerPrefs.GetInt("score", 0);
            int heal = PlayerPrefs.GetInt("heal", 1000);

            LevelController.Instance.startGame();
            ParametersScript.healValue = heal;
            ParametersScript.scoreValue = score;
            ParametersScript.point = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            ParametersScript.scoreValue += 1; // Increase score by 1
            ParametersScript.point += 1;
            if (UICoinDisplay.Instance != null)
                UICoinDisplay.Instance.AddCoin(1);
            else
                Debug.LogWarning("CoinManager is missing in the scene!");
            Destroy(other.gameObject);        // Remove coin from scene
        }
    }
}
