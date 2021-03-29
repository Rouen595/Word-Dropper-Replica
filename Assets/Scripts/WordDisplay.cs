using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {

	public Text text;
	private float fallSpeed = 0.5f * ChangeSpeed.gameSpeed;
	public float delay = 20.5f;

	public Rigidbody2D rb;

	public void SetWord (string word)
	{
		text.text = word;
	}

	public void RemoveLetter ()
	{
		text.text = text.text.Remove(0, 1);
		text.color = Color.red;
	}

	public void RemoveWord ()
	{
		Destroy(gameObject);
	}

	private void FixedUpdate()
	{
		Vector2 forward = new Vector2(transform.up.x, transform.up.y);
		rb.MovePosition(rb.position - forward * Time.fixedDeltaTime * fallSpeed);

		/*
		//transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
		rb.MovePosition(rb.position + fallSpeed * Time.deltaTime);
		*/

		Invoke("RemoveWord", 12.0f);
	}

}
