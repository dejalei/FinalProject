﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public GameController gameController;
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        if (gameController.score >= 150)
        {
            scrollSpeed = -50;
        }
    }
}