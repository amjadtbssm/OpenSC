using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRA.FileSystem;

namespace OpenRA.Mods.SC.FileSystem
{
	public class MpqArchive : IReadOnlyPackage
	{
		public string Name
		{
			get;
			set;
		}

		public IEnumerable<string> Contents { get { return null; } }

		public bool Contains(string filename)
		{
			return false;
		}

		public void Dispose()
		{
		}

		public Stream GetStream(string filename)
		{
			return null;
		}

		public IReadOnlyPackage OpenPackage(string filename, OpenRA.FileSystem.FileSystem context)
		{
			return null;
		}
	}
}
