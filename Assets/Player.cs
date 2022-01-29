using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Vector2 rawInput;

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Time.deltaTime = time that last frame took to render => make frame-rate independant (100FPS * 0.01sec = 1)
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
