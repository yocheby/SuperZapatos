namespace SuperZapatos.Models.ExtendedModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Class to return list of stores.
    /// </summary>
    public class ResponseSuccessStoreList : Response
    {
        /// <summary>
        /// Return list of stores.
        /// </summary>
        public List<StoreCustom> stores { get; set; }

        /// <summary>
        /// Total elements.
        /// </summary>
        public int total_elements { get; set; }
    }
}