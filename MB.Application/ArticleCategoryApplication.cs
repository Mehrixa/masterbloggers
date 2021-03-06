﻿using System.Collections.Generic;
using System.Globalization;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel()
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDelete = articleCategory.IsDelete,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }

            return result;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title);
            _articleCategoryRepository.Add(articleCategory);
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.Save();
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);

            RenameArticleCategory rename = new RenameArticleCategory()
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };

            return rename;
        }

        public void Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _articleCategoryRepository.Save();
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }
    }
}
