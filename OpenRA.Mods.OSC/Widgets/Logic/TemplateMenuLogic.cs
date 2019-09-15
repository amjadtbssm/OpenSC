#region Copyright & License Information
/*
 * Copyright 2007-2017 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using System.IO;
using System.Linq;
using System.Text;
using OpenRA.Mods.Common.Widgets;
using OpenRA.Widgets;

namespace OpenRA.Mods.Example.Widgets.Logic
{
	public class TemplateMenuLogic : ChromeLogic
	{
		[ObjectCreator.UseCtor]
		public TemplateMenuLogic(Widget widget, World world, ModData modData)
		{
			widget.Get<ButtonWidget>("QUIT_BUTTON").OnClick = Game.Exit;
			DetectCD();
		}

		private void DetectCD()
		{
			bool insertedStarcraftCD = false;
			var drivers = DriveInfo.GetDrives();
			foreach (var driver in drivers)
			{
				if (driver.DriveType == DriveType.CDRom && driver.IsReady)
				{
					var di = driver.RootDirectory;
					var fileFolderList = di.EnumerateFileSystemInfos();
					var findStarCraftSetupExe = fileFolderList.Where(o => o.Name == "SETUP.EXE");
					if (findStarCraftSetupExe.Count() == 1)
					{
						// Calculate Hash for SETUP.EXE
						using (FileStream fs = new FileStream(findStarCraftSetupExe.First().FullName, FileMode.Open, FileAccess.Read))
						{
							System.Security.Cryptography.SHA1 calculator = System.Security.Cryptography.SHA1.Create();
							byte[] buffer = calculator.ComputeHash(fs);

							StringBuilder hashBuilder = new StringBuilder();
							for (int i = 0; i < buffer.Length; i++)
							{
								hashBuilder.Append(buffer[i].ToString("x2"));
							}

							var hash = hashBuilder.ToString();
							if (hash == "cbb085bd0013f5aa57e5fdec743912ea92e6a9c4" ||
								hash == "8a46416e1d6bd98b83052767b05f2d41955805d0")
							{
								insertedStarcraftCD = true;
							}
						}

						if (insertedStarcraftCD)
						{
							break;
						}
					}
				}
			}

			if (!insertedStarcraftCD)
			{
				ConfirmationDialogs.ButtonPrompt(
					title: "Error",
					text: "Can't detect the Starcraft CD! Please insert the Starcraft CD to continue.",
					confirmText: "Retry",
					cancelText: "Quit",
					onCancel: Game.Exit,
					onConfirm: DetectCD);
			}
		}
	}
}
