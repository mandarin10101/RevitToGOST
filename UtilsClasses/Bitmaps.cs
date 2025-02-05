﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ExcelSpecificationGOST.Properties;

namespace ExcelSpecificationGOST
{
	public static partial class Work
	{
		public static Bitmaps Bitmaps { get; set; }
	}

	public class Bitmaps
	{
		#region properties

		public ImageSource Table { get; set; }
		public ImageSource Stamp { get; set; }
		public ImageSource Dop { get; set; }

		private int _PreviewPage = 1;
		public int PreviewPage
		{
			get { return _PreviewPage; }
			set
			{
				_PreviewPage = value;
				OnPreviewPageChanged();
			}
		}

		public int MaxPreviewPage
		{
			get
			{
				if (Work.Book.Title != GOST.Standarts.None)
					return 3;
				return 2;
			}
		}

		#endregion properties

		#region previewdata

		public static readonly Bitmap[] Previews =
		{
			Resources.Empty,	// None
			Resources.Preview_GOST_21_110_2013_Table_1,			// GOST_21_110_2013_Table_1
			Resources.Preview_GOST_P_21_101_2020_Stamp_3_A3_L,	// GOST_P_21_101_2020_Stamp_3
			Resources.Preview_GOST_P_21_101_2020_Dop_3_A3_L,	// GOST_P_21_101_2020_Dop_3
			Resources.Preview_GOST_P_21_101_2020_Stamp_4_A3_L,	// GOST_P_21_101_2020_Stamp_4
			Resources.Preview_GOST_P_21_101_2020_Dop_4_A3_L,	// GOST_P_21_101_2020_Dop_4
			Resources.Preview_GOST_P_21_101_2020_Stamp_5_A3_L,	// GOST_P_21_101_2020_Stamp_5
			Resources.Preview_GOST_P_21_101_2020_Dop_5_A3_L,	// GOST_P_21_101_2020_Dop_5
			Resources.Preview_GOST_P_21_101_2020_Stamp_6_A3_L,	// GOST_P_21_101_2020_Stamp_6
			Resources.Preview_GOST_P_21_101_2020_Dop_6_A3_L,	// GOST_P_21_101_2020_Dop_6
			null,	// GOST_P_21_101_2020_Table_7
			null,	// GOST_P_21_101_2020_Table_8
			null,	// misc 9
			null,	// misc 9a
			null,	// misc 10
			null,	// misc 11
			Resources.Preview_GOST_P_21_101_2020_Title_12,	// GOST_P_21_101_2020_Title_12
			Resources.Preview_GOST_P_21_101_2020_Title_12a,	// GOST_P_21_101_2020_Title_12a
			null,	// title 14
			Resources.Preview_GOST_2_104_2006_Stamp_1_A3_L,	// GOST_2_104_2006_Stamp_1
			Resources.Preview_GOST_2_104_2006_Dop_1_A3_L,	// GOST_2_104_2006_Dop_1
			Resources.Preview_GOST_2_104_2006_Stamp_2_A3_L,	// GOST_2_104_2006_Stamp_2
			Resources.Preview_GOST_2_104_2006_Dop_2_A3_L,	// GOST_2_104_2006_Dop_2
			Resources.Preview_GOST_2_104_2006_Stamp_2a_A3_L,	// GOST_2_104_2006_Stamp_2a
			Resources.Preview_GOST_2_104_2006_Dop_2a_A3_L,	// GOST_2_104_2006_Dop_2a
			Resources.Preview_GOST_21_301_2014_Title_2,	// GOST_21_301_2014_Title_2
			null,	// GOST_P_2_106_2019_Table_1
			Resources.Preview_GOST_P_2_106_2019_Table_5	// GOST_P_2_106_2019_Table_5
		};

		public static readonly Bitmap[] Previews_A4_P =
		{
			Resources.Empty,									// None
			null,	// GOST_21_110_2013_Table_1
			Resources.Preview_GOST_P_21_101_2020_Stamp_3_A4_P,	// GOST_P_21_101_2020_Stamp_3
			Resources.Preview_GOST_P_21_101_2020_Dop_3_A4_P,	// GOST_P_21_101_2020_Dop_3
			Resources.Preview_GOST_P_21_101_2020_Stamp_4_A4_P,	// GOST_P_21_101_2020_Stamp_4
			Resources.Preview_GOST_P_21_101_2020_Dop_4_A4_P,	// GOST_P_21_101_2020_Dop_4
			Resources.Preview_GOST_P_21_101_2020_Stamp_5_A4_P,	// GOST_P_21_101_2020_Stamp_5
			Resources.Preview_GOST_P_21_101_2020_Dop_5_A4_P,	// GOST_P_21_101_2020_Dop_5
			Resources.Preview_GOST_P_21_101_2020_Stamp_6_A4_P,	// GOST_P_21_101_2020_Stamp_6
			Resources.Preview_GOST_P_21_101_2020_Dop_6_A4_P,	// GOST_P_21_101_2020_Dop_6
			Resources.Preview_GOST_P_21_101_2020_Table_7,		// GOST_P_21_101_2020_Table_7
			Resources.Preview_GOST_P_21_101_2020_Table_8,		// GOST_P_21_101_2020_Table_8 (kostyl, don't touch)
			null,	// misc 9
			null,	// misc 9a
			null,	// misc 10
			null,	// misc 11
			Resources.Preview_GOST_P_21_101_2020_Title_12,	// GOST_P_21_101_2020_Title_12
			Resources.Preview_GOST_P_21_101_2020_Title_12a,	// GOST_P_21_101_2020_Title_12a
			null,	// title 14
			Resources.Preview_GOST_2_104_2006_Stamp_1_A4_P,	// GOST_2_104_2006_Stamp_1
			Resources.Preview_GOST_2_104_2006_Dop_1_A4_P,	// GOST_2_104_2006_Dop_1
			Resources.Preview_GOST_2_104_2006_Stamp_2_A4_P,	// GOST_2_104_2006_Stamp_2
			Resources.Preview_GOST_2_104_2006_Dop_2_A4_P,	// GOST_2_104_2006_Dop_2
			Resources.Preview_GOST_2_104_2006_Stamp_2a_A4_P,	// GOST_2_104_2006_Stamp_2a
			Resources.Preview_GOST_2_104_2006_Dop_2a_A4_P,	// GOST_2_104_2006_Dop_2a
			Resources.Preview_GOST_21_301_2014_Title_2,	// GOST_21_301_2014_Title_2
			Resources.Preview_GOST_P_2_106_2019_Table_1,	// GOST_P_2_106_2019_Table_1
			null	// GOST_P_2_106_2019_Table_5
		};

		#endregion

		#region events

		public event PropertyChangedEventHandler PreviewPageChanged;

		protected void OnPreviewPageChanged(string propertyName = null)
		{
			PreviewPageChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion events

		#region methods

		public void UpdateImages()
		{
			GOST.Standarts table = GOST.Standarts.None, stamp = GOST.Standarts.None, dop = GOST.Standarts.None;

			// Set current preview page standarts
			if (PreviewPage == 1)
			{
				if (Work.Book.Title != GOST.Standarts.None)
					table = Work.Book.Title;
				else
				{
					table = Work.Book.Table;
					stamp = Work.Book.Stamp1;
					dop = Work.Book.Dop1;
				}
			}
			else if (PreviewPage == 2)
			{
				if (Work.Book.Title != GOST.Standarts.None)
				{
					table = Work.Book.Table;
					stamp = Work.Book.Stamp1;
					dop = Work.Book.Dop1;
				}
				else
				{
					table = Work.Book.Table;
					stamp = Work.Book.Stamp2;
					dop = Work.Book.Dop2;
				}
			}
			else if (PreviewPage == 3)
			{
				if (Work.Book.Title != GOST.Standarts.None)
				{
					table = Work.Book.Table;
					stamp = Work.Book.Stamp2;
					dop = Work.Book.Dop2;
				}
			}

			// Pick right preview image
			if (table == GOST.Standarts.GOST_P_21_101_2020_Table_7 ||
				table == GOST.Standarts.GOST_P_21_101_2020_Table_8 ||
				table == GOST.Standarts.GOST_P_2_106_2019_Table_1) // if A4 or A3 Portrait
			{
				Table = Convert(Previews_A4_P[(int)table] ?? Previews_A4_P[0]);
				Stamp = Convert(Previews_A4_P[(int)stamp] ?? Previews_A4_P[0]);
				Dop = Convert(Previews_A4_P[(int)dop] ?? Previews_A4_P[0]);
			}
			else // if Title or A3 Landscape
			{
				Table = Convert(Previews[(int)table] ?? Previews[0]);
				Stamp = Convert(Previews[(int)stamp] ?? Previews[0]);
				Dop = Convert(Previews[(int)dop] ?? Previews[0]);
			}
		}

		public static ImageSource Convert(Bitmap bmp)
		{
			return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
		}

		public string PreviewPageString()
		{
			if (PreviewPage == MaxPreviewPage)
				return PreviewPage.ToString() + "...";
			return PreviewPage.ToString();
		}

		#endregion methods
	}
}
