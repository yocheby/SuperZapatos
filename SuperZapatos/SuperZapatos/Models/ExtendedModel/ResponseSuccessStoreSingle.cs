namespace SuperZapatos.Models.ExtendedModel
{
    /// <summary>
    /// Class to response success single store.
    /// </summary>
    public class ResponseSuccessStoreSingle : Response
    {
        /// <summary>
        /// Store to response.
        /// </summary>
        public StoreCustom store { get; set; }

        /// <summary>
        /// Total elements.
        /// </summary>
        public int total_elements { get; set; }
    }
}