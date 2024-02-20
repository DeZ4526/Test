using UnityEngine;
namespace T1.Controllers.Map
{
	public class MapCreator : MonoBehaviour
	{
		[SerializeField] private Cell cellPrefab;
		[SerializeField] private int width = 10;
		[SerializeField] private int height = 10;
		[SerializeField] private bool isCreateOnAwake;

		private void Awake()
		{
			if (isCreateOnAwake) Create();
		}

		public void Create()
		{
			if (cellPrefab == null) return;
			bool colorId = false;
			int widthCenter = width / 2;
			int heightCenter = height / 2;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					var cell = Instantiate(cellPrefab, new Vector3(i, 0, j), Quaternion.identity);
					cell.SetObj(
						colorId ?
							i < 2 ? CellType.Black : (
							i > width - 3 ? CellType.White :
							CellType.None) :
						CellType.None);

					if (i == widthCenter && j == heightCenter && CameraController.HasReference)
					{
						CameraController.Instance.SetCenter(cell.transform);
					}


					cell.GetComponent<Renderer>().material.color =
					colorId ? Color.black : Color.white;
					colorId = !colorId;
				}
				if (height % 2 == 0)
				{
					colorId = !colorId;
				}
			}
		}
	}
}