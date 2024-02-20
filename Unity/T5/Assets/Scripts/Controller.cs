using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
	
	[SerializeField] private TMP_Text text0;
	[SerializeField] private TMP_Text text1;
	
	[SerializeField] private Image img0;
	[SerializeField] private Image img1;

	[SerializeField] private Button button;
	[SerializeField] private TMP_Text buttonText;
	
	
	private bool _corId = true;
	private int _timer;

	private Color color0
	{
		set => img0.color = value;
	}
	private Color color1 
	{
		set => img1.color = value;
	}
	private void Start()
	{
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(Play);
	}
	public void Play()
	{
	
		buttonText.text = "Стоп";
		_timer = Random.Range(10, 20);
		if (_corId)
		{
			color0 = Color.green;
			color1 = Color.red;
			text0.text = _timer.ToString();
		}
		else
		{
			color1 = Color.green;
			color0 = Color.red;
			text1.text = _timer.ToString();
		}
		StartCoroutine(Wait0());
		StartCoroutine(Wait1());
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(Stop);
	}

	public void Stop()
	{
		StopAllCoroutines();
		buttonText.text = "Старт";
		color0 = Color.yellow;
		color1 = Color.yellow;
		text0.text = "0";
		text1.text = "0";
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(Play);
	}

	IEnumerator Wait0()
	{
		while (true)
		{

			if (_corId)
			{
				yield return new WaitForSeconds(1);
				_timer--;
				text0.text = _timer.ToString();
				if (_timer <= 0)
				{
					_corId = false;
					color0 = Color.red;
					text0.text = "0";
					color1 = Color.green;
					_timer = Random.Range(10, 20);
					text1.text = _timer.ToString();
				}

			}
			else yield return null;
		}
	}

	IEnumerator Wait1()
	{
		while (true)
		{
			if (!_corId)
			{
				yield return new WaitForSeconds(1);
				_timer--;
				text1.text = _timer.ToString();
				if (_timer <= 0)
				{
					_corId = true;
					color1 = Color.red;
					text1.text = "0";
					color0 = Color.green;
					_timer = Random.Range(10, 20);
					text0.text = _timer.ToString();
				}
			}
			else yield return null;
		}
	}
}
