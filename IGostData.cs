﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;

namespace RevitToGOST
{
	public interface IGostData
	{
		/*
		**	Member fields
		*/

		/*
		**	Member methods
		*/

		void FillLines();
		List<List<string>> FillList();
	} // public interface IGostData
} // namespace RevitToGOST
