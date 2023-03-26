using System;
namespace EntityFrameWorkLib
{
	public class RunePageEntity
	{
        public int Id { get; set; }
        public String? Name { get; set; }
    }

    public enum Category
    {
        Major,
        Minor1,
        Minor2,
        Minor3,
        OtherMinor1,
        OtherMinor2
    }
}

