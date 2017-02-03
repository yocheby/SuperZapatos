namespace SuperZapatos.Models.ExtendedModel
{
    /// <summary>
    /// Class to response success single article.
    /// </summary>
    public class ResponseSuccessArticleSingle : Response
    {
        /// <summary>
        /// Article to response.
        /// </summary>
        public ArticleCustom article { get; set; }

        /// <summary>
        /// Total elements.
        /// </summary>
        public int total_elements { get; set; }
    }
}