using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public WeaponSwitcher weaponSwitcher;

    PlayerInput input;
    InputAction meleeAction;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        input = GetComponent<PlayerInput>();
        meleeAction = input.actions["Melee"];
    }

    private void Update()
    {
        if (meleeAction.WasPressedThisFrame())
        {
            animator.SetTrigger("meleeAttack");
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }
                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            // Flip sprite based on movement direction
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }       
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
                
        }
    }

    bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            return false;
        }
        return false;
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    public void SwordAttack()
    {
        weaponSwitcher.currentWeapon.SetActive(false);
        LockMovement();
        if (spriteRenderer.flipX == true) swordAttack.AttackLeft();
        else swordAttack.AttackRight();
    }

    public void StopSwordAttack()
    {
        weaponSwitcher.currentWeapon.SetActive(true);
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
