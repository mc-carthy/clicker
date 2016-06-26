using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum ItemType { ClickPower, PerSecondIncrease };

public class StoreItem : MonoBehaviour {

	[Tooltip("How much will this upgrade cost?")]
	public int cost;

	public ItemType itemType;

	[Tooltip("If purchased, how much will it increase this?")]
	public float increaseAmount;

	private int qty;

	public Text costText;
	public Text qtyText;

	private GameController controller;
	private Button button;

	void Start() {
		qty = 0;
		qtyText.text = qty.ToString ();
		costText.text = "$" + cost.ToString ();

		button = transform.GetComponent<Button> ();
		controller = GameObject.FindObjectOfType<GameController> ();

		// Execute the ButtonClicked function when we click the button
		button.onClick.AddListener(this.ButtonClicked);
	}

	void Update() {
		button.interactable = (controller.Cash >= cost);
	}

	public void ButtonClicked() {
		controller.Cash -= cost;
		switch (itemType) {
		case ItemType.ClickPower:
			controller.cashPerClick += increaseAmount;
			break;
		case ItemType.PerSecondIncrease:
			controller.CashPerSecond += increaseAmount;
			break;
		}
		qty++;
		qtyText.text = qty.ToString ();
	}

}
