using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace GildedRoseKata;

public class LegacyItemWrapper(Item item)
{
    public Item Item { get; } = item;
}

public class GildedRose(IList<Item> Items)
{
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            LegacyItemWrapper legacyItemWrapper = new(item);
            UpdateItem(legacyItemWrapper);
        }
    }

    private static void UpdateItem(LegacyItemWrapper item)
    {
        if (item.Item.Name == "Aged Brie")
        {
            IncreaseQuality(item);

            item.Item.SellIn -= 1;

            if (item.Item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }
        else if (item.Item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            if (item.Item.Quality < 50)
            {
                item.Item.Quality += 1;

                if (item.Item.SellIn < 11)
                {
                    IncreaseQuality(item);
                }

                if (item.Item.SellIn < 6)
                {
                    IncreaseQuality(item);
                }
            }

            item.Item.SellIn -= 1;

            if (item.Item.SellIn < 0)
            {
                item.Item.Quality = 0;
            }
        }
        else if (item.Item.Name == "Sulfuras, Hand of Ragnaros")
        {
        }
        else
        {
            DecreaseQuality(item);

            item.Item.SellIn -= 1;

            if (item.Item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }
    }

    private static void DecreaseQuality(LegacyItemWrapper item)
    {
        if (item.Item.Quality > 0)
        {
            item.Item.Quality -= 1;
        }
    }

    private static void IncreaseQuality(LegacyItemWrapper item)
    {
        if (item.Item.Quality < 50)
        {
            item.Item.Quality += 1;
        }
    }
}