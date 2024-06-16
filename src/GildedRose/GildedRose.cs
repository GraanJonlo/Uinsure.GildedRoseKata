using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace GildedRoseKata;

public class LegacyItemWrapper(Item item)
{
    public Item Item { get; } = item;

    public void UpdateItem()
    {
        if (Item.Name == "Aged Brie")
        {
            IncreaseQuality();

            Item.SellIn -= 1;

            if (Item.SellIn < 0)
            {
                IncreaseQuality();
            }
        }
        else if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            if (Item.Quality < 50)
            {
                Item.Quality += 1;

                if (Item.SellIn < 11)
                {
                    IncreaseQuality();
                }

                if (Item.SellIn < 6)
                {
                    IncreaseQuality();
                }
            }

            Item.SellIn -= 1;

            if (Item.SellIn < 0)
            {
                Item.Quality = 0;
            }
        }
        else if (Item.Name == "Sulfuras, Hand of Ragnaros")
        {
        }
        else
        {
            DecreaseQuality();

            Item.SellIn -= 1;

            if (Item.SellIn < 0)
            {
                DecreaseQuality();
            }
        }
    }

    public void DecreaseQuality()
    {
        if (Item.Quality > 0)
        {
            Item.Quality -= 1;
        }
    }

    public void IncreaseQuality()
    {
        if (Item.Quality < 50)
        {
            Item.Quality += 1;
        }
    }
}

public class GildedRose(IList<Item> Items)
{
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            LegacyItemWrapper legacyItemWrapper = new(item);
            legacyItemWrapper.UpdateItem();
        }
    }
}