using System;

namespace Build.Mvc.TwitterBootstrap
{
	[Flags]
	public enum BtnStyles
	{
		None		= 0x00,
		Default		= 0x01,
		Primary		= 0x02,
		Info		= 0x04,
		Success		= 0x08,
		Warning		= 0x10,
		Danger		= 0x20,
		Link		= 0x40,
		Active		= 0x80,
		Disabled	= 0x100,
		Small		= 0x200,
		Large		= 0x400,
		Mini		= 0x800,
		Block		= 0x1000,
		[Obsolete("This class is not available in Twitter.Bootstrap version 3+", false)]
		Inverse		= 0x2000
	}
}
