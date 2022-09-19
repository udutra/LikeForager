using UnityEditor;
using UnityEngine;

namespace Baedrick.ColoredHeaderCreator
{
	public class ColoredHeaderObject : MonoBehaviour
	{

#if UNITY_EDITOR
		public HeaderSettings headerSettings = new();

		// If values change when in Edit Mode
		void OnValidate()
		{
			EditorApplication.RepaintHierarchyWindow();

			gameObject.tag = headerSettings.editorOnly ? "EditorOnly" : "Untagged";
		}
#endif // UNITY_EDITOR

	} // class ColoredHeaderObject

} // namespace