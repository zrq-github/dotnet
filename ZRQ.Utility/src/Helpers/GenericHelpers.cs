﻿namespace ZRQ.Utils.Helpers;

public static class GenericHelpers
{
    /// <summary>
    /// Generates tree of items from item list
    /// </summary>
    /// <typeparam name="T"> Type of item in collection </typeparam>
    /// <typeparam name="K"> Type of parent_id </typeparam>
    /// <param name="collection"> Collection of items </param>
    /// <param name="id_selector"> Function extracting item's id </param>
    /// <param name="parent_id_selector"> Function extracting item's parent_id </param>
    /// <param name="root_id"> Root element id </param>
    /// <returns> Tree of items </returns>
    public static IEnumerable<TreeItem<T>> GenerateTree<T, K>(
        this IEnumerable<T> collection,
        Func<T, K> id_selector,
        Func<T, K> parent_id_selector,
        K? root_id = default)
    {
        foreach (var c in collection.Where(c => EqualityComparer<K>.Default.Equals(parent_id_selector(c), root_id)))
            yield return new TreeItem<T>
            {
                Item = c,
                Children = collection.GenerateTree(id_selector, parent_id_selector, id_selector(c))
            };
    }
}

public class TreeItem<T>
{
    public IEnumerable<TreeItem<T>>? Children { get; set; }
    public T? Item { get; set; }
}