using UnityEngine;

namespace T1.Controllers.Map
{
	public class Cell : MonoBehaviour
	{
		[SerializeField] private GameObject obj;
		private Renderer _renderer;
		public CellType CellType { get; private set; }
		private MapController _mapController;

		private void Awake()
		{
			_renderer = obj.GetComponent<Renderer>();
			if (MapController.HasReference)
			{
				_mapController = MapController.Instance;
			}
		}

		private void OnMouseDown()
		{
			_mapController.SelectCell(this);
		}

		public bool SetObj(CellType cellType)
		{
			CellType = cellType;

			if (!obj.activeSelf && cellType != CellType.None)
			{
				obj.SetActive(true);
				_renderer.material.color = cellType == CellType.Black ? Color.black : Color.white;
				return true;
			}
			else if (obj.activeSelf && cellType == CellType.None)
			{
				obj.SetActive(false);
				return true;
			}
			return false;
		}

	}
	public enum CellType
	{
		None,
		Black,
		White
	}
}