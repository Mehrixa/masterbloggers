using System;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDelete { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory(string title,IArticleCategoryValidatorServices services)
        {
            GuardAgainstEmptyTitle(title);
            services.CheckThatThisRecordIsAlReadyExists(title);
            Title = title;
            IsDelete = false;
            CreationDate = DateTime.Now;
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException();
        }

        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
        }

        public void Remove()
        {
            IsDelete = true;
        }

        public void Activate()
        {
            IsDelete = false;
        }
    }
}
