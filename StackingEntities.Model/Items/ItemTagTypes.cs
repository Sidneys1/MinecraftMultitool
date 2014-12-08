using StackingEntities.Model.Items.ItemTags;
using StackingEntities.Model.Metadata;

namespace StackingEntities.Model.Items
{
	public enum ItemTagTypes
	{
		[ClassLink(typeof(ItemTagsGeneral))]
		General,
		[ClassLink(typeof(BlockType))]
		Block,
		[ClassLink(typeof(ItemTagsEnchantments))]
		Enchantments,
		//[ClassLink(typeof(ItemTags.ItemTagsAttributes))]
		//Attributes,
		//[ClassLink(typeof(ItemTags.ItemTagsEffects))]
		//PotionEffects,
		[ClassLink(typeof(ItemTagsDisplay))]
		DisplayProperties,
		[ClassLink(typeof(ItemTagsBook))]
		WrittenBooks,
		//[ClassLink(typeof(ItemTags.ItemTagsSkulls))]
		//PlayerSkulls,
		[ClassLink(typeof(ItemTagsFireworkStar))]
		Fireworks,
		[ClassLink(typeof(ItemTagsMap))]
		Maps
	}
}
