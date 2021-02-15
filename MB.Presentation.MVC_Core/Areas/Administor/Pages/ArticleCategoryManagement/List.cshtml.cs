using System.Collections.Generic;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC_Core.Areas.Administor.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        private readonly IArticleCategoryApplication _categoryApplication;

        public ListModel(IArticleCategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public List<ArticleCategoryViewModel> ArticleCategoryViewModels { get; set; }   
        
        public void OnGet()
        {
            ArticleCategoryViewModels = _categoryApplication.List();
        }

        public IActionResult OnPostRemove(long id)
        {
            _categoryApplication.Remove(id);
            return RedirectToPage("./List");
        }

        public IActionResult OnPostActivate(long id)
        {
            _categoryApplication.Activate(id);
            return RedirectToPage("./List");
        }
    }
}
