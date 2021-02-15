namespace MB.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidatorServices
    {
        void CheckThatThisRecordIsAlReadyExists(string title);
    }
}
