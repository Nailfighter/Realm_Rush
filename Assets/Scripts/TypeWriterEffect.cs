using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour {

    public GameObject wave_display;
	public float delay = 0.1f;
	private string currentText = "";
    string random_wish;
    bool is_typing;
	[SerializeField] float wish_time;
    bool is_couritne;
	// Use this for initialization
	public void type_message_box (string full_text)
	{
		StartCoroutine(ShowText(full_text));
	}
    private void Start()
    {
        is_couritne = false;
		StartCoroutine(Wave_Info());
    }

    IEnumerator ShowText(string full_Text)
	{
        if (!is_typing)
        {
            StopCoroutine(Wave_Info());
            is_typing = true;
            for (int i = 0; i <= full_Text.Length; i++)
            {
                currentText = full_Text.Substring(0, i);
                gameObject.GetComponentInChildren<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            is_typing = false;

        }


    }

   public  IEnumerator Wave_Info()
    {
        random_wish = "Wave-" + FindObjectOfType<Wave_Setter>().count;
		for (int i = 0; i <= random_wish.Length; i++)
		{
			currentText =random_wish.Substring(0, i);
			wave_display.GetComponentInChildren<Text>().text = currentText;
			yield return new WaitForSeconds(delay*5);
		}

    }
}
