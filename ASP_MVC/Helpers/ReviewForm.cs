using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace ASP_MVC.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlContent ReviewForm(this IHtmlHelper htmlHelper, int productId)
        {
            var form = new TagBuilder("form");
            form.Attributes.Add("method", "post");
            form.Attributes.Add("action", $"/Reviews/Create?productId={productId}");

            var ratingDiv = new TagBuilder("div");
            ratingDiv.AddCssClass("mb-3");

            var ratingLabel = new TagBuilder("label");
            ratingLabel.AddCssClass("form-label");
            ratingLabel.InnerHtml.Append("Rating:");

            var ratingSelect = new TagBuilder("select");
            ratingSelect.AddCssClass("form-control");
            ratingSelect.Attributes.Add("name", "rating");
            for (int i = 1; i <= 5; i++)
            {
                var option = new TagBuilder("option");
                option.Attributes.Add("value", i.ToString());
                option.InnerHtml.Append(i.ToString());
                ratingSelect.InnerHtml.AppendHtml(option);
            }

            ratingDiv.InnerHtml.AppendHtml(ratingLabel);
            ratingDiv.InnerHtml.AppendHtml(ratingSelect);

            var commentDiv = new TagBuilder("div");
            commentDiv.AddCssClass("mb-3");

            var commentLabel = new TagBuilder("label");
            commentLabel.AddCssClass("form-label");
            commentLabel.InnerHtml.Append("Comment:");

            var commentTextArea = new TagBuilder("textarea");
            commentTextArea.AddCssClass("form-control");
            commentTextArea.Attributes.Add("name", "comment");

            commentDiv.InnerHtml.AppendHtml(commentLabel);
            commentDiv.InnerHtml.AppendHtml(commentTextArea);

            var submitButton = new TagBuilder("button");
            submitButton.AddCssClass("btn btn-primary");
            submitButton.Attributes.Add("type", "submit");
            submitButton.InnerHtml.Append("Submit");

            form.InnerHtml.AppendHtml(ratingDiv);
            form.InnerHtml.AppendHtml(commentDiv);
            form.InnerHtml.AppendHtml(submitButton);

            return form;
        }
    }
}
