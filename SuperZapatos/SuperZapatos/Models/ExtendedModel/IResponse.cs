namespace SuperZapatos.Models.ExtendedModel
{
    interface IResponse
    {
        /// <summary>
        /// Get response.
        /// </summary>
        /// <param name="entityType">Entity type.</param>
        /// <returns>Response.</returns>
        Response GetResponse(int entityType);
    }
}
