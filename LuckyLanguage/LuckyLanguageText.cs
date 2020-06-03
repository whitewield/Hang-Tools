using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Hang {
	namespace LuckyLanguage {
		public class LuckyLanguageText : MonoBehaviour {

			[SerializeField] Text myText;
			[SerializeField] string myCategory;
			[SerializeField] string myTitle;
			[SerializeField] bool isAllCaps;

			// Use this for initialization
			void Awake () {
				if (myText == null)
					myText = this.GetComponentInChildren<Text> ();
			}

			void Start () {
				SetText ();
			}

			public void SetText () {
				if (myCategory == "")
					return;

				if (myTitle == "")
					return;

				SetText (LuckyLanguageManager.Instance.LoadCaption (myCategory, myTitle));
			}

			public void SetColor (Color g_color) {
				myText.color = g_color;
			}

			public void SetText (string g_text) {
				if (isAllCaps)
					myText.text = g_text.ToUpper ();
				else
					myText.text = g_text;
			}

			public void SetCategory (string g_title) {
				myCategory = g_title;
			}

			public void SetTitle (string g_title) {
				myTitle = g_title;
				SetText ();
			}

		}
	}
}