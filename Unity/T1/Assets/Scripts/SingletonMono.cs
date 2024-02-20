using UnityEditor;
using UnityEngine;

namespace T1
{
	public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
	{
		[SerializeField] protected bool isDontDestroy;

		protected static T Reference;

		/// <summary>
		/// The singleton instance of a reference.
		/// </summary>
		public static T Instance
		{
			get
			{
				if (Reference == null)
				{
					if (!(Reference = FindObjectOfType<T>()))
					{
						throw new MissingReferenceException($"The singleton reference to a {typeof(T).Name} does not found!");
					}
				}

				return Reference;
			}
		}

		public static bool HasReference
		{
			get
			{
				if (Reference == null)
				{
					return (Reference = FindObjectOfType<T>()) != null;
				}

				return true;
			}
		}

		protected void Awake()
		{
			if (isDontDestroy)
			{
				DontDestroyOnLoad(Instance);
			}
		}

		protected virtual void Reset()
		{
#if UNITY_EDITOR
			if (FindObjectsOfType<T>().Length > 1)
			{
				EditorUtility.DisplayDialog("Singleton Error", $"There should never be more than 1 reference of {typeof(T).Name}!", "OK");
				DestroyImmediate(this);
			}
#endif
		}
	}
}