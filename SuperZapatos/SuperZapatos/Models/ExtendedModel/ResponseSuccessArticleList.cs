namespace SuperZapatos.Models.ExtendedModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Class to return list of articles.
    /// </summary>
    public class ResponseSuccessArticleList : Response
    {
        /// <summary>
        /// List of articles.
        /// </summary>
        public List<ArticleCustom> articles { get; set; }

        /// <summary>
        /// Total elements.
        /// </summary>
        public int total_elements { get; set; }
    }
}