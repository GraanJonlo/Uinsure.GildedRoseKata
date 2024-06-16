using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace GildedRoseKata;

public class LegacyItemWrapper(Item item)
{
    public void UpdateItem()
    {
        if (item.Name == "Aged Brie")
        {
            IncreaseQuality();

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                IncreaseQuality();
            }
        }
        else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.SellIn < 11)
                {
                    IncreaseQuality();
                }

                if (item.SellIn < 6)
                {
                    IncreaseQuality();
                }
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
        else if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
        }
        else
        {
            DecreaseQuality();

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                DecreaseQuality();
            }
        }
    }

    private void DecreaseQuality()
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }

    private void IncreaseQuality()
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
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