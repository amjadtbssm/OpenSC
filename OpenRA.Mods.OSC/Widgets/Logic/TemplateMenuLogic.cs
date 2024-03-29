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
		}
	}
}
