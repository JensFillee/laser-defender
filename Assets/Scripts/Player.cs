using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Vector2 rawInput;

    // bottom-left of screen
    // = worldpoint-equivelent of viewport: (0, 0)
    Vector2 minBounds;
    // top-right of screen
    // = worldpoint-equivelent of viewport: (1, 1)
    Vector2 maxBounds;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    // Init = Initialise
    void InitBounds()
    {
        Camera mainCamera = Camera.main; // refers to camera tagged with "MainCamera"
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        // Time.deltaTime = time that last frame took to render => make frame-rate independant (100FPS * 0.01sec = 1)
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;

        Vector2 newPos = new Vector2();
        //Mathf.Clamp(value, min, max): will restrict value between min and max (=> value = never lower or higher)
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
