namespace StackingEntities.Model.Entities.Other
{
	public class EyeOfEnder : EntityBase
	{
		public EyeOfEnder()
		{
			Type = EntityTypes.EyeOfEnderSignal;
		}

		public override string DisplayImage => "/StackingEntities.Resources;component/Images/Other/EyeOfEnder.png";
	}
}
