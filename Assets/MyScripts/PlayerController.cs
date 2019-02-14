﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb2d;

	public float speed;

	private int count;

	public Text countText;
	public Text WinText;

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb2d.AddForce(movement * speed);

		if (Input.GetKey("escape"))
			Application.Quit();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		count = 0;
		SetCountText();
		WinText.text = "";
	}
		
	void Update()
	{
		
	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString();
		if (count >=12 )
			WinText.text = "You Win";
	}
}
