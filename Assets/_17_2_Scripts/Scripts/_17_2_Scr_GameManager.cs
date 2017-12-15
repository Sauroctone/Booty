using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _17_2_Scr_GameManager : MonoBehaviour {

	public GameStates state;
	public List<Transform> booty = new List<Transform>();
	public Slider slider;
	public float timer;
	Coroutine timerInst;

	public Animator loseAnim;
	public Animator winAnim;
	public GameObject tooSlowText;
	public GameObject lossText;
	public GameObject winText;
	public GameObject loseScreen;
	public GameObject winScreen;

	public AudioSource source;
	public AudioClip tooSlow;
	public AudioClip win;

	void Start()
	{
		state = GameStates.Ticking;
		timerInst = StartCoroutine (Timer());
		source = GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (state == GameStates.Ticking)
			slider.value -= Time.deltaTime / timer;
	}

	public void Win()
	{
		StopCoroutine (timerInst);
		winAnim.SetTrigger("wins");
		StartCoroutine (WinFeedback ());
		state = GameStates.Win;
	}

	public void Lose()
	{
		loseAnim.SetTrigger ("loses");
		StartCoroutine (LossFeedback ());
	}

	IEnumerator WinFeedback()
	{
		source.Stop ();
		source.PlayOneShot (win);
		RectTransform rect = winScreen.GetComponent<RectTransform> ();
		while (rect.anchoredPosition.y != 0)
			yield return null;
		winText.SetActive (true);

//		yield return new WaitForSeconds (4);
//		GetComponent<Transition> ().Win ();
	}

	IEnumerator LossFeedback()
	{
		RectTransform rect = loseScreen.GetComponent<RectTransform> ();
		while (rect.anchoredPosition.y != 0)
			yield return null;

		if (state == GameStates.Ticking) 
		{
			state = GameStates.Loss;
			StopCoroutine (timerInst);
			lossText.SetActive (true);
		}

		else 
		{
			tooSlowText.SetActive (true);
		}

	//	yield return new WaitForSeconds (4);
	//	GetComponent<Transition> ().Lose ();
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds (timer);
		state = GameStates.Loss;
		Lose ();
		source.Stop ();
		source.PlayOneShot (tooSlow);
	}
}
