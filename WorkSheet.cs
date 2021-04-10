﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;

namespace RevitToGOST
{
	public class WorkSheet
	{
		/*
		**	Member fields
		*/

		public string Name { get; set; }
		public IXLWorksheet WS { get; set; }
		private string Format;
		private string Orientation;
		private int Height;
		private int Width;
		public List<GOST> Tables { get; set; }
		public List<int[]> Columns;
		public List<int[]> Rows;

		/*
		**	Member methods
		*/

		public WorkSheet(IXLWorksheet ixlWorkSheet, string name = Constants.DefaultName)
		{
			Name = name;
			WS = ixlWorkSheet;
			Tables = new List<GOST>();
		}

		public void AddTable(GOST table)
		{
			if (Tables.Count == 0)
			{
				Tables.Add(table);
				Format = table.Format;
				Orientation = table.Orientation;
				Columns = new List<int[]>(table.Columns);
				Rows = new List<int[]>(table.Rows);
				SetPageDimensions();
			}
			else
			{
				//if (Format != table.Format || Orientation != table.Orientation)
				//	return;
				if (table.Position > 1)
				{
					XMLTools.CompleteFields(table, Height, Width);
					XMLTools.CreateNormalTable(table, Height, Width);
				}
				Tables.Add(table);
				if (table.Columns != null && table.Rows != null)
					(Columns, Rows) = XMLTools.MergeTables(Columns, Rows, table.Columns, table.Rows);
			}
		}

		private void SetPageDimensions()
		{
			if (Format == "A3" && Orientation == "Portrait")
				(Height, Width) = (Constants.A3.Height, Constants.A3.Width);
			else if (Format == "A3" && Orientation == "Landscape")
				(Height, Width) = (Constants.A3.Width, Constants.A3.Height);
			else if (Format == "A4" && Orientation == "Portrait")
				(Height, Width) = (Constants.A4.Height, Constants.A4.Width);
			else if (Format == "A4" && Orientation == "Landscape")
				(Height, Width) = (Constants.A4.Width, Constants.A4.Height);
			else if (Format == "A11" && Orientation == "Portrait")
				(Height, Width) = (Constants.A11.Height, Constants.A11.Width);
			else if (Format == "A11" && Orientation == "Landscape")
				(Height, Width) = (Constants.A11.Width, Constants.A11.Height);
		}

		public void BuildWorkSheet()
		{
			ApplyParameters();
			ReshapeWorkSheet();
			MergeCells();
			ApplyStyles();
			DrawFrame();
			FillHeader();
			FillTable();
			Kostyl();
		}

		private void ApplyParameters()
		{
			//// Page setup
			// Format
			if (Format == "A4")
				WS.PageSetup.PaperSize = XLPaperSize.A4Paper;
			else if (Format == "A3")
				WS.PageSetup.PaperSize = XLPaperSize.A3Paper;
			else
				WS.PageSetup.PaperSize = XLPaperSize.A4Paper;
			// Orientation
			if (Orientation == "Landscape")
				WS.PageSetup.PageOrientation = XLPageOrientation.Landscape;
			else if (Orientation == "Portrait")
				WS.PageSetup.PageOrientation = XLPageOrientation.Portrait;
			else
				WS.PageSetup.PageOrientation = XLPageOrientation.Default;
			// Adjust scale
			WS.PageSetup.AdjustTo(100);
			// Set dpi
			WS.PageSetup.VerticalDpi = 600;
			WS.PageSetup.HorizontalDpi = 600;

			//// Set font
			// ... to do ....
			//WS.Style.Font.FontName = "GOST A";
			//WS.Column(1).Style.Font.FontName = "GOST A";
			//WS.Column(1).Style.Font.FontSize = 7;
			//WS.Column(1).Style.Font.Italic = true;

			//// Margins setup
			WS.PageSetup.Margins.Top = 0;
			WS.PageSetup.Margins.Left = 0;
			WS.PageSetup.Margins.Right = 0;
			WS.PageSetup.Margins.Bottom = 0;
			WS.PageSetup.Margins.Footer = 0;
			WS.PageSetup.Margins.Header = 0;
			WS.PageSetup.CenterHorizontally = false;
			WS.PageSetup.CenterVertically = false;
		}

		private void ReshapeWorkSheet()
		{
			SortedSet<int> cols = XMLTools.GetSortedSet(Columns);
			SortedSet<int> rows = XMLTools.GetSortedSet(Rows);

			// Set widths
			for (int i = 0, size = cols.ElementAt(0); i < cols.Count; i++)
			{
				if (i > 0)
					size = cols.ElementAt(i) - cols.ElementAt(i - 1);
				WS.Column(i + 1).Width = XMLTools.mmToWidth(size);
			}
			// Set heights
			for (int i = 0, size = rows.ElementAt(0); i < rows.Count; i++)
			{
				if (i > 0)
					size = rows.ElementAt(i) - rows.ElementAt(i - 1);
				WS.Row(i + 1).Height = XMLTools.mmToHeight(size); // size * Constants.mm_h;
			}
		}

		private void MergeCells()
		{
			foreach (GOST table in Tables)
			{
				if (table.Fields == null)
					continue;
				foreach (List<int[]> line in table.Fields)
				{
					foreach (int[] field in line)
					{
						(int y1, int x1) = XMLTools.GetCellIndexesBySize(Rows, Columns, field[0], field[1]);
						(int y2, int x2) = XMLTools.GetCellIndexesBySize(Rows, Columns, field[2], field[3]);
						WS.Range(y1, x1, y2, x2).Merge();
						//if (table.Type != "Page")
						//	WS.Range(y1, x1, y2, x2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
						//WS.Cell(y1, x1).Style.Alignment.Vertical = (XLAlignmentVerticalValues)table.VerticalAlignment;
						//WS.Cell(y1, x1).Style.Alignment.Vertical = (XLAlignmentVerticalValues)table.HorizontalAlignment;
					}
				}
			}
			//foreach (int[] field in Fields)
			//{
			//	//Log.WriteLine("Merge: {0} {1} - {2} {3}", field[0], field[1], field[2], field[3]);
			//	(int y1, int x1) = XMLTools.GetCellIndexesBySize(Rows, Columns, field[0], field[1]);
			//	(int y2, int x2) = XMLTools.GetCellIndexesBySize(Rows, Columns, field[2], field[3]);
			//	WS.Range(y1, x1, y2, x2).Merge();
			//	WS.Range(y1, x1, y2, x2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
			//}
		}

		private void ApplyStyles()
		{
			foreach (GOST table in Tables)
			{
				if (table.Fields == null)
					continue;
				for (int i = 0; i < table.Fields.Count; ++i)
				{
					for (int j = 0; j < table.Fields[i].Count; ++j)
					{
						// Get cell coordinates
						// (int y, int x) = XMLTools.GetCellIndexesBySize(Rows, Columns, table.Fields[i][j][0], table.Fields[i][j][1]);
						(int y1, int x1) = (table.Fields[i][j][0], table.Fields[i][j][1]);
						(int y2, int x2) = (table.Fields[i][j][2], table.Fields[i][j][3]);
						(y1, x1) = XMLTools.GetCellIndexesBySize(Rows, Columns, y1, x1);
						(y2, x2) = XMLTools.GetCellIndexesBySize(Rows, Columns, y2, x2);

						// Set font
						if (table.Font != null)
							WS.Cell(y1, x1).Style.Font.FontName = table.Font;

						// Set font size
						if (table.FontSizes != null && table.FontSizes[i][j] != 0)
							WS.Cell(y1, x1).Style.Font.FontSize = table.FontSizes[i][j];
						else if (table.FontSize != 0)
							WS.Cell(y1, x1).Style.Font.FontSize = table.FontSize;

						// Set vertical alignments
						if (table.VerticalAlignments != null && 0 <= table.VerticalAlignments[i][j] && table.VerticalAlignments[i][j] <= 4)
							WS.Cell(y1, x1).Style.Alignment.Vertical = (XLAlignmentVerticalValues)table.VerticalAlignments[i][j];
						else
							WS.Cell(y1, x1).Style.Alignment.Vertical = (XLAlignmentVerticalValues)table.VerticalAlignment;

						// Set horizontal alignments
						if (table.HorizontalAlignments != null && 0 <= table.HorizontalAlignments[i][j] && table.HorizontalAlignments[i][j] <= 7)
							WS.Cell(y1, x1).Style.Alignment.Horizontal = (XLAlignmentHorizontalValues)table.HorizontalAlignments[i][j];
						else
							WS.Cell(y1, x1).Style.Alignment.Horizontal = (XLAlignmentHorizontalValues)table.HorizontalAlignment;

						// Apply word wrap
						WS.Cell(y1, x1).Style.Alignment.WrapText = true;

						// Set vertical text direction
						if (table.VerticalText == true)
							WS.Cell(y1, x1).Style.Alignment.SetTextRotation(90);

						// Draw borders
						if (table.Borders != null)
							WS.Range(y1, x1, y2, x2).Style.Border.OutsideBorder = (XLBorderStyleValues)table.Borders[i][j];
					}
				}
			}
		}

		private void DrawFrame()
		{
			if (Tables == null || Tables.First() == null || Tables.First().Frame == null)
				return;
			(int y1, int x1) = (Tables.First().Frame[0], Tables.First().Frame[1]);
			(int y2, int x2) = (Tables.First().Frame[2], Tables.First().Frame[3]);
			(y1, x1) = XMLTools.GetCellIndexesBySize(Rows, Columns, y1, x1);
			(y2, x2) = XMLTools.GetCellIndexesBySize(Rows, Columns, y2, x2);
			WS.Range(y1, x1, y2, x2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
		}

		private void FillHeader()
		{
			foreach (GOST table in Tables)
			{
				if (table.Map == null || table.Fields == null)
					continue;
				foreach (KeyValuePair<string, int[]> entry in table.Map)
				{
					if (entry.Key.First() != '_' && entry.Value.Length == 2)
					{
						(int y1, int x1) = (table.Fields[entry.Value[0]][entry.Value[1]][0], table.Fields[entry.Value[0]][entry.Value[1]][1]);
						(int y2, int x2) = (table.Fields[entry.Value[0]][entry.Value[1]][2], table.Fields[entry.Value[0]][entry.Value[1]][3]);
						(y1, x1) = XMLTools.GetCellIndexesBySize(Rows, Columns, y1, x1);
						(y2, x2) = XMLTools.GetCellIndexesBySize(Rows, Columns, y2, x2);
						WS.Cell(y1, x1).Value = entry.Key.Replace("_", string.Empty);
						//WS.Range(y1, x1, y2, x2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
						//int y = table.Fields[entry.Value[0]][entry.Value[1]][0];
						//int x = table.Fields[entry.Value[0]][entry.Value[1]][1];
						//(y, x) = XMLTools.GetCellIndexesBySize(Rows, Columns, y, x);
						//WS.Cell(y, x).Value = entry.Key.Replace("_", string.Empty);
					}
				}
				//if (table.HeaderList == null || table.Fields == null)
				//	continue;
				//for (int i = 0; i < table.HeaderList.Length; ++i)
				//{
				//	(int y, int x) = XMLTools.GetCellIndexesBySize(Rows, Columns, table.Fields[0][i][0], table.Fields[0][i][1]);
				//	WS.Cell(y, x).Value = table.HeaderList[i];
				//}
			}
		}

		private void FillTable()
		{
			foreach (GOST table in Tables)
			{
				for (int dataLine = 0;
					dataLine < table.LinesCount && dataLine < table.Data.Count;
					table.Line++, dataLine++)
				{
					for (int field = 0;
						field < table.Fields[table.Line].Count && field < table.Data[dataLine].Count;
						field++)
					{
						(int y1, int x1) = (table.Fields[table.Line][field][0], table.Fields[table.Line][field][1]);
						(y1, x1) = XMLTools.GetCellIndexesBySize(Rows, Columns, y1, x1);
						WS.Cell(y1, x1).Value = table.Data[dataLine][field];
						if (table.Type == GOST.Types.Table)
						{
							(int y2, int x2) = (table.Fields[table.Line][field][2], table.Fields[table.Line][field][3]);
							(y2, x2) = XMLTools.GetCellIndexesBySize(Rows, Columns, y2, x2);
							WS.Range(y1, x1, y2, x2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
						}
					}
				}
			}
		}

		//public void FillTable()
		//{
		//	foreach (GOST table in Tables)
		//	{
		//		table.ApplyGostData();
		//		for (int dataLine = 0;
		//			dataLine < table.LinesCount && dataLine < table.Data.Count;
		//			table.Line++, dataLine++)
		//		{
		//			for (int field = 0;
		//				field < table.Fields[table.Line].Count && field < table.Data[dataLine].Count;
		//				field++)
		//			{
		//				(int y1, int x1) = (table.Fields[table.Line][field][0], table.Fields[table.Line][field][1]);
		//				(y1, x1) = XMLTools.GetCellIndexesBySize(Rows, Columns, y1, x1);
		//				WS.Cell(y1, x1).Value = table.Data[dataLine][field];
		//				if (table.Type == GOST.Types.Table)
		//				{
		//					(int y2, int x2) = (table.Fields[table.Line][field][2], table.Fields[table.Line][field][3]);
		//					(y2, x2) = XMLTools.GetCellIndexesBySize(Rows, Columns, y2, x2);
		//					WS.Range(y1, x1, y2, x2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
		//				}
		//				//int y = table.Fields[table.Line][field][0];
		//				//int x = table.Fields[table.Line][field][1];
		//				//(y, x) = XMLTools.GetCellIndexesBySize(Rows, Columns, y, x);
		//				//WS.Cell(y, x).Value = table.Data[dataLine][field];
		//			}
		//		}
		//	}
		//}

		private void Kostyl()
		{
			// Set horizontal alignment for columns enumeration row
			if (Work.Book.Table == GOST.Standarts.GOST_21_110_2013_Table_1 &&
				Tables[0].Standart == Work.Book.Table &&
				Rvt.Control.EnumerateColumnsCheckBox == true)
			{
				(int y, int x) = (Tables[0].Fields[1][1][0], Tables[0].Fields[1][1][1]);
				(y, x) = XMLTools.GetCellIndexesBySize(Rows, Columns, y, x);
				//Log.WriteLine("cell {0} {1}. Text: {2}", y, x, WS.Cell(y, x).Value);
				WS.Cell(y, x).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
			}
		}

		public void TablesElemColsToData()
		{
			foreach (GOST table in Tables)
				table.ElemColToData();
		}

	} // class WorkSheet
} // namespace RevitToGOST
