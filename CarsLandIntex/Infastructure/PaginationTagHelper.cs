using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using CarsLandIntex.Models.ViewModels;

namespace CarsLandIntex.Infastructure
{

    [HtmlTargetElement("div", Attributes = "book-page")]
    public class PagnationTagHelper : TagHelper
    {
        //create page links
        private IUrlHelperFactory uhf;

        public PagnationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }


        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        //This is received from teh html 
        public PageInfo BookPage { get; set; } //this has to be named the same as the Attributes thing up above.
        public string PageAction { get; set; }

        //this is the styles for the stuff
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("div");
            for (int i = 1; i <= BookPage.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                //this code below adds the css classes to the a tag
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    if (i == BookPage.CurrentPage)
                    {
                        tb.AddCssClass(PageClassSelected);
                    }
                    else
                    {
                        tb.AddCssClass(PageClassNormal);
                    }
                }
                //code above adds the css classes from bootstrap
                tb.InnerHtml.Append(i.ToString());
                final.InnerHtml.AppendHtml(tb);
            }

            output.Content.AppendHtml(final.InnerHtml);
        }
    }
}
