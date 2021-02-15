using System;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorServices : IArticleCategoryValidatorServices
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorServices(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordIsAlReadyExists(string title)
        {
            if (_articleCategoryRepository.Exists(title))
                throw new Exception();
        }
    }
}