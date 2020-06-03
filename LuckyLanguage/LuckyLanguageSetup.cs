using UnityEngine;
using System.Collections;

namespace Hang {
	namespace LuckyLanguage {
		public enum Language {
			EN = 0,
			CHS = 1,
			CHT = 2,
		}

		[CreateAssetMenu (fileName = "LanguageSetup", menuName = "Hang/LanguageSetup", order = 1)]
		public class LuckyLanguageSetup : ScriptableObject {
			public Language myLanguage;
			public Font myFont;
		}
	}
}