namespace USFH.Areas.Admin.DTOs.LinkProduct
{
    public class Collection
    {
        public long? id { get; set; }
        public string? title { get; set; }
        public string? urlName { get; set; }
        public string? description { get; set; }
        public string? imageUrl { get; set; }
        public string? sortOrder { get; set; }
    }

    public class Data
    {
        public int? totalCollections { get; set; }
        public object? collections { get; set; }
        public int? totalPages { get; set; }
        public object? pages { get; set; }
        public int? total { get; set; }
        public List<Item>? items { get; set; }
        public Extra? extra { get; set; }
    }

    public class Extra
    {
        public List<Collection>? collections { get; set; }
    }

    public class Image
    {
        public string? url { get; set; }
        public string? alt { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
    }

    public class Item
    {
        public object? id { get; set; }
        public string? productType { get; set; }
        public string? title { get; set; }
        public object? description { get; set; }
        public List<object>? collections { get; set; }
        public List<string>? tags { get; set; }
        public string? urlName { get; set; }
        public string? vendor { get; set; }
        public DateTime? date { get; set; }
        public List<Variant>? variants { get; set; }
        public object? selectedVariantId { get; set; }
        public List<Image>? images { get; set; }
        public List<Metafield>? metafields { get; set; }
        public List<object>? options { get; set; }
        public int? review { get; set; }
        public int? reviewCount { get; set; }
        public object? extra { get; set; }
    }

    public class Label
    {
        public string? label { get; set; }
        public int? value { get; set; }
    }

    public class Metafield
    {
        public string? key { get; set; }
        public object? value { get; set; }
        public bool? multiple { get; set; }
        public string? valueType { get; set; }
        public string? @namespace { get; set; }
    }

    public class CreateByLinkResponseDTO
    {
        public Data? data { get; set; }
    }

    public class Variant
    {
        public object? id { get; set; }
        public string? sku { get; set; }
        public object? barcode { get; set; }
        public int? available { get; set; }
        public double? price { get; set; }
        public double? weight { get; set; }
        public int? compareAtPrice { get; set; }
        public int? imageIndex { get; set; }
        public List<object>? options { get; set; }
        public object? metafields { get; set; }
        public int? flags { get; set; }
        public object? locations { get; set; }
    }


}
