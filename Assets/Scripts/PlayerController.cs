using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [Header ("The 2D Rigidbody component applied to the player")]
    Rigidbody2D playerRB;

    [Header ("The Transform component of the player")]
    Transform playerTF;

    [Header ("The 2D Collider component of the player")]
    BoxCollider2D playerCol;

    [Header ("The Animator component of the player")]
    Animator playerAn;

    [Header ("The collider object of the tilemap in the area (must be set manually)")]
    public TilemapCollider2D tilemapCol;


    [Space(20)]
    [Header("The force of the player's jump")]
    public float jumpForce;

    [Header ("The speed of the player's movement")]
    public float moveSpeed;

    [Space(20)]
    [Header ("The empty GameObject that is in the position of the player's spawn")]
    public Transform spawnpoint;

    void Awake() {
        // Hides the mouse cursor
        Cursor.visible = false;

        // Sets the variables to the actual components of the player before the first frame is drawn
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerTF = gameObject.GetComponent<Transform>();
        playerCol = gameObject.GetComponent<BoxCollider2D>();
        playerAn = gameObject.GetComponent<Animator>();
    }

    void Update() {
        if(Input.GetAxisRaw("Horizontal") > 0) {
            playerAn.SetBool("facingRight", true);
        }
        if(Input.GetAxisRaw("Horizontal") < 0) {
            playerAn.SetBool("facingRight", false);
        }
        
        // In the frame the player presses a jump button, if the player is on solid ground, add an impulse force (the jumpForce variable) to the 2D Rigidbody.
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && playerCol.IsTouching(tilemapCol)) {
            playerRB.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }

        // Basic movement control
        playerTF.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0.0f, 0.0f));

        
    }

    // If this method is called, set the player's position to that of the spawnpoint
    void respawn() {
        transform.position = spawnpoint.position;
    }
}
