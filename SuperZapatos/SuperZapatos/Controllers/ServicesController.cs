namespace SuperZapatos.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using SuperZapatos.Models;
    using SuperZapatos.Models.ExtendedModel;
    using System.Linq;

    public class ServicesController : ApiController
    {
        /// <summary>
        /// Load all the articles that are in the Database. 
        /// </summary>
        /// <returns>List of articles</returns>
        [BasicAuthentication]
        [ActionName("Articles")]
        public Response GetAllArticles()
        {
            try
            {
                var articlesCustom = new List<ArticleCustom>();
                Response response = new Response();

                using (SuperZapatosEntities db = new SuperZapatosEntities())
                {
                    var articles = db.Articles;
                    foreach (var itemArticle in articles)
                    {
                        articlesCustom.Add(new ArticleCustom()
                        {
                            id = itemArticle.id,
                            description = itemArticle.description,
                            name = itemArticle.name,
                            price = itemArticle.price,
                            total_in_shelf = itemArticle.total_in_shelf,
                            total_in_vault = itemArticle.total_in_vault,
                            store_name = itemArticle.Stores.name
                        });
                    }
                }

                CreatorResponse creator = new CreatorResponse(articlesCustom);

                return creator.GetResponse((int)EntityType.Article);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Load all the stores that are stored in the Database.
        /// </summary>
        /// <returns>List of stores.</returns>
        [BasicAuthentication]
        [ActionName("Stores")]
        public Response GetAllStores()
        {
            try
            {
                var storesCustom = new List<StoreCustom>();

                using (SuperZapatosEntities db = new SuperZapatosEntities())
                {
                    var stores = db.Stores;
                    foreach (var itemStore in stores)
                    {
                        storesCustom.Add(new StoreCustom()
                        {
                            id = itemStore.id,
                            name = itemStore.name,
                            address = itemStore.address
                        });
                    }
                }

                CreatorResponse creator = new CreatorResponse(storesCustom);
                return creator.GetResponse((int)EntityType.Store);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [BasicAuthentication]
        [ActionName("ArticlesById")]
        public Response GetArticlesById(string idStoreParameter)
        {
            try
            {
                int idStore = 0;
                if (!int.TryParse(idStoreParameter, out idStore))
                {
                    CreatorResponse creator = new CreatorResponse((int)ErrorType.BadRequest);
                    return creator.GetResponse((int)EntityType.Error);
                }

                var articlesCustom = new List<ArticleCustom>();
                Response response = new Response();

                using (SuperZapatosEntities db = new SuperZapatosEntities())
                {
                    var articles = db.Articles.Where(article => article.store_id == idStore).ToList();
                    
                    foreach (var itemArticle in articles)
                    {
                        articlesCustom.Add(new ArticleCustom()
                        {
                            id = itemArticle.id,
                            description = itemArticle.description,
                            name = itemArticle.name,
                            price = itemArticle.price,
                            total_in_shelf = itemArticle.total_in_shelf,
                            total_in_vault = itemArticle.total_in_vault,
                            store_name = itemArticle.Stores.name
                        });
                    }

                    CreatorResponse creator = new CreatorResponse(articlesCustom);
                    return creator.GetResponse((int)EntityType.Article);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
