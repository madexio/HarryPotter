using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSprite : MonoBehaviour {

    SpriteRenderer playerRenderer;
    Rigidbody2D rb2d;

    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite idleSprite;

	// Use this for initialization
	void Start () {
        playerRenderer = GetComponent<SpriteRenderer>();
        playerRenderer.sprite = idleSprite;

        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb2d.velocity.x > 0)
        {
            playerRenderer.sprite = rightSprite;
        } else if (rb2d.velocity.x < 0)
        {
            playerRenderer.sprite = leftSprite;
        } else
        {
            playerRenderer.sprite = idleSprite;
        }
	}
}
