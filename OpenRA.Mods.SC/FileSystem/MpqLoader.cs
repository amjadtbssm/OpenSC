using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRA.FileSystem;

namespace OpenRA.Mods.SC.FileSystem
{
	public class MpqLoader : IPackageLoader
	{
		public bool TryParsePackage(Stream s, string filename, OpenRA.FileSystem.FileSystem context, out IReadOnlyPackage package)
		{
			package = null;

			return true;
		}
	}
}
