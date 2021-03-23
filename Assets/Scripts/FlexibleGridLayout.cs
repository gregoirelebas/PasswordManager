using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Toolbox
{
	public class FlexibleGridLayout : LayoutGroup
	{
		public enum FitType
		{
			Uniform,
			Width,
			Height,
			FixedRows,
			FixedColumns
		}

		[SerializeField] private FitType fitType = FitType.Uniform;
		[SerializeField] private int rows = 1;
		[SerializeField] private int columns = 1;
		[SerializeField] private Vector2 spacing = Vector2.zero;
		[SerializeField] private bool fitX = false;
		[SerializeField] private bool fitY = false;

		private Vector2 cellSize = Vector2.one;

		public override void CalculateLayoutInputHorizontal()
		{
			base.CalculateLayoutInputHorizontal();

			if (fitType == FitType.Uniform || fitType == FitType.Width || fitType == FitType.Height)
			{
				fitX = true;
				fitY = true;

				float sqrt = Mathf.Sqrt(transform.childCount);
				rows = Mathf.CeilToInt(sqrt);
				columns = Mathf.CeilToInt(sqrt);
			}

			if (fitType == FitType.Width || fitType == FitType.FixedColumns)
			{
				rows = Mathf.CeilToInt(transform.childCount / (float)columns);
			}

			if (fitType == FitType.Height || fitType == FitType.FixedRows)
			{
				columns = Mathf.CeilToInt(transform.childCount / (float)rows);
			}

			float parentWidth = rectTransform.rect.width;
			float parentHeight = rectTransform.rect.height;

			float cellWidth = (parentWidth / columns) - (spacing.x / columns * 2.0f) - (padding.left / columns) - (padding.right / columns);
			float cellHeight = (parentHeight / rows) - (spacing.y / rows * 2.0f) - (padding.top / rows) - (padding.bottom / rows);

			cellSize.x = fitX ? cellWidth : cellSize.x;
			cellSize.y = fitY ? cellHeight : cellSize.y;

			int rowCount;
			int columnCount;

			for (int i = 0; i < rectChildren.Count; i++)
			{
				rowCount = i / columns;
				columnCount = i % columns;

				RectTransform item = rectChildren[i];
				float xPos = (cellSize.x * columnCount) + (spacing.x * columnCount) + padding.left;
				float yPos = cellSize.y * rowCount + (spacing.y * rowCount) + padding.top;

				SetChildAlongAxis(item, 0, xPos, cellSize.x);
				SetChildAlongAxis(item, 1, yPos, cellSize.y);
			}
		}

		public override void CalculateLayoutInputVertical()
		{

		}

		public override void SetLayoutHorizontal()
		{

		}

		public override void SetLayoutVertical()
		{

		}
	}
}
