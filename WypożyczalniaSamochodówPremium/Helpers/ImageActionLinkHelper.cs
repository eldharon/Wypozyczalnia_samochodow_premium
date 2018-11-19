using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;


public static class ImageActionLinkHelper
{
    public static IHtmlString ImageActionLink(this AjaxHelper helper, string imageUrl, string altText, string actionName, object routeValues, AjaxOptions ajaxOptions)
    {
        var builder = new TagBuilder("img");
        builder.MergeAttribute("src", imageUrl);
        builder.MergeAttribute("alt", altText);
        var link = helper.ActionLink("[replaceme]", actionName, routeValues, ajaxOptions).ToHtmlString();
        return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing)));
    }

}
