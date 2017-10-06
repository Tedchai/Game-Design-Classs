using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //access texts and images

public class HealthSystem : MonoBehaviour {

	public Image fullHearts;
	public Image twoHearts;
	public Image oneHearts;
	public Image emptyHearts;

	public Image heartsUI;

	private PlayerControlScript player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControlScript> ();
		}
	
	// Update is called once per frame
	void Update () {
	
		if (player.curHealth == 3)
		{
			heartsUI.sprite = fullHearts;
				}
		if (player.curHealth == 2)
		{
			heartsUI.sprite = twoHearts;
			}
		if (player.curHealth == 1)
		{
			heartsUI.sprite = oneHearts;

		}
		if (player.curHealth == 0)
		{
			heartsUI.sprite = emptyHearts;

		}
}
