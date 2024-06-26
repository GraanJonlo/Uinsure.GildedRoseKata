﻿using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace GildedRoseKata;

public class GildedRose(IList<Item> Items)
{
    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            UpdateItem(item);
        }
    }

    private static void UpdateItem(Item item)
    {
        if (item.Name == "Aged Brie")
        {
            IncreaseQuality(item);

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }
        else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.SellIn < 11)
                {
                    IncreaseQuality(item);
                }

                if (item.SellIn < 6)
                {
                    IncreaseQuality(item);
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
            DecreaseQuality(item);

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }
    }

    private static void DecreaseQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }

    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
    }
}