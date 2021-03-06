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
  public static class InputExtensions
    {
        //
        // 摘要: 
        //     Returns a text input element for each property in the object that is represented
        //     by the specified expression, using the specified HTML attributes.
        //
        // 参数: 
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to
        //     render.
        //
        //   htmlAttributes:
        //     A dictionary that contains the HTML attributes to set for the element.
        //
        // 类型参数: 
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // 返回结果: 
        //     An HTML input element type attribute is set to "text" for each property in
        //     the object that is represented by the expression.
        //
        // 异常: 
        //   System.ArgumentException:
        //     The expression parameter is null or empty.
      public static MvcHtmlString InputFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TProperty>> expression, 
          string tipString = "", bool readOnly = false)
      {
          var dest = new StringBuilder();
          dest.Append("<div class='form-group'>");
          dest.Append(htmlHelper.LabelFor(expression, new { @class = "col-md-3 control-label" }));
          dest.Append(" <div class='col-md-9'>");
          dest.Append(readOnly
              ? htmlHelper.TextBoxFor(expression, new {@class = "form-control", @readonly = "readonly"})
              : htmlHelper.TextBoxFor(expression, new {@class = "form-control"}));
          dest.Append("<span class='help-block'>");
          dest.Append(tipString);
          dest.Append(" </span>");
          dest.Append(" </div>");
          dest.Append(" </div>");
          return new MvcHtmlString(dest.ToString());
      }


      public static MvcHtmlString Input2For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
           Expression<Func<TModel, TProperty>> expression,
           string tipString = "", bool readOnly = false)
      {

             //<div class="form-group">
             //                   <label>Text Input</label>
             //                   <input class="form-control">
             //                   <p class="help-block">
            //                       Example block-level help text here.
          //                        </p>
             //               </div>

          var dest = new StringBuilder();
          dest.Append("<div class='form-group'>");
          dest.Append("<label>");
          dest.Append(htmlHelper.DisplayNameFor(expression));
          dest.Append("</label>");
          dest.Append(readOnly
              ? htmlHelper.TextBoxFor(expression, new { @class = "form-control", @readonly = "readonly" })
              : htmlHelper.TextBoxFor(expression, new { @class = "form-control", placeholder = "请输入" + htmlHelper.DisplayNameFor(expression) }));
          dest.Append("<p class=\"help-block\">");
          dest.Append(tipString);
          dest.Append("</p>");
          dest.Append("</div>");
          return new MvcHtmlString(dest.ToString());
      }
    }


}
