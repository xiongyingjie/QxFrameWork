﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Qx.Tools.Web.Mvc.Html
{
    public static class RichBoxExtensions
    {
        public static MvcHtmlString RichBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string tipString="")
        {
            var dest = new StringBuilder();
            dest.Append("<div class='form-group'>");
            dest.Append(htmlHelper.LabelFor(expression, new { @class = "col-md-3 control-label" }));
            dest.Append(" <div class='col-md-9'>");
            dest.Append(htmlHelper.Partial("/Views/Templates/_KindEditor.cshtml", new ViewDataDictionary()
                                   {
                                      { "css",""},
                                      { "id",htmlHelper.IdFor(expression).ToString()},
                                      { "name",htmlHelper.NameFor(expression).ToString()},
                                       { "value",htmlHelper.DisplayFor(expression).ToString()}
                                   }));
            dest.Append("<span class='help-block'>");
            dest.Append(tipString);
            dest.Append(" </span>");
            dest.Append(" </div>");
            dest.Append(" </div>");
            return new MvcHtmlString(dest.ToString());
        }

    }
}
