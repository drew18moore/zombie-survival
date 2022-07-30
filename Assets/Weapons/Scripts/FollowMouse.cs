using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    SpriteRenderer weaponSprite;
    Vector2 mousePos;
    Vector2 lookDir;
    float angle;

    private void Start()
    {
        weaponSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        lookDir = mousePos - (Vector2)transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        /*
        if (mousePos.x < transform.position.x)
        {
            weaponSprite.flipY = true;
        }
        else
        {
            weaponSprite.flipY = false;
        }
        */
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
