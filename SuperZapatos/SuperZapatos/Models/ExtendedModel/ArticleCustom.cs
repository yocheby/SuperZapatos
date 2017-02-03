namespace SuperZapatos.Models.ExtendedModel
{
    /// <summary>
    /// Class to use in services.
    /// </summary>
    public class ArticleCustom
    {
        /// <summary>
        /// Entity primary key.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Article name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Article description.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Article prices.
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// Total in shelf.
        /// </summary>
        public int total_in_shelf { get; set; }

        /// <summary>
        /// Total in vault.
        /// </summary>
        public int total_in_vault { get; set; }

        /// <summary>
        /// Store name related to article.
        /// </summary>
        public string store_name { get; set; }
    }
}