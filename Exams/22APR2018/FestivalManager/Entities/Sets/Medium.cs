namespace FestivalManager.Entities.Sets
{
    using FestivalManager.Entities.Contracts;
    using System;

	public class Medium : Set, ISet
	{
		public Medium(string name)
			: base(name, new TimeSpan(0,40,0))
		{
		
		}
	}
}