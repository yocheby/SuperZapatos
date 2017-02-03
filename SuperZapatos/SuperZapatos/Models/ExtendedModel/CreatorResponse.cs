namespace SuperZapatos.Models.ExtendedModel
{
    using System;
    using System.Collections.Generic;

    public class CreatorResponse : IResponse
    {
        List<ArticleCustom> articlesCustom;
        List<StoreCustom> storesCustom;
        private int errorCode;

        public CreatorResponse(int errorCode)
        {
            this.errorCode = errorCode;
        }

        public CreatorResponse(List<ArticleCustom> articleCustomList)
        {
            this.articlesCustom = articleCustomList;
        }

        public CreatorResponse(List<StoreCustom> storeCustomList)
        {
            this.storesCustom = storeCustomList;
        }

        public Response GetResponse(int entityType)
        {
            switch (entityType)
            {
                case (int)EntityType.Article:

                    return this.GetArticles();

                case (int)EntityType.Store:

                    return this.GetStores();

                case (int)EntityType.Error:

                    return this.GetErrorResponse();

                default:
                    return new Response();
            }
        }

        private Response GetErrorResponse()
        {
            switch (this.errorCode)
            {
                case (int)ErrorType.BadRequest:
                    return new ResponseError()
                    { 
                        success = "false",
                        error_code = this.errorCode.ToString(),
                        error_msg = "Bad request"
                    };

                case (int)ErrorType.RecordNotFound:
                    return new ResponseError()
                    {
                        success = "false",
                        error_code = this.errorCode.ToString(),
                        error_msg = "Record not found"
                    };

                case (int)ErrorType.NotAuthorized:
                    return new ResponseError()
                    {
                        success = "false",
                        error_code = this.errorCode.ToString(),
                        error_msg = "No authorized"
                    };

                case (int)ErrorType.ServerError:
                    return new ResponseError()
                    {
                        success = "false",
                        error_code = this.errorCode.ToString(),
                        error_msg = "Server error"
                    };

                default:
                    return new Response();
            }
        }

        private Response GetArticles()
        {
            if (articlesCustom.Count == 1)
            {
                return new ResponseSuccessArticleSingle()
                {
                    success = "true",
                    article = articlesCustom[0],
                    total_elements = 1
                };
            }
            else if (articlesCustom.Count > 1)
            {
                return new ResponseSuccessArticleList()
                {
                    success = "true",
                    articles = articlesCustom,
                    total_elements = articlesCustom.Count
                };
            }
            else
            {
                return new ResponseError()
                {
                    success = "false",
                    error_code = ((int)ErrorType.RecordNotFound).ToString(),
                    error_msg = "Record Not Found"
                };
            }
        }

        private Response GetStores()
        {
            if (storesCustom.Count == 1)
            {
                return new ResponseSuccessStoreSingle()
                {
                    success = "true",
                    store = storesCustom[0],
                    total_elements = 1
                };
            }
            else if (storesCustom.Count > 1)
            {
                return new ResponseSuccessStoreList()
                {
                    success = "true",
                    stores = storesCustom,
                    total_elements = storesCustom.Count
                };
            }
            else
            {
                return new ResponseError()
                {
                    success = "false",
                    error_code = ((int)ErrorType.RecordNotFound).ToString(),
                    error_msg = "Record Not Found"
                };
            }
        }
    }

    enum EntityType : int
    {
        Article = 1 ,
        Store = 2,
        Error = 3
    }

    enum ErrorType : int
    {
        BadRequest = 400,
        NotAuthorized = 401,
        RecordNotFound = 404,
        ServerError = 500
    }
}