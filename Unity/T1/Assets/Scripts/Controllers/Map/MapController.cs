using T1.Controllers.Map;
using UnityEngine;

namespace T1.Controllers.Map
{
	public class MapController : SingletonMono<MapController>
	{
		private Cell _selectedCell;

		public void SelectCell(Cell cell)
		{
			if (_selectedCell == null && cell.CellType == CellType.None) return;
			if (_selectedCell == null && cell.CellType != CellType.None)
			{
				_selectedCell = cell;
			}
			else
			{
				if (cell.CellType == CellType.None && _selectedCell.CellType != CellType.None)
				{
					cell.SetObj(_selectedCell.CellType);
					_selectedCell.SetObj(CellType.None);
					_selectedCell = null;
				}
			}
		}
	}
}