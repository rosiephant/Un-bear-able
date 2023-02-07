using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

	private int stones = 0;
	private int wood = 0;

	[SerializeField] private Text stonesText;
	[SerializeField] private Text woodText;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Stone"))
		{
			Destroy(collision.gameObject);
			stones++;
			stonesText.text = "Stones: " + stones;
		}

		if (collision.gameObject.CompareTag("Wood"))
		{
			Destroy(collision.gameObject);
			wood++;
			woodText.text = "Wood: " + wood;
		}
	}
}
