using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {
    
    public Text healthText;

    [SerializeField]
    Health health;

	void Update () {
        healthText.text = "Health: " + health.currentHealth.ToString("0");
	}
}
