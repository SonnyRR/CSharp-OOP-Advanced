namespace FestivalManager.Entities.Sets
{
    using FestivalManager.Entities.Contracts;
    using System;

	public class Short : Set, ISet
	{
		public Short(string name) 
			: base(name, new TimeSpan(0, 15, 0))
		{

		}
	}
}