﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollectionMovement : MonoBehaviour
{
    public float speed = 5f;
    public float deltaY;

    public float fade = 2f;

    public float fadeDelay = 1;
    public float fadeDelayCounter;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        fadeDelayCounter = fadeDelay;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float delta = speed * Time.deltaTime;
        deltaY += delta;

        Vector3 pos = transform.position;
        pos.y = Mathf.Max(_player.transform.position.y + deltaY, pos.y + delta);
        transform.position = pos;

        fadeDelayCounter -= Time.deltaTime;

        if (fadeDelayCounter < 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer)
            {
                Color color = spriteRenderer.color;
                color.a *= (1 - (fade * Time.deltaTime));
                spriteRenderer.color = color;
            }
        }
    }
}